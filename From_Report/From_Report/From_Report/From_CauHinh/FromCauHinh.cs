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
using NFtest;
namespace From_Report.From_CauHinh
{
    public partial class FromCauHinh : Form
    {
        public static string _key = "29fa797a-d341-4755-af56-8bf5aa6c9e5d";   
        //public static string _key = "ARlKSYpaj6s="; 
        //public static string _key = "123"; 
        public testCDKey e = new testCDKey();
        
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
                                                            new XElement("Pass", this.e.Encrypt(txtPass.Text, _key, true)),
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

        private void btCancel_Click(object sender, EventArgs e)
        {
            txtGiaiMa.Text = this.e.Decrypt(txtMa.Text, _key, true).ToString();           
    
        }
    }
}

