using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace From_Report.From_Dstore
{
    public partial class Frm_Use_Type : Form
    {
        public string Nm;
        public string Passvalue
        {
            get { return Nm; }
            set { Nm = value; }
        }

        #region Variable
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        public static string StrConnect = UTL.DataBase.GetConfig();
        DAL.Mau21BQPKhacDAL _DanhMuc = new DAL.Mau21BQPKhacDAL(StrConnect);
        #endregion

        public Frm_Use_Type()
        {
            InitializeComponent();
        }

    }
}
