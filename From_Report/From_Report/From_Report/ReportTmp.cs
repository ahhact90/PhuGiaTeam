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
    public partial class ReportTmp : DevExpress.XtraBars.Ribbon.RibbonForm
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
           
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;
                    //MessageBox.Show(exportFilePath);
                    
                    switch (fileExtenstion)
                    {
                        case ".xls":
                            gridView1.ExportToXls(exportFilePath);
                            break;
                        case ".xlsx":
                            gridView1.ExportToXlsx(exportFilePath);
                            break;
                        case ".rtf":
                            gridView1.ExportToRtf(exportFilePath);
                            break;
                        case ".pdf":
                            gridView1.ExportToPdf(exportFilePath);
                            break;
                        case ".html":
                            gridView1.ExportToHtml(exportFilePath);
                            break;
                        case ".mht":
                            gridView1.ExportToMht(exportFilePath);
                            break;
                        default:
                            break;
                    }

                    if (File.Exists(exportFilePath))
                    {
                        try
                        {
                            //Try to open the file and let windows decide how to open it.
                            System.Diagnostics.Process.Start(exportFilePath);
                        }
                        catch
                        {
                            String msg = "The file could not be opened." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        String msg = "The file could not be saved." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                        MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }


    }
}
