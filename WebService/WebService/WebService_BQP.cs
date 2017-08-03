using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using Npgsql;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net;
using System.Net.Http.Headers;

namespace WebService
{
    public partial class WebService_BQP : Form
    {
        public WebService_BQP()
        {
            InitializeComponent();
        }

        #region Variable
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        public static string StrConnect = UTL.DataBase.GetConfig();
        public static string lashpath = UTL.DataBase.GetConfig();
        DAL.Mau21BQPKhacDAL _Export = new DAL.Mau21BQPKhacDAL(StrConnect);
        /// <summary>
        /// Ket noi Postgrest
        /// </summary>
        public NpgsqlConnection myPgConnect;
        //private NpgsqlCommand myPgCommand;
        //private NpgsqlDataAdapter myPgAdapter;
        /// <summary>
        /// 
        /// </summary>
        private string PathBHYT;
        private string FileName;
        private string sobh;
        private string sql;
        private long MedID;
        private long MedID_tmp;
        private string sobn;
        private string doituong_bn;
        private string ten_bn;
        private string log_tenbn;
        private string log_doituongbn;
        private HttpClient client = new HttpClient();
        private string[] result1;
        private string[] ketqua;
        private string[] access;
        private string[] idtoken;
        private string kq;
        private string access1;
        private string token;
        private string username = "92002_BV";
        private string password = "dfe99ede6292051396d3cbea73f4985d";
        //private string lashpath;

        #endregion
        #region Methods

        /// <summary>
        /// Export 3 bang thanh 1 file xml
        /// </summary>
        /// <param name="path"></param>
        /// <param name="i"></param>
        private void Export3file(string path, long i)
        {
            try
            {
                string xml = "";
                string xml2 = "";
                string xml3 = "";
                DataTable dataTable = new DataTable();
                DataTable dataTable2 = new DataTable();
                DataTable dataTable3 = new DataTable();
                DataTable dataTable4 = new DataTable();
                dataTable = _Export.Select_Bang1(i);
                dataTable2 = _Export.Select_Bang2(i);
                dataTable3 = _Export.Select_Bang3(i);
                dataTable4 = _Export.Select_his_chitiet_bhyt(i);
                DataSet dataSet = new DataSet();
                DataSet dataSet2 = new DataSet();
                DataSet dataSet3 = new DataSet();
                DataSet dataSet4 = new DataSet();

                dataSet.Tables.Add(_Export.Select_Bang1(i));
                dataSet2.Tables.Add(_Export.Select_Bang2(i));
                dataSet3.Tables.Add(_Export.Select_Bang3(i));
                dataSet4.Tables.Add(_Export.Select_his_chitiet_bhyt(i));
                                                 
                

                if (dataTable.Rows.Count == 0)
                {
                    this.writelog(this.MedID.ToString());
                }
                else
                {
                    this.sobh = dataSet.Tables[0].Rows[0]["ma_the"].ToString();
                    this.sobn = dataSet.Tables[0].Rows[0]["ma_bn"].ToString();
                    this.doituong_bn = dataSet4.Tables[0].Rows[0]["doituong_bn"].ToString();
                    this.ten_bn = dataSet4.Tables[0].Rows[0]["tenbn"].ToString(); 
                    XmlDocument xmlDocument = new XmlDocument();
                    StringBuilder stringBuilder = new StringBuilder();
                    using (XmlWriter xmlWriter = XmlWriter.Create(stringBuilder, new XmlWriterSettings
                    {
                        Encoding = Encoding.UTF8
                    }))
                    {
                        xmlWriter.WriteStartDocument(true);
                        xmlWriter.WriteStartElement("TONG_HOP");
                        dataSet.Tables[0].WriteXml(xmlWriter);
                        xmlWriter.WriteEndElement();
                        xmlWriter.WriteEndDocument();
                        xmlWriter.Flush();
                        xmlWriter.Close();
                    }
                    this.sql = stringBuilder.ToString();
                    this.sql = this.sql.Replace("<NewDataSet>", "");
                    this.sql = this.sql.Replace("</NewDataSet>", "");
                    this.sql = this.sql.Replace("<Table1>", "");
                    this.sql = this.sql.Replace("</Table1>", "");
                    this.sql = this.sql.Replace("&lt;", "<");
                    this.sql = this.sql.Replace("&gt;", ">");
                    this.sql = this.sql.Replace("<Tmp>", "");
                    this.sql = this.sql.Replace("</Tmp>", "");
                    this.sql = this.sql.Replace("<nam_qt>0</nam_qt>", "<nam_qt>" + DateTime.Now.Year.ToString() + "</nam_qt>");
                    this.sql = this.sql.Replace("<thang_qt>0</thang_qt>", "<thang_qt>" + DateTime.Now.Month.ToString() + "</thang_qt>");
                    xmlDocument.LoadXml(this.sql);
                    xmlDocument.Save(path + "\\" + string.Format("{0}_{1}_XML1.xml", this.MedID, this.sobh));
                    byte[] inArray = File.ReadAllBytes(path + "\\" + string.Format("{0}_{1}_XML1.xml", this.MedID, this.sobh));
                    xml = Convert.ToBase64String(inArray);
                    File.Delete(path + "\\" + string.Format("{0}_{1}_XML1.xml", this.MedID, this.sobh));
                    if (dataTable2.Rows.Count > 0)
                    {
                        xmlDocument = new XmlDocument();
                        stringBuilder = new StringBuilder();
                        XmlWriterSettings settings = new XmlWriterSettings();
                        using (XmlWriter xmlWriter = XmlWriter.Create(stringBuilder, settings))
                        {
                            xmlWriter.WriteStartDocument(true);
                            xmlWriter.WriteStartElement("DSACH_CHI_TIET_THUOC");
                            dataSet2.Tables[0].TableName = "CHI_TIET_THUOC";
                            dataSet2.Tables[0].WriteXml(xmlWriter);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteEndDocument();
                            xmlWriter.Flush();
                            xmlWriter.Close();
                        }
                        this.sql = stringBuilder.ToString();
                        this.sql = this.sql.Replace("<NewDataSet>", "");
                        this.sql = this.sql.Replace("</NewDataSet>", "");
                        this.sql = this.sql.Replace("<Table1>", "");
                        this.sql = this.sql.Replace("</Table1>", "");
                        this.sql = this.sql.Replace("&lt;", "<");
                        this.sql = this.sql.Replace("&gt;", ">");
                        xmlDocument.LoadXml(this.sql);
                        xmlDocument.Save(path + "\\" + string.Format("{0}_{1}_XML2.xml", this.MedID, this.sobh));
                        byte[] inArray2 = File.ReadAllBytes(path + "\\" + string.Format("{0}_{1}_XML2.xml", this.MedID, this.sobh));
                        xml2 = Convert.ToBase64String(inArray2);
                        File.Delete(path + "\\" + string.Format("{0}_{1}_XML2.xml", this.MedID, this.sobh));
                    }
                    if (dataTable3.Rows.Count > 0)
                    {
                        xmlDocument = new XmlDocument();
                        stringBuilder = new StringBuilder();
                        XmlWriterSettings settings = new XmlWriterSettings();
                        using (XmlWriter xmlWriter = XmlWriter.Create(stringBuilder, settings))
                        {
                            xmlWriter.WriteStartDocument(true);
                            xmlWriter.WriteStartElement("DSACH_CHI_TIET_DVKT");
                            dataSet3.Tables[0].TableName = "CHI_TIET_DVKT";
                            dataSet3.Tables[0].WriteXml(xmlWriter);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteEndDocument();
                            xmlWriter.Flush();
                            xmlWriter.Close();
                        }
                        this.sql = stringBuilder.ToString();
                        this.sql = this.sql.Replace("<NewDataSet>", "");
                        this.sql = this.sql.Replace("</NewDataSet>", "");
                        this.sql = this.sql.Replace("<Table1>", "");
                        this.sql = this.sql.Replace("</Table1>", "");
                        this.sql = this.sql.Replace("&lt;", "<");
                        this.sql = this.sql.Replace("&gt;", ">");
                        xmlDocument.LoadXml(this.sql);
                        xmlDocument.Save(path + "\\" + string.Format("{0}_{1}_XML3.xml", this.MedID, this.sobh));
                        byte[] inArray3 = File.ReadAllBytes(path + "\\" + string.Format("{0}_{1}_XML3.xml", this.MedID, this.sobh));
                        xml3 = Convert.ToBase64String(inArray3);
                        File.Delete(path + "\\" + string.Format("{0}_{1}_XML3.xml", this.MedID, this.sobh));
                    }
                    this.ExportGeneral(path, xml, xml2, xml3, this.MedID.ToString());
                }
            }
            catch (Exception ex)
            {
                this.writelog(this.MedID.ToString() + " " + ex.ToString());
            }
            finally
            {
                //this.myPgConnect.Close();
            }
        }
        /// <summary>
        /// Xuat ra file XML
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="xml1"></param>
        /// <param name="xml2"></param>
        /// <param name="xml3"></param>
        /// <param name="Medicalid"></param>
        private void ExportGeneral(string path, string xml1, string xml2, string xml3, string Medicalid)
        {
            XmlDocument xmlDocument = new XmlDocument();
            StringBuilder stringBuilder = new StringBuilder();
            XmlWriter xmlWriter = XmlWriter.Create(stringBuilder);
            xmlWriter.WriteStartDocument(true);
            xmlWriter.WriteStartElement("GIAMDINHHS");
            xmlWriter.WriteStartElement("THONGTINDONVI");
            xmlWriter.WriteStartElement("MACSKCB");
            xmlWriter.WriteString("92002");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("THONGTINHOSO");
            xmlWriter.WriteStartElement("NGAYLAP");
            xmlWriter.WriteString(DateTime.Now.ToString("yyyyMMdd"));
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("SOLUONGHOSO");
            xmlWriter.WriteString("1");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("DANHSACHHOSO");
            xmlWriter.WriteStartElement("HOSO");
            xmlWriter.WriteStartElement("FILEHOSO");
            xmlWriter.WriteStartElement("LOAIHOSO");
            xmlWriter.WriteString("XML1");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("NOIDUNGFILE");
            xmlWriter.WriteString(xml1);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            if (xml2.CompareTo("") != 0)
            {
                xmlWriter.WriteStartElement("FILEHOSO");
                xmlWriter.WriteStartElement("LOAIHOSO");
                xmlWriter.WriteString("XML2");
                xmlWriter.WriteEndElement();
                xmlWriter.WriteStartElement("NOIDUNGFILE");
                xmlWriter.WriteString(xml2);
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndElement();
            }
            if (xml3.CompareTo("") != 0)
            {
                xmlWriter.WriteStartElement("FILEHOSO");
                xmlWriter.WriteStartElement("LOAIHOSO");
                xmlWriter.WriteString("XML3");
                xmlWriter.WriteEndElement();
                xmlWriter.WriteStartElement("NOIDUNGFILE");
                xmlWriter.WriteString(xml3);
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndElement();
            }
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Flush();
            xmlWriter.Close();
            string text = stringBuilder.ToString();
            text = text.Replace("<NewDataSet>", "");
            text = text.Replace("</NewDataSet>", "");
            text = text.Replace("<Table1>", "");
            text = text.Replace("</Table1>", "");
            xmlDocument.LoadXml(text);
            xmlDocument.Save(path + "\\" + string.Format("{0}_{1}_{2}_{3}_{4}_BQP.xml", this.doituong_bn, Medicalid, this.sobh, this.sobn, this.ten_bn));
            this.PathBHYT = path + "\\" + string.Format("{0}_{1}_{2}_{3}_{4}_BQP.xml", this.doituong_bn, Medicalid, this.sobh, this.sobn, this.ten_bn);
            this.FileName = string.Format("{0}_{1}_{2}_{3}_{4}_BQP.xml", this.doituong_bn, Medicalid, this.sobh, this.sobn, this.ten_bn);
            string data = File.ReadAllText(path + "\\" + string.Format("{0}_{1}_{2}_{3}_{4}_BQP.xml", this.doituong_bn, Medicalid, this.sobh, this.sobn, this.ten_bn));
            //this.new_sign(data, Medicalid);
        }
        public void WriteLog(string Contents)
        {
            try
            {
                string path = "\\\\172.251.110.194\\Log\\log.txt";
                if (File.Exists(path))
                {
                    File.AppendAllText(path, string.Concat(new string[]
					{
						"### ",
						this.FileName,
						"|",
						Contents,
						Environment.NewLine
					}));
                }
                else
                {
                    File.WriteAllText(path, string.Concat(new string[]
					{
						"### ",
						this.FileName,
						"|",
						Contents,
						Environment.NewLine
					}));
                }
            }
            catch
            {
            }
        }
        private void writelog(string MedID)
        {
            long sohoso;
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                //string path = "\\\\172.251.110.194\\Log\\log.txt";
                string path = txtBackup_BQP.Text.Trim() + string.Format("\\log_{0}_BQP.txt", System.DateTime.Now.ToString("yyyyMMdd"));
                sohoso = Int64.Parse(MedID);
                //dt = _Export.Select_his_chitiet_bhyt(sohoso);                
                ds.Tables.Add(_Export.Select_his_chitiet_bhyt(sohoso));
                log_tenbn = ds.Tables[0].Rows[0]["tenbn"].ToString();
                log_doituongbn = ds.Tables[0].Rows[0]["doituong_bn"].ToString();
                if (File.Exists(path))
                {
                    File.AppendAllText(path, System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ": " + MedID + " " + log_tenbn + " " + "Đối tượng BN " + log_doituongbn + Environment.NewLine);
                    //MessageBox.Show("file log noi tiep " + MedID);
                }
                else
                {
                    File.WriteAllText(path, System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ": " + MedID + " " + log_tenbn + " " + "Đối tượng BN " + log_doituongbn + Environment.NewLine);
                    // MessageBox.Show("File mới tạo " + MedID);
                }
            }
            catch
            {
            }
        }

        #endregion

        private void btnExport_Click(object sender, EventArgs e)
        {    
            
        }     

        
        
        /// <summary>
        /// Lấy đường để xuất file Export XML
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       
        private void btnExprot_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtPathEx.Text = fbd.SelectedPath;
            }
        }

        private void btnbackup_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtPathEx.Text = fbd.SelectedPath;
            }
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
        }

        private void WebService_BQP_Load(object sender, EventArgs e)
        {
            string STR_DBNAME = @"E:\TecaBQP\QD917";
            txtPathEx.Text = STR_DBNAME;            
            string STR_DBNAME_BACKUP = @"E:\TecaBQP\QD917\Backup";
            txtBackup_BQP.Text = STR_DBNAME_BACKUP;
        }

        private void btnExport_Click_1(object sender, EventArgs e)
        {
            string lashpath = txtPathEx.Text.Trim();
            //string pathBackup = txtBackup_BQP.Text.Trim();

            string pathBackup = txtBackup_BQP.Text.Trim() + "\\" + DateTime.Now.ToString("yyyyMMdd");

            if (!Directory.Exists(pathBackup))
            {
                Directory.CreateDirectory(pathBackup);
            }

            btnExport.Enabled = false;
            Thread thread = new Thread(() =>
            {

                while (true)
                {
                    try
                    {
                        //MedID = _Export.Select_Medical_BQP();

                        if (rdoNgTru.Checked == true)
                        {
                            string doituongbn = "1,3";
                            MedID = _Export.Select_Medical_BQP_With_doituong(doituongbn);


                        }
                        //// Thận Nhân Tạo
                        else if (rdoTNT.Checked == true)
                        {
                            string doituongbn = "4";
                            MedID = _Export.Select_Medical_BQP_With_doituong(doituongbn);

                        }
                        //// Thận Nhân Tạo + Ngoại Trú
                        else if (rdoNgTNT.Checked == true)
                        {
                            string doituongbn = "1,3,4";
                            MedID = _Export.Select_Medical_BQP_With_doituong(doituongbn);                            

                        }
                        //// Nội Trú
                        else if (rdoNTru.Checked == true)
                        {
                            string doituongbn = "2";
                            MedID = _Export.Select_Medical_BQP_With_doituong(doituongbn);

                        }
                        else
                        {
                            string doituongbn = "1,2,3,4";
                            MedID = _Export.Select_Medical_BQP_With_doituong(doituongbn);
                        }



                        if (MedID < 0)
                        {
                            goto sleep;
                        }

                        if (MedID > 0L)
                        {
                            string tam = _Export.his_find_medical(MedID);
                            if (tam == "Error")
                            {

                                _Export.FinishMed(MedID);
                                string Medical = MedID.ToString();
                                writelog(Medical);
                                //MessageBox.Show("Bệnh án đã gửi lên cổng thông tin rồi. Vui lòng kiểm tra lại " + Medical);
                                goto sleep;

                            }
                            else
                            {
                                _Export.his_fee_sync_tonghop_bqp(MedID);
                                Export3file(lashpath, MedID);
                                //MessageBox.Show("Bệnh án đã gửi lên cổng thông tin rồi. Vui lòng kiểm tra lại " + MedID);
                                Export3file(pathBackup, MedID);
                                _Export.Finish_his_medical(MedID);
                            }


                        }
                    sleep:
                        Thread.Sleep(5000);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            );  // Tao mot luong du lieu rieng de may chay khong bi treo
            thread.Start();

        }

            

    }
    }



