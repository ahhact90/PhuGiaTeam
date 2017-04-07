using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.Design.GroupSort;
using DevExpress.XtraReports.UI;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraBars;

namespace From_Report
{
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Variable
       
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        DAL.Mau21BQPKhacDAL _DanhMuc = new DAL.Mau21BQPKhacDAL();
       

        #endregion
        public FrmMain()
        {
            InitializeComponent();
        }

        private void barBtIt_ItemClick(object sender, ItemClickEventArgs e)
        {
            ds = _DanhMuc.Select_non();
            if (ds == null)
            {
                MessageBox.Show("Dữ liệu rỗng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
            }
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            Report.Rpt_DS_TT_PT fDichVu = new Report.Rpt_DS_TT_PT();
            fDichVu.DataSource = ds;
            fDichVu.DataMember = ds.Tables[0].TableName;
            fDichVu.ShowPreview();
        }

        private void barBHYT_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmBHYT fbhyt = new FrmBHYT();
            fbhyt.Show();
        }

        
    }
}