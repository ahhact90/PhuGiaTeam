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
        public static string string1 = "server = localhost; port = 5432; user id = postgres; password = P@$121# ; Database = HMIS";
        DAL.Mau21BQPKhacDAL _DanhMuc = new DAL.Mau21BQPKhacDAL(string1);


        #endregion
        public FrmService()
        {
            InitializeComponent();           
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            //// Ham xuat Excel Bang Dev Nhanh
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010-2013-2016) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html|All File (.*)|*.*";
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
                            MessageBox.Show("Xuất dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnOk_Click(object sender, EventArgs e)
        {
            dt = _DanhMuc.Select_DMKT();

            grdCtrlDM.DataSource = dt;
        }
    }
}
