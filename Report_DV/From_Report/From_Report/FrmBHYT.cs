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
    public partial class FrmBHYT : Form
    {
        #region Variable
        public static string string1 = "server = localhost; port = 5432; user id = postgres; password = P@$121# ; Database = HMIS";
        DAL.Mau21BQPKhacDAL _DanhMuc = new DAL.Mau21BQPKhacDAL(string1);
        #endregion
        public FrmBHYT()
        {
            InitializeComponent();
        }

        private void btnBhyt_Click(object sender, EventArgs e)
        {
            try
            {
                txtBA.Text.Trim();
                txtBA.Text.ToString();
                long Media = long.Parse(txtBA.Text);
                string bhyt = _DanhMuc.tonghop_chiphi_bhyt(Media);
                //MessageBox.Show(bhyt);
                if (bhyt == "OK")
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn đã tổng hợp  Bệnh án BHYT thành công", "Thông Báo", MessageBoxButtons.YesNo);
                }                            
                else
                {
                    DialogResult dialogResult = MessageBox.Show(bhyt, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {

               // throw;
                DialogResult dialogResult = MessageBox.Show("Vui lòng nhập số Bệnh án", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
