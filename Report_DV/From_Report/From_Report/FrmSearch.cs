using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace From_Report
{
    public partial class FrmSearch : Form
    {
        #region Variable
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        public static string StrConnect = UTL.DataBase.GetConfig();
        DAL.Mau21BQPKhacDAL _DanhMuc = new DAL.Mau21BQPKhacDAL(StrConnect);
        #endregion

        public FrmSearch()
        {
            InitializeComponent();
        }

        private void FrmSearch_Load(object sender, EventArgs e)
        {

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
                            txtDoituong.Text = "BH:" + dt.Rows[i]["insurance_discount"].ToString();
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


    }
}
