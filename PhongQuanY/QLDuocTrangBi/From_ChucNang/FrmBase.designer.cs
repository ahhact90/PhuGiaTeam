namespace PRE.Catalog
{
    partial class FrmBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.barMain = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnAdd = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnCancel = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnSearch = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnPrint = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bbiMenuAdd = new DevExpress.XtraBars.BarButtonItem();
            this.bbiMenuEdit = new DevExpress.XtraBars.BarButtonItem();
            this.bbiMenuDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bbiMenuSave = new DevExpress.XtraBars.BarButtonItem();
            this.bbiMenuCancel = new DevExpress.XtraBars.BarButtonItem();
            this.bbiLapHD = new DevExpress.XtraBars.BarLargeButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.barMain)).BeginInit();
            this.SuspendLayout();
            // 
            // barMain
            // 
            this.barMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar3});
            this.barMain.DockControls.Add(this.barDockControlTop);
            this.barMain.DockControls.Add(this.barDockControlBottom);
            this.barMain.DockControls.Add(this.barDockControlLeft);
            this.barMain.DockControls.Add(this.barDockControlRight);
            this.barMain.Form = this;
            this.barMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnAdd,
            this.btnEdit,
            this.btnDelete,
            this.btnSave,
            this.btnCancel,
            this.btnSearch,
            this.btnRefresh,
            this.btnPrint,
            this.btnClose,
            this.bbiMenuAdd,
            this.bbiMenuEdit,
            this.bbiMenuDelete,
            this.bbiMenuSave,
            this.bbiMenuCancel,
            this.bbiLapHD});
            this.barMain.MaxItemId = 15;
            this.barMain.StatusBar = this.bar3;
            this.barMain.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barMain_ItemClick);
            // 
            // bar1
            // 
            this.bar1.BarAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.bar1.BarAppearance.Normal.Options.UseFont = true;
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.FloatLocation = new System.Drawing.Point(39, 148);
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnAdd, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnEdit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSave, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnCancel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSearch, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnRefresh, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnPrint, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnClose, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.Text = "Tools";
            // 
            // btnAdd
            // 
            this.btnAdd.Caption = "&Thêm";
            this.btnAdd.Id = 0;
            this.btnAdd.LargeGlyph = global::QLDuocTrangBi.Properties.Resources._1;
            this.btnAdd.Name = "btnAdd";
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = "&Sửa";
            this.btnEdit.Glyph = global::QLDuocTrangBi.Properties.Resources._4;
            this.btnEdit.Id = 1;
            this.btnEdit.Name = "btnEdit";
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "&Xóa";
            this.btnDelete.Glyph = global::QLDuocTrangBi.Properties.Resources._3;
            this.btnDelete.Id = 2;
            this.btnDelete.Name = "btnDelete";
            // 
            // btnSave
            // 
            this.btnSave.Caption = "&Lưu";
            this.btnSave.Enabled = false;
            this.btnSave.Glyph = global::QLDuocTrangBi.Properties.Resources.save;
            this.btnSave.Id = 3;
            this.btnSave.Name = "btnSave";
            // 
            // btnCancel
            // 
            this.btnCancel.Caption = "&Hủy";
            this.btnCancel.Enabled = false;
            this.btnCancel.Glyph = global::QLDuocTrangBi.Properties.Resources._6;
            this.btnCancel.Id = 4;
            this.btnCancel.Name = "btnCancel";
            // 
            // btnSearch
            // 
            this.btnSearch.Caption = "&Tìm kiếm";
            this.btnSearch.Glyph = global::QLDuocTrangBi.Properties.Resources._5;
            this.btnSearch.Id = 5;
            this.btnSearch.Name = "btnSearch";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "&Làm tươi";
            this.btnRefresh.Glyph = global::QLDuocTrangBi.Properties.Resources.refresh1;
            this.btnRefresh.Id = 6;
            this.btnRefresh.Name = "btnRefresh";
            // 
            // btnPrint
            // 
            this.btnPrint.Caption = "&In";
            this.btnPrint.Glyph = global::QLDuocTrangBi.Properties.Resources.printer;
            this.btnPrint.Id = 7;
            this.btnPrint.Name = "btnPrint";
            // 
            // btnClose
            // 
            this.btnClose.Caption = "&Đóng";
            this.btnClose.Glyph = global::QLDuocTrangBi.Properties.Resources._2;
            this.btnClose.Id = 8;
            this.btnClose.Name = "btnClose";
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "ytui";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(413, 55);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 54);
            this.barDockControlBottom.Size = new System.Drawing.Size(413, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 55);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 0);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(413, 55);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 0);
            // 
            // bbiMenuAdd
            // 
            this.bbiMenuAdd.Caption = "Thêm";
            this.bbiMenuAdd.Id = 9;
            this.bbiMenuAdd.Name = "bbiMenuAdd";
            // 
            // bbiMenuEdit
            // 
            this.bbiMenuEdit.Caption = "Sửa";
            this.bbiMenuEdit.Id = 10;
            this.bbiMenuEdit.Name = "bbiMenuEdit";
            // 
            // bbiMenuDelete
            // 
            this.bbiMenuDelete.Caption = "Xóa";
            this.bbiMenuDelete.Id = 11;
            this.bbiMenuDelete.Name = "bbiMenuDelete";
            // 
            // bbiMenuSave
            // 
            this.bbiMenuSave.Caption = "Lưu";
            this.bbiMenuSave.Enabled = false;
            this.bbiMenuSave.Id = 12;
            this.bbiMenuSave.Name = "bbiMenuSave";
            // 
            // bbiMenuCancel
            // 
            this.bbiMenuCancel.Caption = "Hủy";
            this.bbiMenuCancel.Enabled = false;
            this.bbiMenuCancel.Id = 13;
            this.bbiMenuCancel.Name = "bbiMenuCancel";
            // 
            // bbiLapHD
            // 
            this.bbiLapHD.Caption = "&Lập Hóa đơn";
            this.bbiLapHD.Id = 14;
            this.bbiLapHD.Name = "bbiLapHD";
            // 
            // FrmBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 77);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmBase";
            this.Text = "FrmBase";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmBase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barMain;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarLargeButtonItem btnAdd;
        private DevExpress.XtraBars.BarLargeButtonItem btnEdit;
        private DevExpress.XtraBars.BarLargeButtonItem btnDelete;
        private DevExpress.XtraBars.BarLargeButtonItem btnSave;
        private DevExpress.XtraBars.BarLargeButtonItem btnCancel;
        private DevExpress.XtraBars.BarLargeButtonItem btnSearch;
        private DevExpress.XtraBars.BarLargeButtonItem btnRefresh;
        private DevExpress.XtraBars.BarLargeButtonItem btnPrint;
        private DevExpress.XtraBars.BarLargeButtonItem btnClose;
        private DevExpress.XtraBars.BarButtonItem bbiMenuAdd;
        private DevExpress.XtraBars.BarButtonItem bbiMenuEdit;
        private DevExpress.XtraBars.BarButtonItem bbiMenuDelete;
        private DevExpress.XtraBars.BarButtonItem bbiMenuSave;
        private DevExpress.XtraBars.BarButtonItem bbiMenuCancel;
        private DevExpress.XtraBars.BarLargeButtonItem bbiLapHD;
    }
}