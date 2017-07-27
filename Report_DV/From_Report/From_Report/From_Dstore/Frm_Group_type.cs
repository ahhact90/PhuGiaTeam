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
    public partial class Frm_Group_type : Form
    {
        
        #region Variable
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        public static string StrConnect = UTL.DataBase.GetConfig();
        DAL.Mau21BQPKhacDAL _DanhMuc = new DAL.Mau21BQPKhacDAL(StrConnect);   
        #endregion
        public static string a;
        public static string b; 
        private string Passvalue;
        public string Passvalue1
        {
          get { return Passvalue; }
          set { Passvalue = value; }
        }
        private string PassId;
        public string PassId1
        {
          get { return PassId; }
          set { PassId = value; }
        }
        
        public Frm_Group_type()
        {
            InitializeComponent();
        }

        private void Frm_Group_type_Load(object sender, EventArgs e)
        {
            dt = _DanhMuc.MaNhom();
            gridControl_Group_Type.DataSource = dt;

        }

        private void gridControl_Group_Type_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();               
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

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string cellValue;
                string cellId;
                cellValue = gridView1.GetFocusedRowCellValue("name").ToString();
                cellId = gridView1.GetFocusedRowCellValue("line").ToString();
                a = cellValue;
                Passvalue1 = cellValue;
                b = cellId;
                PassId1 = cellId;
                this.Close();
            }

        }
       
    }
}



