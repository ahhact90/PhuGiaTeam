using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QLDuocTrangBi.From_ChucNang
{
    public partial class Frm_NuocSX : PRE.Catalog.FrmBase
    {
        #region Variable
        public static string StrConnect = UTL.DataBase.GetConfigMySQL();
        DAL.EntitiesDAL.Country_DAL _dal = new DAL.EntitiesDAL.Country_DAL(StrConnect);

        DataTable _dt = new DataTable();
        DataTable _dt2 = new DataTable();
        DataTable _dt3 = new DataTable();

        #endregion

        public Frm_NuocSX()
        {
            InitializeComponent();
        }

        #region Override

        /// <summary>
        /// Perform when click add button
        /// </summary>
        protected override void PerformAdd()
        {

            ReadOnlyControl(false);
            ClearDataBindings();
            ChangeStatus(false);
            //txtMa.Properties.ReadOnly = true;
            base.PerformAdd();

        }

        /// <summary>
        /// Perform when click cancel button
        /// </summary>
        protected override void PerformCancel()
        {
            ChangeStatus();
            PerformRefresh();
            base.PerformCancel();
        }

        /// <summary>
        /// Perform when click delete button
        /// </summary>
        /// <returns></returns>
        protected override void PerformDelete()
        {
            try
            {
                var id1 = gv_NSX.GetFocusedRowCellValue("id") + "";
                DialogResult result;
                result = XtraMessageBox.Show("Bạn có chắc xóa không ? ", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    var ok = _dal.Delete(id1);
                    if (ok)
                    {
                        PerformRefresh();
                    }
                    else
                        XtraMessageBox.Show("Lỗi! Không xóa được", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Vui lòng chọn dữ liệu cần xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            base.PerformDelete();
        }

        /// <summary>
        /// Perform when click edit button
        /// </summary>
        protected override void PerformEdit()
        {
            ReadOnlyControl(false);

            //txtMa.Properties.ReadOnly = true;
            //txtNSX.Properties.ReadOnly = true;           

            base.PerformEdit();
        }

        /// <summary>
        /// Perform when click print button
        /// </summary>
        protected override void PerformPrint()
        {

            base.PerformPrint();
        }

        /// <summary>
        /// Load data or perform when click refresh button
        /// </summary>
        protected override void PerformRefresh()
        {
            ReadOnlyControl();
            LoadData();
            ChangeStatus();
            ResetText();



            if (_dt != null)
            {
                // Binding data
                ClearDataBindings();
                if (_dt.Rows.Count > 0) DataBindingControl();
            }





            base.PerformRefresh();
        }

        /// <summary>
        /// Perform when click save button
        /// </summary>
        protected override void PerformSave()
        {
            if (IsAdd)
            {
                try
                {
                    var o = new DAL.Entities.Country()
                    {

                        //id = Convert.ToInt32(txtMa.Text),
                        country_code = Convert.ToString(txtMa.Text),
                        country_name = Convert.ToString(txtNSX.Text)


                    };

                    var oki = _dal.Insert(o);
                    if (oki)
                    {
                        XtraMessageBox.Show("Đã lưu thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        PerformRefresh();
                        ChangeStatus(false);
                        PerformAdd();
                    }
                    else
                    {
                        XtraMessageBox.Show("Lỗi! Lưu thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ChangeStatus(false);
                        ReadOnlyControl(false);
                    }
                }
                catch (Exception ex)
                {

                    XtraMessageBox.Show("Vui lòng nhập đầy đủ dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            if (IsEdit)
            {
                var id1 = gv_NSX.GetFocusedRowCellValue("id") + "";
                try
                {
                    var o = new DAL.Entities.Country()
                    {                       
                        country_code = Convert.ToString(txtMa.Text),
                        country_name = Convert.ToString(txtNSX.Text)

                    };

                    var oki = _dal.Update(o);

                    if (oki)
                    {
                        XtraMessageBox.Show("Đã lưu thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        PerformRefresh();
                        ChangeStatus();
                    }
                    else
                    {
                        XtraMessageBox.Show("Lỗi! Lưu thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ChangeStatus(false);
                        ReadOnlyControl(false);
                    }
                }
                catch (Exception)
                {

                    XtraMessageBox.Show("Vui lòng nhập đầy đủ dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }


            base.PerformSave();
        }

        /// <summary>
        /// Reset all input control
        /// </summary>
        protected override void ResetText()
        {
            txtMa.ResetText();
            txtNSX.ResetText();
            //txt_SttBienLai.ResetText();
            //cbo_SttPhieuMuon.ResetText();
            //cbo_MaCuonSach.ResetText();
            //txt_TenDauSach.ResetText();
            //txt_LyDo.ResetText();
            //txt_HoTen.ResetText();
            //txt_SoTien.ResetText();
            //dte_NgayLap.ResetText();



            base.ResetText();
        }

        /// <summary>
        /// Clear data binding
        /// </summary>
        protected override void ClearDataBindings()
        {
            //txt_SttBienLai.DataBindings.Clear();
            //cbo_SttPhieuMuon.DataBindings.Clear();
            //cbo_MaCuonSach.DataBindings.Clear();
            //txt_TenDauSach.DataBindings.Clear();
            //txt_LyDo.DataBindings.Clear();
            //txt_HoTen.DataBindings.Clear();
            //txt_SoTien.DataBindings.Clear();
            //dte_NgayLap.DataBindings.Clear();


            base.ClearDataBindings();
        }

        /// <summary>
        /// Add data binding
        /// </summary>
        protected override void DataBindingControl()
        {
            //txtMa.DataBindings.Add("Text", _dt, ".id");
            //txtNSX.DataBindings.Add("Text", _dt, ".unitname");
            //txt_SttBienLai.DataBindings.Add("Text", _dt, ".STT_BLP");
            //cbo_SttPhieuMuon.DataBindings.Add("EditValue", _dt, "STT_PM");
            //cbo_MaCuonSach.DataBindings.Add("EditValue", _dt, ".MACUONSACH");
            //txt_TenDauSach.DataBindings.Add("Text", _dt, "TENDAUSACH");
            //txt_LyDo.DataBindings.Add("Text", _dt, ".LYDOPHAT");
            //txt_HoTen.DataBindings.Add("Text", _dt, "HOVATEN");
            //txt_SoTien.DataBindings.Add("Text", _dt, ".SOTIENPHAT");
            //dte_NgayLap.DataBindings.Add("Text", _dt, ".NGAYPHAT");

            base.DataBindingControl();
        }

        /// <summary>
        /// Set read only control on form
        /// </summary>
        /// <param name="isReadOnly">Read only is trule else normal</param>
        protected override void ReadOnlyControl(bool isReadOnly = true)
        {

            txtMa.Properties.ReadOnly = isReadOnly;
            txtNSX.Properties.ReadOnly = isReadOnly;


            base.ReadOnlyControl(isReadOnly);
        }

        protected override void PerformSearch()
        {


            base.PerformSearch();
        }


        /// <summary>
        /// Update object
        /// </summary>
        /// <returns>True if successful else false</returns>
        protected override bool UpdateObject()
        {
            return base.UpdateObject();
        }

        /// <summary>
        /// Insert object
        /// </summary>
        /// <returns>True if successful else false</returns>
        protected override bool InsertObject()
        {
            return base.InsertObject();
        }

        /// <summary>
        /// Load data
        /// </summary>
        protected override void LoadData()
        {
            _dt = _dal.Select();
            //_dt2 = _dal2.Select();
            //_dt3 = _dal3.Select();
            //cbo_MaCuonSach.Properties.DataSource = _dt2;
            //cbo_SttPhieuMuon.Properties.DataSource = _dt3;           

            try
            {
                if (_dt != null)
                {
                    gc_NSX.DataSource = _dt;
                    gv_NSX.OptionsBehavior.ReadOnly = true;
                    gv_NSX.OptionsView.ColumnAutoWidth = true;
                    //gv_NSX.Columns[0].Visible = false;
                    gv_NSX.Columns[0].Caption = "ID";
                    gv_NSX.Columns[1].Caption = "Mã Nước";
                    gv_NSX.Columns[2].Caption = "Tên Nước";
                    gv_NSX.BestFitColumns();
                }

                base.LoadData();
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Lỗi! Không load được dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
       
        #endregion

        private void gv_NSX_Click(object sender, EventArgs e)
        {
            txtMa.Text = gv_NSX.GetFocusedRowCellValue("country_code").ToString();
            txtNSX.Text = gv_NSX.GetFocusedRowCellValue("country_name").ToString();  
        }
        
    }
}
