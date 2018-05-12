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
    public partial class Frm_DVT : PRE.Catalog.FrmBase
    {
        #region Variable
        public static string StrConnect = UTL.DataBase.GetConfig();
        DAL.EntitiesDAL.Drug_Unit_DAL _dal = new DAL.EntitiesDAL.Drug_Unit_DAL(StrConnect);       

        DataTable _dt = new DataTable();
        DataTable _dt2 = new DataTable();
        DataTable _dt3 = new DataTable();

        #endregion

        public Frm_DVT()
        {
            InitializeComponent();
            
        }

        private void Frm_DVT_Load(object sender, EventArgs e)
        {
            PerformRefresh();
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
            

            base.PerformDelete();
        }

        /// <summary>
        /// Perform when click edit button
        /// </summary>
        protected override void PerformEdit()
        {
            ReadOnlyControl(false);           
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

                var o = new DAL.Entities.Drug_Unit()
                {

                    id = Convert.ToInt32(txtDvt.Text),                    
                    unitname = Convert.ToString(txtTenDVT.Text)


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

            if (IsEdit)
            {
                var id1 = gv_data.GetFocusedRowCellValue("id") + "";


                var o = new DAL.Entities.Drug_Unit()
                {
                    id = Convert.ToInt32(txtDvt.Text),
                    unitname = Convert.ToString(txtTenDVT.Text)

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


            base.PerformSave();
        }

        /// <summary>
        /// Reset all input control
        /// </summary>
        protected override void ResetText()
        {
            txtDvt.ResetText();
            txtTenDVT.ResetText();
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

            txtDvt.Properties.ReadOnly = isReadOnly;
            txtTenDVT.Properties.ReadOnly = isReadOnly;
            

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
                    grc_data.DataSource = _dt;

                    gv_data.OptionsBehavior.ReadOnly = true;
                    gv_data.OptionsView.ColumnAutoWidth = true;
                }

                base.LoadData();
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Lỗi! Không load được dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #endregion

       
    }
}
