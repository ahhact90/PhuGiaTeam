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

namespace QLDuocTrangBi
{
    public partial class FrmTest : Form
    {
        public FrmTest()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                txtXuat.Text = UTL.Currency.ToString(decimal.Parse(txtNhap.Text));
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Vui lòng nhập đầy đủ dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

       
    }
}
