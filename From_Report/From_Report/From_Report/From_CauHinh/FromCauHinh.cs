using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using UTL;
namespace From_Report.From_CauHinh
{
    public partial class FromCauHinh : Form
    {
        public static string _key = "MAITHY";
        public FromCauHinh()
        {
            InitializeComponent();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
                       
            XDocument doc = new XDocument(new XElement("ROWSET",
                                                        new XElement("ROW",
                                                            new XElement("Host", txtHost.Text),
                                                            new XElement("Pass", FunctionHelper.Encrypt(_key, txtPass.Text)),
                                                            new XElement("Port", txtPort.Text),
                                                            new XElement("UID", txtUid.Text),
                                                            new XElement("Server", txtServer.Text.ToString())
                                                                    )
                                                       )
                                          );
            string path = string.Format(@"{0}\Config.xml", folderBrowserDialog.SelectedPath);
            doc.Save(path);
          
            if (folderBrowserDialog.SelectedPath != string.Empty)
            {
                MessageBox.Show("Lưu File Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

