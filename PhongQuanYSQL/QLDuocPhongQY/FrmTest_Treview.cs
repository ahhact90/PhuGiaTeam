using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList.Columns;

namespace QLDuocPhongQY
{
    public partial class FrmTest_Treview : PRE.Catalog.FrmBase
    {
        public FrmTest_Treview()
        {
            InitializeComponent();
        }


        private void CreateColumns(TreeList tl)
        {
            RepositoryItemCheckEdit edit;
            edit = treeList1.RepositoryItems.Add("CheckEdit") as RepositoryItemCheckEdit;
            tl.BeginUpdate();
            TreeListColumn column = treeList1.Columns.Add();
            column.FieldName = "rolename";
            column.Caption = "Phân quyền";
            column.VisibleIndex = 0;
            TreeListColumn column1 = treeList1.Columns.Add();
            column1.FieldName = "per_access";
            column1.Caption = "Truy xuất";
            column1.VisibleIndex = 1;
            tl.Columns[1].ColumnEdit = edit;
            TreeListColumn column2 = treeList1.Columns.Add();
            column2.FieldName = "per_read";
            column2.Caption = "Đọc";
            column2.VisibleIndex = 2;
            tl.Columns[2].ColumnEdit = edit;
            TreeListColumn column3 = treeList1.Columns.Add();
            column3.FieldName = "per_write";
            column3.Caption = "Ghi";
            column3.VisibleIndex = 3;
            tl.Columns[3].ColumnEdit = edit;
            TreeListColumn column4 = treeList1.Columns.Add();
            column4.FieldName = "per_delete";
            column4.Caption = "Xóa";
            column4.VisibleIndex = 4;
            tl.Columns[4].ColumnEdit = edit;
            TreeListColumn column5 = treeList1.Columns.Add();
            column5.FieldName = "ID";
            column5.Caption = "ID";
            tl.Columns[5].VisibleIndex = -1;
            tl.EndUpdate();
        }

        private void FrmTest_Treview_Load(object sender, EventArgs e)
        {
            CreateColumns(treeList1);
        }
    }
}
