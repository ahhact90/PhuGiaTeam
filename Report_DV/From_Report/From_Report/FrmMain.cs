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
        public static string StrConnect = UTL.DataBase.GetConfig();
        DAL.Mau21BQPKhacDAL _DanhMuc = new DAL.Mau21BQPKhacDAL(StrConnect);
       

        #endregion
        public FrmMain()
        {
            InitializeComponent();
            barEditItem_dfrom.EditValue = DateTime.Today; //= DateTime.Today;DateTime.Now
            barEditItem_dto.EditValue = DateTime.Today.AddDays(+1).Date;
           
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
            
            foreach (var x in MdiChildren) if (x is FrmService) return;
            var frm = new FrmService() { MdiParent = this };
            frm.Show();
           
          
        }

        private void barbtnSetting_ItemClick(object sender, ItemClickEventArgs e)
        {
            //From_CauHinh.FromCauHinh fsetting = new From_CauHinh.FromCauHinh();
            //fsetting.Show();
            foreach (var x in MdiChildren) if (x is From_CauHinh.FromCauHinh) return;
            var frm = new From_CauHinh.FromCauHinh() { MdiParent = this };
            frm.Show();

        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            
            foreach (var x in MdiChildren) if (x is From_Dstore.From_Duoc_AnhXa) return;
            var frm = new From_Dstore.From_Duoc_AnhXa() { MdiParent = this };
            frm.Show();

        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (var x in MdiChildren) if (x is From_CauHinh.FrmMH) return;
            var frm = new From_CauHinh.FrmMH() { MdiParent = this };
            frm.Show();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (var x in MdiChildren) if (x is FrmSearch) return;
            var frm = new FrmSearch() { MdiParent = this };
            frm.Show();
        }

        
    }
}