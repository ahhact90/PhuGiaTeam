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
    public partial class From_Duoc_AnhXa : Form
    {
        #region Variable
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        public static string StrConnect = UTL.DataBase.GetConfig();
        DAL.Mau21BQPKhacDAL _DanhMuc = new DAL.Mau21BQPKhacDAL(StrConnect);
        #endregion

        public From_Duoc_AnhXa()
        {
            InitializeComponent();
        }

        private void From_Duoc_AnhXa_Load(object sender, EventArgs e)
        {
            dt = _DanhMuc.Select_Thuoc_AX();
            grdCtrlThuocAX.DataSource = dt;
        }

    }
}
