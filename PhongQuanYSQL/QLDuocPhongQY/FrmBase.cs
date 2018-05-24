using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PRE.Catalog
{
    public partial class FrmBase : DevExpress.XtraEditors.XtraForm
    {
        #region Variable
        protected DataTable _dtb = new DataTable("Tmp");
        protected bool IsAdd { set; get; }
        protected bool IsEdit { set; get; }
        #endregion

        #region Function
        public FrmBase()
        {
            InitializeComponent();
        }

        protected void ChangeStatus(bool Istrue = true)
        {
            btnAdd.Enabled = Istrue;
            btnEdit.Enabled = Istrue;
            btnDelete.Enabled = Istrue;
            btnPrint.Enabled = Istrue;
            btnSave.Enabled = !Istrue;
            btnCancel.Enabled = !Istrue;

            btnSearch.Enabled = Istrue;
            
        }

        protected void ChangeStatus_HD(bool Istrue = true)
        {
            btnAdd.Enabled = Istrue;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;

            btnSave.Enabled = !Istrue;
            btnCancel.Enabled = !Istrue;

            btnSearch.Enabled = Istrue;

        }

        /// <summary>
        /// Kí tự đầu tiên viết hoa
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string Proper(string name)
        {
            string s = name.Trim();
            string result = "";

            string tmp = ""; if (s != "") tmp = s.Substring(0, 1);
            result += tmp.ToUpper();
            for (int i = 1; i < s.Length; i++)
            {
                if ((s[i - 1].ToString() == " ") && (s[i].ToString() != " "))
                {
                    string ss = s[i].ToString();
                    result += ss.ToUpper();
                }
                else
                {
                    string ss = s[i].ToString();
                    result += ss.ToLower();

                }
            }

            return result;
        }

        private void barMain_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "btnAdd":
                    ChangeStatus(false);
                    ResetText();
                    btnAdd.Border = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
                    ClearDataBindings();
                    ReadOnlyControl(false);

                    IsAdd = true;
                    IsEdit = false;

                    PerformAdd();
                    break;

                case "btnEdit":
                    ChangeStatus(false);
                    ReadOnlyControl(false);
                    btnEdit.Border = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
                    IsAdd = false;
                    IsEdit = true;

                    PerformEdit();
                    break;

                case "btnDelete":
                    PerformDelete();
                    btnDelete.Border = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
                    break;

                case "btnSave":
                    btnSave.Border = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
                    if (IsEdit || IsAdd)
                    {
                        ChangeStatus();
                        ReadOnlyControl();
                    }

                    PerformSave();
                    break;

                case "btnCancel":
                    btnSave.Border = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
                    ChangeStatus();
                    ReadOnlyControl();

                    PerformCancel();
                    break;

                case "btnSearch":
                    btnSearch.Border = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
                    PerformSearch();
                    break;

                case "btnRefresh":
                    btnRefresh.Border = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
                    PerformRefresh();
                    break;

                case "btnPrint":
                    PerformPrint();
                    break;

                case "btnClose":
                    btnClose.Border = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
                    Close();
                    break;

                default:
                    break;

            }
        }

        private void FrmBase_Load(object sender, EventArgs e)
        {
            ReadOnlyControl();
            PerformRefresh();
        }

        #endregion

        #region Virtual

        /// <summary>
        /// Perform when click add button
        /// </summary>
        protected virtual void PerformAdd() { }

        /// <summary>
        /// Perform when click edit button
        /// </summary>
        protected virtual void PerformEdit() { }

        /// <summary>
        /// Perform when click delete button
        /// </summary>
        protected virtual void PerformDelete() { }

        /// <summary>
        /// Perform when click save button
        /// </summary>
        protected virtual void PerformSave() { }

        /// <summary>
        /// Perform when click cancel button
        /// </summary>
        protected virtual void PerformCancel() { }

        /// <summary>
        /// Load data or perform when click refresh button
        /// </summary>
        protected virtual void PerformRefresh() 
        {
            btnAdd.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            btnEdit.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            btnSave.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            btnDelete.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            btnRefresh.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            btnCancel.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            btnSearch.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            btnClose.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            
        }

        /// <summary>
        /// Perform when click find button
        /// </summary>
        protected virtual void PerformSearch() { }

        /// <summary>
        /// Perform when click print button
        /// </summary>
        protected virtual void PerformPrint() { }

        /// <summary>
        /// Reset all input control
        /// </summary>
        protected new virtual void ResetText() { }

        /// <summary>
        /// Clear data binding
        /// </summary>
        protected virtual void ClearDataBindings() { }

        /// <summary>
        /// Add data binding
        /// </summary>
        protected virtual void DataBindingControl() { }

        /// <summary>
        /// Set read only control on form
        /// </summary>
        /// <param name="isReadOnly">Read only is trule else normal</param>
        protected virtual void ReadOnlyControl(bool isReadOnly = true) { }

        /// <summary>
        /// Set visibility control on form
        /// </summary>
        /// <param name="isVisit">Visibility is trule else normal</param>
        protected virtual void VisibilityControl(bool isVisit = false) { }

        /// <summary>
        /// Update object
        /// </summary>
        /// <returns>True if successful else false</returns>
        protected virtual bool UpdateObject() { return true; }

        /// <summary>
        /// Delete object
        /// </summary>
        /// <returns>True if successful else false</returns>
        protected virtual bool InsertObject() { return true; }

        /// <summary>
        /// Load data
        /// </summary>
        protected virtual void LoadData() { }

        #endregion

    }
}