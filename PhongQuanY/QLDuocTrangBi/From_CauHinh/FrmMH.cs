using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UTL;

namespace From_Report.From_CauHinh
{
    public partial class FrmMH : Form
    {
        #region Variable
        public static string _key = "29fa797a-d341-4755-af56-8bf5aa6c9e5d";
        public static string _key1 = "2010-01-01;TRUONG ANH VU;COD-FWG-674-ECF";
       

        #endregion
        public FrmMH()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
           
            try
            {
                txtXuat.Text = UTL.DataBase.Encrypt(txtNhap.Text, _key, true).ToString();
            }
            catch (Exception )
            {

                return; 
            }
        }

        private void btDec_Click(object sender, EventArgs e)
        {
            try
            {
                txtXuat.Text = UTL.DataBase.Decrypt(txtNhap.Text, _key, true).ToString();
            }
            catch (Exception )
            {

                return;
            }
            
           
        }

        private void btOk2_Click(object sender, EventArgs e)
        {
           
            try
            {
                txtXuat2.Text = UTL.DataBase.Encrypt(txtNhap2.Text, _key1, true).ToString();
            }
            catch (Exception)
            {

                return;
            }
        }

        private void btDec2_Click(object sender, EventArgs e)
        {
            
            try
            {
                txtXuat2.Text = UTL.DataBase.Decrypt(txtNhap2.Text, _key1, true).ToString();
            }
            catch (Exception)
            {

                return;
            }
        }
    }
}
