using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using Npgsql;
using System.Threading;

namespace WebService
{
    public partial class WebService : Form
    {
        public WebService()
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
        private NpgsqlCommand myPgCommand;
        private NpgsqlDataAdapter myPgAdapter;
        /// <summary>
        /// 
        /// </summary>
        private string PathBHYT;
        private string FileName;
        private string sobh;
        private string sql;
        private long MedID;
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
                dataTable = _Export.Select_Bang1(i);
                dataTable2 = _Export.Select_Bang2(i);
                dataTable3 = _Export.Select_Bang3(i);
                DataSet dataSet = new DataSet();
                DataSet dataSet2 = new DataSet();
                DataSet dataSet3 = new DataSet();
                dataSet.Tables.Add(_Export.Select_Bang1(i));
                dataSet2.Tables.Add(_Export.Select_Bang2(i));
                dataSet3.Tables.Add(_Export.Select_Bang3(i));

                if (dataTable.Rows.Count == 0)
                {
                    this.writelog(this.MedID.ToString());
                }
                else
                {
                    this.sobh = dataSet.Tables[0].Rows[0]["ma_the"].ToString();
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
            xmlDocument.Save(path + "\\" + string.Format("{0}_{1}_BHXH.xml", Medicalid, this.sobh));
            this.PathBHYT = path + "\\" + string.Format("{0}_{1}_BHXH.xml", Medicalid, this.sobh);
            this.FileName = string.Format("{0}_{1}_BHXH.xml", Medicalid, this.sobh);
            string data = File.ReadAllText(path + "\\" + string.Format("{0}_{1}_BHXH.xml", Medicalid, this.sobh));
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
            try
            {
                string path = "\\\\172.251.110.194\\Log\\log.txt";
                if (File.Exists(path))
                {
                    File.AppendAllText(path, "### " + MedID + Environment.NewLine);
                }
                else
                {
                    File.WriteAllText(path, "### " + MedID + Environment.NewLine);
                }
            }
            catch
            {
            }
        }

        #endregion

        private void btnExport_Click(object sender, EventArgs e)
        {                 
            //string lashpath = Path.GetFullPath(openFileDialog1.FileName);
            //txtPath.Text = lashpath;
            string lashpath = txtPath.Text.Trim();
            btnExport.Enabled = false;
            Thread thread = new Thread(() =>
            {
              
                    while (true)
                    {
                        try
                        {
                            MedID = _Export.Select_Medical();
                            if (MedID < 0 )
                            {
                                //MessageBox.Show("Không có dữ liệu cần Export...");
                                //this.Close();
                                //Application.Exit();
                                goto sleep;
                            }
                   
                            if (MedID > 0L)
                            {
                                _Export.his_fee_sync_tonghop(MedID);
                                 Export3file(lashpath, MedID);
                                _Export.FinishMed(MedID);
                        
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
        
        

        private void WebService_Load(object sender, EventArgs e)
        {
            string STR_DBNAME = @"E:\Teca\VAS\QD917";
            txtPath.Text = STR_DBNAME;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
