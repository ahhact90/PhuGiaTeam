using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.Design.GroupSort;
using DevExpress.XtraReports.UI;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.BandedGrid;
using System.Threading;
using System.IO;

namespace From_Report
{
    public partial class FrmService : Form
    {
        #region Variable

        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        public static string StrConnect = UTL.DataBase.GetConfig();
        DAL.Mau21BQPKhacDAL _DanhMuc = new DAL.Mau21BQPKhacDAL(StrConnect);


        #endregion
        public FrmService()
        {
            InitializeComponent();           
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void FrmService_Load(object sender, EventArgs e)
        {

        }

     
    }
}
