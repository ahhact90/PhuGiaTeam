using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyNhaHang
{
    public partial class frmKhoiTao : Form
    {
        public frmKhoiTao()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            prcLoad.Increment(1);
            if (prcLoad.Value == 100)
            {
                timer1.Stop();
            }
        }
    }
}
