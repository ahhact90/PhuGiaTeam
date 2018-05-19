using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;


namespace GeneralCode
{
    public partial class General : Form
    {
        #region Variable

        private List<Column> colName;

        private IContainer components = null;

        private RichTextBox richTextBox1;

        private ContextMenuStrip contextMenuStrip1;

        private ToolStripMenuItem copyAllToolStripMenuItem;

        #endregion
        #region Popertion
        public string tbName
        {
            get;
            set;
        }
        #endregion
       


        public General()
        {
            InitializeComponent();
        }
    }
}
