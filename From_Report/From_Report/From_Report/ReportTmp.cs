using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace From_Report
{
    public partial class ReportTmp :  DevExpress.XtraEditors.XtraForm
    {
        #region Variable
        /// <summary>
        /// Biến chung
        /// </summary>
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        /// <summary>
        /// Biến truyền vào Mẫu 21 Khác
        /// </summary>
        DAL.Mau21BQPKhacDAL _M21Khac = new DAL.Mau21BQPKhacDAL();

        #endregion
        public ReportTmp()
        {
            InitializeComponent();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            DateTime FromDate = Convert.ToDateTime(dte_To.DateTime);
            DateTime ToDate = Convert.ToDateTime(dte_From.DateTime);
            dt = _M21Khac.Select_QN_NgTru(FromDate, ToDate);
            gridControl1.DataSource = dt;
        }

        private void btExport_Click(object sender, EventArgs e)
        {
            //this.gridView1.ExportToXlsx("CV3360.xlsx");           

            using (SaveFileDialog sfd = new SaveFileDialog() /*{ Filter = "Excel Workbook|*.xlsx" }*/)
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string path = sfd.FileName.ToString(); /*+ "(" + DateTime.Now.ToString("yyyy-MM-dd") + ")";*/
                    MessageBox.Show(path);
                    string filename_with_ext = Path.GetFileNameWithoutExtension(path); 
                    FileInfo fi = new FileInfo(path);
                    string text = fi.Name;

                    gridView1.ExportToXlsx(text);
                   // Thread thread = new Thread(() =>
                   //{
                   //    string path = sfd.FileName.ToString(); /*+ "(" + DateTime.Now.ToString("yyyy-MM-dd") + ")";*/
                   //    MessageBox.Show(path);                       
                   //    //FileInfo fi = new FileInfo(path);
                   //    //string text = fi.Name;
                   //    //MessageBox.Show(text);                      
                      
                   //}
                   //);
                   // thread.Start();
                }

            }

        }


    }
}
