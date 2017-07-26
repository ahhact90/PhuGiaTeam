using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace From_Report.From_CV3360
{
    public partial class CV3360_CT : Form
    {
        public CV3360_CT()
        {
            InitializeComponent();
            tdFrom.Time = DateTime.Today.AddDays(+1).Date;
            tdTo.Time = DateTime.Today;
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {

        }
       
    }
}
