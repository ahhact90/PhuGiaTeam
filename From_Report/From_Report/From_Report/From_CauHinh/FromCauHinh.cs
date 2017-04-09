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

namespace From_Report.From_CauHinh
{
    public partial class FromCauHinh : Form
    {
        public FromCauHinh()
        {
            InitializeComponent();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            XDocument doc = new XDocument(new XElement("ROWSET",
                                                        new XElement("ROW",
                                                            new XElement("Host", "Host"),
                                                            new XElement("Pass", "Pass"),
                                                            new XElement("Port", "Port"),
                                                            new XElement("UID", "UID"),
                                                            new XElement("Server", "Server")
                                                                    )
                                                       )
                                          );
            doc.Save("E:\\document.xml");
        }
    }
}

