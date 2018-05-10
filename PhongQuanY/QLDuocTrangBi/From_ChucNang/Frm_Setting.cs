using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDuocTrangBi.From_CauHinh
{
    public partial class Frm_Setting : Form
    {
        #region Variable
        public static string _key = "29fa797a-d341-4755-af56-8bf5aa6c9e5d";
        public static string _key1 = "2010-01-01;TRUONG ANH VU;COD-FWG-674-ECF";
        public static string StrConnect = UTL.DataBase.GetConfigMySQL();
        DAL.TestConnectDAL _TestConnect = new DAL.TestConnectDAL(StrConnect);


        #endregion

        public Frm_Setting()
        {
            InitializeComponent();
        }

        private void btn_Enc_Click(object sender, EventArgs e)
        {
            try
            {
                txtXuat.Text = UTL.DataBase.Encrypt(txtNhap.Text, _key, true).ToString();
            }
            catch (Exception)
            {

                return;
            }

        }

        private void btn_Dec_Click(object sender, EventArgs e)
        {
            try
            {
                txtXuat.Text = UTL.DataBase.Decrypt(txtNhap.Text, _key, true).ToString();
            }
            catch (Exception)
            {

                return;
            }
        }

        private void txtConnect_Click(object sender, EventArgs e)
        {          
            try
            {
                DataTable result2 = new DataTable();                
                result2 = _TestConnect.Showdata();
                lst_database.DataSource = result2;
                lst_database.DisplayMember = "Database";
                lst_database.ValueMember = "Database";
                MessageBox.Show("Kết nối CSDL thành công");
                
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối CSDL");
                
            }
        }
    }
}
