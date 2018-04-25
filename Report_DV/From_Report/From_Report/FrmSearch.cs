using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.Design.GroupSort;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid.Views.BandedGrid;

namespace From_Report
{
    public partial class FrmSearch : Form 
    {
        #region Variable
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        public static string StrConnect = UTL.DataBase.GetConfig();
        DAL.Mau21BQPKhacDAL _DanhMuc = new DAL.Mau21BQPKhacDAL(StrConnect);
        string m_medicalrecordid;

        public static string cal_from
        {
            get;
            set;
        }

        public static string cal_to
        {
            get;
            set;
        }
        public static string cal_search
        {
            get;
            set;
        }

        #endregion

        public FrmSearch()
        {
            InitializeComponent();
        }

        private void FrmSearch_Load(object sender, EventArgs e)
        {           

            if (chbox_hientai.Checked == true)
            {
                DataTable dt = new DataTable();
                dt = _DanhMuc.Select_ThongTinBA_hientai();
                gridControl2.DataSource = dt;
            }
            if (chbox_hientai.Checked == false)
            {
                try
                {
                    DataTable dt_Se = new DataTable();
                    dt_Se = _DanhMuc.Select_CV_NgoaiTru();
                    gridControl2.DataSource = dt_Se;
                }
                catch (Exception)
                {

                    throw;
                }

            }
  
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
                    //MessageBox.Show(txtBA.Text);
                    //string tmp_bv =  FrmSearch.cal_search.ToString().Trim();
                    dt = _DanhMuc.Select_ThongTinBA_chitiet(tmp_bv.Trim());
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
                e.Appearance.ForeColor = Color.MediumBlue;               
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

        private void chbox_hientai_Click(object sender, EventArgs e)
        {
            

            if (chbox_hientai.Checked == true)
            {
                DataTable dt = new DataTable();
                dt = _DanhMuc.Select_ThongTinBA_hientai();
                gridControl2.DataSource = dt;
            }
            if (chbox_hientai.Checked == false)
            {
                try
                {
                    DataTable dt_Se = new DataTable();
                    dt_Se = _DanhMuc.Select_CV_NgoaiTru();
                    gridControl2.DataSource = dt_Se;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void FrmNgoaiTru_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    string tmp_bv = FrmSearch.cal_search.ToString().Trim();
                    dt = _DanhMuc.Select_ThongTinBA_chitiet(tmp_bv.Trim());
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

        private void chbox_hientai_CheckedChanged(object sender, EventArgs e)
        {
            
            if (chbox_hientai.Checked == true)
            {
                DataTable dt = new DataTable();
                dt = _DanhMuc.Select_ThongTinBA_hientai();
                gridControl2.DataSource = dt;
            }
            if (chbox_hientai.Checked == false)
            {
                try
                {
                    DataTable dt_Se = new DataTable();
                    dt_Se = _DanhMuc.Select_CV_NgoaiTru();
                    gridControl2.DataSource = dt_Se;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void xtraTabControl2_Click(object sender, EventArgs e)
        {
            if (chbox_hientai.Checked == true)
            {
                DataTable dt = new DataTable();
                dt = _DanhMuc.Select_ThongTinBA_hientai();
                gridControl3.DataSource = dt;
            }
            if (chbox_hientai.Checked == false)
            {
                try
                {
                    DataTable dt_Se = new DataTable();
                    dt_Se = _DanhMuc.Select_CV_NoiTru();
                    gridControl3.DataSource = dt_Se;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void gridView3_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            if (e.RowHandle % 2 == 0)
            {
                e.Appearance.ForeColor = Color.MediumBlue;
               

            }
            else
            {
                e.Appearance.ForeColor = Color.Firebrick;

            }
        }

        private void gridView3_Click(object sender, EventArgs e)
        {
            try
            {
                m_medicalrecordid = gridView3.GetFocusedRowCellValue("medicalrecordid").ToString();
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

        private void btnCV_Click(object sender, EventArgs e)
        {
            string tmp_bv = txtMedia.Text.ToString().Trim();
            ds = _DanhMuc.Giay_CV(tmp_bv);
            if (ds == null)
            {
                MessageBox.Show("Dữ liệu rỗng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
            }
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            Report.Rpt_Chuyentuyen f21 = new Report.Rpt_Chuyentuyen();
            f21.DataSource = ds;
            f21.DataMember = ds.Tables[0].TableName;            
            f21.ShowPreview();
      
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {

        }
       
    }
}

