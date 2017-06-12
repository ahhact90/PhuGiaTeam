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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_Click(object sender, EventArgs e)
        {
            txtDrugName.Text = gridView1.GetFocusedRowCellValue("drug_name").ToString();
            txtUsing.Text = gridView1.GetFocusedRowCellValue("usingdrugid").ToString();
            txtDrug.Text = gridView1.GetFocusedDataRow()["drug_id"].ToString();
            txtCompont.Text = gridView1.GetFocusedDataRow()["component"].ToString();
            txtContent.Text = gridView1.GetFocusedDataRow()["content_name"].ToString();
            txtUnit.Text = gridView1.GetFocusedDataRow()["unit_name"].ToString();
            txtMaBV.Text = gridView1.GetFocusedDataRow()["MA_BV"].ToString();
            txtMaAX.Text = gridView1.GetFocusedDataRow()["Ma_AX"].ToString();
            txtUseType.Text = gridView1.GetFocusedDataRow()["use_type_id"].ToString();
            txtStock.Text = gridView1.GetFocusedDataRow()["stockid"].ToString();
            txtSoPhieu.Text = gridView1.GetFocusedDataRow()["mainimexid"].ToString();
            txtCreatdate.Text = gridView1.GetFocusedDataRow()["creationdate_drug"].ToString();
            txtGroup.Text = gridView1.GetFocusedDataRow()["service_type_id"].ToString();
            //textBox1.Text = gridView1.GetDataRow(e.FocusedRowHandle)["Name"].ToString();
            //textBox1.Text = gridView1.GetFocusedDataRow()["Name"].ToString();
            //textBox1.Text = (gridView1.GetFocusedRow() as DataRowView).Row["drug_name"].ToString();
            //textBox1.Text = gridView1.GetFocusedRowCellValue("Name").ToString();
            //txtDrugName.Text = (gridView1.GetFocusedRow() as DataRowView).Row["drug_name"].ToString();
            
            txtDrugName.Enabled = false;
            txtUsing.Enabled = false;
            txtDrug.Enabled = false;
            txtCompont.Enabled = false;
            txtContent.Enabled = false;
            txtUnit.Enabled = false;
            txtMaBV.Enabled = false;
            txtMaAX.Enabled = false;
            txtUseType.Enabled = false;
            txtStock.Enabled = false;
            txtSoPhieu.Enabled = false;
            txtCreatdate.Enabled = false;
            txtGroup.Enabled = false;
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {

        }

        private void gridView1_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;            
            if (e.RowHandle % 2 == 0 )
            {
                
                e.Appearance.BackColor = Color.WhiteSmoke;
                e.Appearance.ForeColor = Color.Green;
                e.HighPriority = true;
                
            }
            else
            {
               
                e.Appearance.BackColor = Color.SeaShell;
                e.Appearance.ForeColor = Color.IndianRed;
                e.HighPriority = true;
            }
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
           

        }

        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            txtDrugName.Text = gridView1.GetFocusedRowCellValue("drug_name").ToString();
            txtUsing.Text = gridView1.GetFocusedRowCellValue("usingdrugid").ToString();
            txtDrug.Text = gridView1.GetFocusedDataRow()["drug_id"].ToString();
            txtCompont.Text = gridView1.GetFocusedDataRow()["component"].ToString();
            txtContent.Text = gridView1.GetFocusedDataRow()["content_name"].ToString();
            txtUnit.Text = gridView1.GetFocusedDataRow()["unit_name"].ToString();
            txtMaBV.Text = gridView1.GetFocusedDataRow()["MA_BV"].ToString();
            txtMaAX.Text = gridView1.GetFocusedDataRow()["Ma_AX"].ToString();
            txtUseType.Text = gridView1.GetFocusedDataRow()["use_type_id"].ToString();
            txtStock.Text = gridView1.GetFocusedDataRow()["stockid"].ToString();
            txtSoPhieu.Text = gridView1.GetFocusedDataRow()["mainimexid"].ToString();
            txtCreatdate.Text = gridView1.GetFocusedDataRow()["creationdate_drug"].ToString();
            txtGroup.Text = gridView1.GetFocusedDataRow()["service_type_id"].ToString();
        }

        private void sửaChiTiêtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMaBV.Enabled = true;
            txtMaAX.Enabled = true;
            txtUseType.Enabled = true;
            txtDrugName.Enabled = true;
        }

        private void From_Duoc_AnhXa_KeyDown(object sender, KeyEventArgs e)
        {
            

               

            
            
        }

        private void txtMaAX_KeyDown(object sender, KeyEventArgs e)
        {          

        }

        private void btSave_Click(object sender, EventArgs e)
        { 
            if (txtMaBV.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mã bệnh viện");
            }
            else
            {
                if (txtMaAX.Text.Length == 0)
                {
                     MessageBox.Show("Vui lòng nhập mã ánh xạ trên công thông tin BHYT");
                }
                else
                {
                    try
                    {
                        string tmp_bv = txtMaBV.Text.ToString();
                        string ax_tmp = txtMaAX.Text.ToString();
                        string text = tmp_bv + '|' + ax_tmp;
                        Int32 mDrug = Int32.Parse(txtDrug.Text.ToString());
                        _DanhMuc.Update_AX(text, 1, mDrug);
                        MessageBox.Show("Cập nhật thành công");
                        From_Duoc_AnhXa_Load(sender,e);
                    }
                    catch (Exception) 
                    {
                        DialogResult dialogResult = MessageBox.Show("Cập nhật không thành công", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    };
                    
                }
            }
        }

        private void dockPanel1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode.Equals(Keys.S))//= Ctrl + S
                {
                    From_Duoc_AnhXa_Load(sender, e);
                }
            }
        }          
       
    }
}
