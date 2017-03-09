using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace From_Report
{
    public partial class FromMain : Form
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
        public FromMain()
        {
            InitializeComponent();
        }
    }
}
