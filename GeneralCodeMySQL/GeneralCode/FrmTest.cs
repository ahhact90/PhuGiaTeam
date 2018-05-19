using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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
                DataTable result_tablename = new DataTable();
                result2 = _TestConnect.Showdata();
                //result_tablename = _TestConnect.ShowTable();       
                cmbDatabase.DisplayMember = "Database";
                cmbDatabase.ValueMember = "Database";
                cmbDatabase.DataSource = result2;
                cmbDatabase.SelectedIndex = 4;
                
                //lstConnect.DataSource = result2;
                //lstConnect.DisplayMember = "Database";
                //lstConnect.ValueMember = "Database";     


                MessageBox.Show("Kết nối CSDL thành công");
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối CSDL");

            }
        }

        private void cmbDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable result_tablename = new DataTable();

            lstConnect.Items.Clear();
            result_tablename = _TestConnect.ShowTable(cmbDatabase.Text.ToString());
            lstConnect.DataSource = result_tablename;
           // lstConnect.DisplayMember = "table";
            //lstConnect.ValueMember = "table";  
        }
    }
}
