using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneralCode
{
    public partial class FrmTest : Form
    {
        #region Variable
        public static string _key = "29fa797a-d341-4755-af56-8bf5aa6c9e5d";
        public static string _key1 = "2010-01-01;TRUONG ANH VU;COD-FWG-674-ECF";
        public static string StrConnect = UTL.DataBase.GetConfigMySQL();
        DAL.TestConnectDAL _TestConnect = new DAL.TestConnectDAL(StrConnect);
        #endregion

        public FrmTest()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable result2 = new DataTable();
                result2 = _TestConnect.Showdata();               
                lstConnect.DataSource = result2;
                lstConnect.DisplayMember = "Database";
                lstConnect.ValueMember = "Database";
                MessageBox.Show("Kết nối CSDL thành công");

            }
            catch
            {
                MessageBox.Show("Lỗi kết nối CSDL");

            }
        }
    }
}
