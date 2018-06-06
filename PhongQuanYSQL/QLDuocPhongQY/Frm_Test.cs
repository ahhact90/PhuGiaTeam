using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDuocPhongQY
{
    public partial class Frm_Test : Form
    {
        #region Variable        
        public static string StrConnect = UTL.DataBase.GetConfigSQL();
        DAL.TestConnectDAL _TestConnect = new DAL.TestConnectDAL(StrConnect);
        #endregion
        public Frm_Test()
        {
            InitializeComponent();
        }

        private void btbConnect_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable result2 = new DataTable();
                result2 = _TestConnect.Showdata();
                dataGridView1.DataSource = result2;                               
                MessageBox.Show("Kết nối CSDL thành công");
                gridControl1.DataSource = result2;
                MessageBox.Show("Kết nối CSDL thành công");
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối CSDL");

            }
        }
    }
}
