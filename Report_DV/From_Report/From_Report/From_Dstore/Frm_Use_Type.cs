using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;

namespace From_Report.From_Dstore
{
    public partial class Frm_Use_Type : Form
    {
        public static string a;       
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

        private void Frm_Use_Type_Load(object sender, EventArgs e)
        {
            dt = _DanhMuc.Duongdung();
            gridControl_Use_Type.DataSource = dt;

        }

        private void gridControl_Use_Type_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
               // Application.Exit();
            }
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            if (e.RowHandle % 2 == 0)
            {                
                e.Appearance.ForeColor = Color.MediumBlue;
            }
            else
            {                
                e.Appearance.ForeColor = Color.Firebrick;
            }
        }

        //private void gridView1_RowClick(object sender, RowClickEventArgs e)
        //{

        //}

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string cellValue;
                cellValue = gridView1.GetFocusedRowCellValue("name").ToString();               
                a = cellValue;
                Passvalue = cellValue;
                this.Hide();
            }
        }

    }
}
