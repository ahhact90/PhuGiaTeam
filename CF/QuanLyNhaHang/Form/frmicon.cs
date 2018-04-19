using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LQ_NhaHang___Karaoke
{
    public partial class frmThemAnh : Form
    {

        public frmThemAnh()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {

            OpenFileDialog path = new OpenFileDialog();
            path.Filter = path.Filter = "File ảnh(*.png)|*.png|All File (*.*)|*.*";
            path.FilterIndex = 0;
            path.RestoreDirectory = true;
            if (path.ShowDialog() == DialogResult.OK)
            {
                pibHinhanh.ImageLocation = path.FileName;
                txtPath.Text = path.FileName;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
           
        }

        private void frmThemAnh_Load(object sender, EventArgs e)
        {

        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
