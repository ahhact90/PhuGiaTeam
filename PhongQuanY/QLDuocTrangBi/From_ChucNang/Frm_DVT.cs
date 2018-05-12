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
        public Frm_DVT()
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
            



            base.PerformRefresh();
        }

        /// <summary>
        /// Perform when click save button
        /// </summary>
        protected override void PerformSave()
        {
            

            base.PerformSave();
        }

        /// <summary>
        /// Reset all input control
        /// </summary>
        protected override void ResetText()
        {
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

            //txt_SttBienLai.Properties.ReadOnly = isReadOnly;
            //txt_LyDo.Properties.ReadOnly = isReadOnly;
            //txt_SoTien.Properties.ReadOnly = isReadOnly;
            //txt_HoTen.Properties.ReadOnly = isReadOnly;
            //dte_NgayLap.Properties.ReadOnly = isReadOnly;
            //cbo_SttPhieuMuon.Properties.ReadOnly = isReadOnly;
            //cbo_MaCuonSach.Properties.ReadOnly = isReadOnly;
            //txt_TenDauSach.Properties.ReadOnly = isReadOnly;
            //gridControl_BienLaiPhat.Enabled = isReadOnly;

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
            //_dt = _dal.Select();
            //_dt2 = _dal2.Select();
            //_dt3 = _dal3.Select();
            //cbo_MaCuonSach.Properties.DataSource = _dt2;
            //cbo_SttPhieuMuon.Properties.DataSource = _dt3;

            try
            {
                //if (_dt != null)
                //{
                //    gridControl_BienLaiPhat.DataSource = _dt;

                //    gridView_BienLaiPhat.OptionsBehavior.ReadOnly = true;
                //    gridView_BienLaiPhat.OptionsView.ColumnAutoWidth = true;
                //}

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
