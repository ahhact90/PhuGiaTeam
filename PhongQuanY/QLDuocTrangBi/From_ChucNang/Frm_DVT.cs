using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
            DataTable _ma = _dal.Select_Max();

            if (_ma != null)
                if (_ma.Rows.Count > 0)
                {
                    string ma = _bll.AddID(_ma.Rows[0]["Ma"] + "");
                    txt_SttBienLai.Text = ma;

                    ReadOnlyControl(false);
                    ClearDataBindings();
                    ChangeStatus(false);


                    cbo_MaCuonSach.ResetText();


                    txt_SttBienLai.Properties.ReadOnly = true;
                    txt_TenDauSach.Properties.ReadOnly = true;
                    txt_HoTen.Properties.ReadOnly = true;

                }
            cbo_MaCuonSach.Properties.DataSource = _dt2;
            dte_NgayLap.EditValue = DateTime.Now;

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
            var id1 = gridView_BienLaiPhat.GetFocusedRowCellValue("STT_BLP") + "";

            DialogResult result;
            var ok = _dal.Delete(id1);
            result = XtraMessageBox.Show("Bạn có chắc xóa không ? ", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                if (ok)
                {
                    PerformRefresh();
                }
                else
                    XtraMessageBox.Show("Lỗi! Không xóa được", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            base.PerformDelete();
        }

        /// <summary>
        /// Perform when click edit button
        /// </summary>
        protected override void PerformEdit()
        {
            ReadOnlyControl(false);
            txt_SttBienLai.Properties.ReadOnly = true;
            txt_TenDauSach.Properties.ReadOnly = true;
            txt_HoTen.Properties.ReadOnly = true;
            base.PerformEdit();
        }

        /// <summary>
        /// Perform when click print button
        /// </summary>
        protected override void PerformPrint()
        {
            try
            {

                var o = new DAL.Entities.BienLaiPhat()
                {
                    STT_BLP = Convert.ToString(txt_SttBienLai.Text),
                };
                DataTable _tbPrint = new DataTable();

                int _tongTienPhat = 0;
                string _NgayKy = "TP.Cần Thơ, ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
                _tbPrint = _dal.Select_BienLaiPhat(o);


                foreach (DataRow dr in _tbPrint.Rows)
                {
                    _tongTienPhat += Convert.ToInt32(dr["SOTIENPHAT"].ToString());
                }

                string _ketQua = UTL.Currency.ToString(_tongTienPhat);

                Reports.FrmReportView frm = new Reports.FrmReportView();
                frm._load_XtraBienLaiPhat(_tbPrint, _ketQua, _NgayKy);
                frm.Show();
            }
            catch { }
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


            btnGoSearch.Visible = false;

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

                var o = new DAL.Entities.BienLaiPhat()
                {
                    STT_BLP = Convert.ToString(txt_SttBienLai.Text),
                    LYDOPHAT = Convert.ToString(txt_LyDo.Text),
                    SOTIENPHAT = Convert.ToInt32(txt_SoTien.Text),
                    NGAYPHAT = Convert.ToDateTime(dte_NgayLap.Text),
                    MACUONSACH = Convert.ToString(cbo_MaCuonSach.EditValue),
                    STT_PM = Convert.ToString(cbo_SttPhieuMuon.EditValue)


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
                var id1 = gridView_BienLaiPhat.GetFocusedRowCellValue("STT_BLP") + "";


                var o = new DAL.Entities.BienLaiPhat()
                {
                    STT_BLP = Convert.ToString(txt_SttBienLai.Text),
                    LYDOPHAT = Convert.ToString(txt_LyDo.Text),
                    SOTIENPHAT = Convert.ToInt32(txt_SoTien.Text),
                    NGAYPHAT = Convert.ToDateTime(dte_NgayLap.Text),
                    MACUONSACH = Convert.ToString(cbo_MaCuonSach.EditValue),
                    STT_PM = Convert.ToString(cbo_SttPhieuMuon.EditValue)

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
            txt_SttBienLai.ResetText();
            cbo_SttPhieuMuon.ResetText();
            cbo_MaCuonSach.ResetText();
            txt_TenDauSach.ResetText();
            txt_LyDo.ResetText();
            txt_HoTen.ResetText();
            txt_SoTien.ResetText();
            dte_NgayLap.ResetText();



            base.ResetText();
        }

        /// <summary>
        /// Clear data binding
        /// </summary>
        protected override void ClearDataBindings()
        {
            txt_SttBienLai.DataBindings.Clear();
            cbo_SttPhieuMuon.DataBindings.Clear();
            cbo_MaCuonSach.DataBindings.Clear();
            txt_TenDauSach.DataBindings.Clear();
            txt_LyDo.DataBindings.Clear();
            txt_HoTen.DataBindings.Clear();
            txt_SoTien.DataBindings.Clear();
            dte_NgayLap.DataBindings.Clear();


            base.ClearDataBindings();
        }

        /// <summary>
        /// Add data binding
        /// </summary>
        protected override void DataBindingControl()
        {

            txt_SttBienLai.DataBindings.Add("Text", _dt, ".STT_BLP");
            cbo_SttPhieuMuon.DataBindings.Add("EditValue", _dt, "STT_PM");
            cbo_MaCuonSach.DataBindings.Add("EditValue", _dt, ".MACUONSACH");
            txt_TenDauSach.DataBindings.Add("Text", _dt, "TENDAUSACH");
            txt_LyDo.DataBindings.Add("Text", _dt, ".LYDOPHAT");
            txt_HoTen.DataBindings.Add("Text", _dt, "HOVATEN");
            txt_SoTien.DataBindings.Add("Text", _dt, ".SOTIENPHAT");
            dte_NgayLap.DataBindings.Add("Text", _dt, ".NGAYPHAT");

            base.DataBindingControl();
        }

        /// <summary>
        /// Set read only control on form
        /// </summary>
        /// <param name="isReadOnly">Read only is trule else normal</param>
        protected override void ReadOnlyControl(bool isReadOnly = true)
        {

            txt_SttBienLai.Properties.ReadOnly = isReadOnly;
            txt_LyDo.Properties.ReadOnly = isReadOnly;
            txt_SoTien.Properties.ReadOnly = isReadOnly;
            txt_HoTen.Properties.ReadOnly = isReadOnly;
            dte_NgayLap.Properties.ReadOnly = isReadOnly;
            cbo_SttPhieuMuon.Properties.ReadOnly = isReadOnly;
            cbo_MaCuonSach.Properties.ReadOnly = isReadOnly;
            txt_TenDauSach.Properties.ReadOnly = isReadOnly;
            gridControl_BienLaiPhat.Enabled = isReadOnly;

            base.ReadOnlyControl(isReadOnly);
        }

        protected override void PerformSearch()
        {
            ChangeStatus(false);
            ReadOnlyControl(false);
            txt_HoTen.Properties.ReadOnly = true;
            txt_TenDauSach.Properties.ReadOnly = true;

            ResetText();

            btnGoSearch.Visible = true;

            gridControl_BienLaiPhat.Enabled = true;

            base.PerformSearch();
        }

        /// <summary>
        /// Execute Search data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnGoSearch_Click_1(object sender, EventArgs e)
        {
            try
            {
                var o = new DAL.Entities.BienLaiPhat()
                {
                    STT_BLP = Convert.ToString(txt_SttBienLai.Text),
                    // LYDOPHAT = Convert.ToString(txt_LyDo.Text),
                    //SOTIENPHAT = Convert.ToInt32(txt_SoTien.Text),
                    // NGAYPHAT = Convert.ToDateTime(dte_NgayLap.EditValue),
                    MACUONSACH = Convert.ToString(cbo_MaCuonSach.EditValue),
                    STT_PM = Convert.ToString(cbo_SttPhieuMuon.EditValue)

                };

                gridControl_BienLaiPhat.DataSource = _dal.Search(o);
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Lỗi! Không tìm thấy được dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
            _dt2 = _dal2.Select();
            _dt3 = _dal3.Select();
            cbo_MaCuonSach.Properties.DataSource = _dt2;
            cbo_SttPhieuMuon.Properties.DataSource = _dt3;

            try
            {
                if (_dt != null)
                {
                    gridControl_BienLaiPhat.DataSource = _dt;

                    gridView_BienLaiPhat.OptionsBehavior.ReadOnly = true;
                    gridView_BienLaiPhat.OptionsView.ColumnAutoWidth = true;
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
