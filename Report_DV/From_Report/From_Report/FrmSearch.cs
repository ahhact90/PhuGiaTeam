using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;

namespace From_Report
{
    public partial class FrmNgoaiTru : Form
    {
        #region Variable
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        public static string StrConnect = UTL.DataBase.GetConfig();
        DAL.Mau21BQPKhacDAL _DanhMuc = new DAL.Mau21BQPKhacDAL(StrConnect);
        string m_medicalrecordid;
        #endregion

        public FrmNgoaiTru()
        {
            InitializeComponent();
        }

        private void FrmSearch_Load(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            dt1 = _DanhMuc.Select_CV_NgoaiTru();
            gridControl2.DataSource = dt1;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtBA.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập số bệnh án");
            }
            else
            {
                try
                {
                    string tmp_bv = txtBA.Text.ToString().Trim();
                    dt = _DanhMuc.Select_ThongTinBA(tmp_bv.Trim());
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            txtName.Text = dt.Rows[i]["full_name"].ToString();
                            txtBHYT.Text = dt.Rows[i]["code"].ToString();
                            txtMedia.Text = dt.Rows[i]["id"].ToString();
                            txtBN.Text = dt.Rows[i]["patient_id"].ToString();
                            txtDoituong.Text = dt.Rows[i]["medical_object"].ToString();
                            txtvaovien.Text = dt.Rows[i]["reception_time"].ToString();
                            txtnamsinh.Text = dt.Rows[i]["birthday"].ToString();
                            txtfrom.Text = dt.Rows[i]["date_from"].ToString();
                            //txtfrom.Text.ToString("dd/MM/yyyy HH:mm:ss");
                            txtto.Text = dt.Rows[i]["date_to"].ToString();
                            txtsex.Text = dt.Rows[i]["sex_name"].ToString();
                            txtKhoa.Text = dt.Rows[i]["division_name"].ToString();
                            txtRavien.Text = dt.Rows[i]["close_time"].ToString();
                            txtStatus.Text = dt.Rows[i]["status"].ToString();
                        }
                    }


                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void gridView2_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            if (e.RowHandle % 2 == 0)
            {

                // e.Appearance.BackColor = Color.WhiteSmoke;
                e.Appearance.ForeColor = Color.MediumBlue;
                //e.HighPriority = true;


            }
            else
            {
                e.Appearance.ForeColor = Color.Firebrick;

            }
        }

        private void gridView2_Click(object sender, EventArgs e)
        {
           
            try
            {
                 m_medicalrecordid = gridView2.GetFocusedRowCellValue("medicalrecordid").ToString();
                 dt = _DanhMuc.Select_ThongTinBA_chitiet(m_medicalrecordid.Trim());
                 if (dt.Rows.Count > 0)
                 {
                     for (int i = 0; i < dt.Rows.Count; i++)
                     {
                         txtName.Text = dt.Rows[i]["full_name"].ToString();
                         txtBHYT.Text = dt.Rows[i]["code"].ToString();
                         txtMedia.Text = dt.Rows[i]["id"].ToString();
                         txtBN.Text = dt.Rows[i]["patient_id"].ToString();
                         txtDoituong.Text = dt.Rows[i]["medical_object"].ToString();
                         txtvaovien.Text = dt.Rows[i]["reception_time"].ToString();
                         txtnamsinh.Text = dt.Rows[i]["birthday"].ToString();
                         txtfrom.Text = dt.Rows[i]["date_from"].ToString();
                         //txtfrom.Text.ToString("dd/MM/yyyy HH:mm:ss");
                         txtto.Text = dt.Rows[i]["date_to"].ToString();
                         txtsex.Text = dt.Rows[i]["sex_name"].ToString();
                         txtKhoa.Text = dt.Rows[i]["division_name"].ToString();
                         txtRavien.Text = dt.Rows[i]["close_time"].ToString();
                         txtStatus.Text = dt.Rows[i]["status"].ToString();
                     }
                 }

            }
            catch (Exception)
            {
                
                throw;
            }

        }


    }
}
