using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace From_Report.Report
{
    public partial class RptM21Khaccs : DevExpress.XtraReports.UI.XtraReport
    {
        public RptM21Khaccs(string dateNgayBD, string dateNgaKT)
        {
            InitializeComponent();
            xrlFrom.Text = dateNgayBD;
            xrlTo.Text = dateNgaKT; 
        }

    }
}
