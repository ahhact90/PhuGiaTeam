namespace From_Report.From_Dstore
{
    partial class From_Duoc_AnhXa
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
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.grdCtrlThuocAX = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Drug_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UsingDrugId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Drug_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.component = new DevExpress.XtraGrid.Columns.GridColumn();
            this.content_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.unit_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Ma_AX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MA_BV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.service_type_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.stockid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mainimexid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.use_type_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.creationdate_drug = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel2.SuspendLayout();
            this.dockPanel2_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCtrlThuocAX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1,
            this.dockPanel2});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane"});
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Top;
            this.dockPanel1.ID = new System.Guid("9cd5423a-2882-4923-af80-36a63b104e29");
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 295);
            this.dockPanel1.Size = new System.Drawing.Size(1089, 295);
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(1081, 268);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // dockPanel2
            // 
            this.dockPanel2.Controls.Add(this.dockPanel2_Container);
            this.dockPanel2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dockPanel2.ID = new System.Guid("b434e5f9-3e22-418f-a14f-e386d7d5ddb1");
            this.dockPanel2.Location = new System.Drawing.Point(0, 295);
            this.dockPanel2.Name = "dockPanel2";
            this.dockPanel2.OriginalSize = new System.Drawing.Size(200, 340);
            this.dockPanel2.Size = new System.Drawing.Size(1089, 340);
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Controls.Add(this.grdCtrlThuocAX);
            this.dockPanel2_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(1081, 313);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // grdCtrlThuocAX
            // 
            this.grdCtrlThuocAX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCtrlThuocAX.Location = new System.Drawing.Point(0, 0);
            this.grdCtrlThuocAX.MainView = this.gridView1;
            this.grdCtrlThuocAX.Name = "grdCtrlThuocAX";
            this.grdCtrlThuocAX.Size = new System.Drawing.Size(1081, 313);
            this.grdCtrlThuocAX.TabIndex = 0;
            this.grdCtrlThuocAX.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Drug_ID,
            this.UsingDrugId,
            this.Drug_name,
            this.component,
            this.content_name,
            this.unit_name,
            this.Ma_AX,
            this.MA_BV,
            this.service_type_id,
            this.stockid,
            this.mainimexid,
            this.use_type_id,
            this.creationdate_drug});
            this.gridView1.GridControl = this.grdCtrlThuocAX;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            // 
            // Drug_ID
            // 
            this.Drug_ID.Caption = "Mã Thuốc";
            this.Drug_ID.FieldName = "drug_id";
            this.Drug_ID.Name = "Drug_ID";
            this.Drug_ID.Visible = true;
            this.Drug_ID.VisibleIndex = 0;
            // 
            // UsingDrugId
            // 
            this.UsingDrugId.Caption = "UsingdrugId";
            this.UsingDrugId.FieldName = "usingdrugid";
            this.UsingDrugId.Name = "UsingDrugId";
            this.UsingDrugId.Visible = true;
            this.UsingDrugId.VisibleIndex = 1;
            // 
            // Drug_name
            // 
            this.Drug_name.Caption = "Tên Thuốc";
            this.Drug_name.FieldName = "drug_name";
            this.Drug_name.Name = "Drug_name";
            this.Drug_name.Visible = true;
            this.Drug_name.VisibleIndex = 2;
            // 
            // component
            // 
            this.component.Caption = "Hoạt Chất";
            this.component.FieldName = "component";
            this.component.Name = "component";
            this.component.Visible = true;
            this.component.VisibleIndex = 3;
            // 
            // content_name
            // 
            this.content_name.Caption = "Hàm Lượng";
            this.content_name.FieldName = "content_name";
            this.content_name.Name = "content_name";
            this.content_name.Visible = true;
            this.content_name.VisibleIndex = 4;
            // 
            // unit_name
            // 
            this.unit_name.Caption = "Đơn vị tính";
            this.unit_name.FieldName = "unit_name";
            this.unit_name.Name = "unit_name";
            this.unit_name.Visible = true;
            this.unit_name.VisibleIndex = 5;
            // 
            // Ma_AX
            // 
            this.Ma_AX.Caption = "Mã Ánh Xạ";
            this.Ma_AX.FieldName = "ma_ax";
            this.Ma_AX.Name = "Ma_AX";
            this.Ma_AX.Visible = true;
            this.Ma_AX.VisibleIndex = 7;
            // 
            // MA_BV
            // 
            this.MA_BV.Caption = "Mã Bệnh Viện";
            this.MA_BV.FieldName = "ma_bv";
            this.MA_BV.Name = "MA_BV";
            this.MA_BV.Visible = true;
            this.MA_BV.VisibleIndex = 6;
            // 
            // service_type_id
            // 
            this.service_type_id.Caption = "Nhóm";
            this.service_type_id.FieldName = "service_type_id";
            this.service_type_id.Name = "service_type_id";
            this.service_type_id.Visible = true;
            this.service_type_id.VisibleIndex = 9;
            // 
            // stockid
            // 
            this.stockid.Caption = "Kho";
            this.stockid.FieldName = "stockid";
            this.stockid.Name = "stockid";
            this.stockid.Visible = true;
            this.stockid.VisibleIndex = 11;
            // 
            // mainimexid
            // 
            this.mainimexid.Caption = "Số Phiếu";
            this.mainimexid.FieldName = "mainimexid";
            this.mainimexid.Name = "mainimexid";
            this.mainimexid.Visible = true;
            this.mainimexid.VisibleIndex = 10;
            // 
            // use_type_id
            // 
            this.use_type_id.Caption = "Đường Dùng";
            this.use_type_id.FieldName = "use_type_id";
            this.use_type_id.Name = "use_type_id";
            this.use_type_id.Visible = true;
            this.use_type_id.VisibleIndex = 8;
            // 
            // creationdate_drug
            // 
            this.creationdate_drug.Caption = "Ngày Thêm Thuốc";
            this.creationdate_drug.FieldName = "creationdate_drug";
            this.creationdate_drug.GroupFormat.FormatString = "d";
            this.creationdate_drug.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.creationdate_drug.Name = "creationdate_drug";
            this.creationdate_drug.Visible = true;
            this.creationdate_drug.VisibleIndex = 12;
            // 
            // From_Duoc_AnhXa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 635);
            this.Controls.Add(this.dockPanel2);
            this.Controls.Add(this.dockPanel1);
            this.Name = "From_Duoc_AnhXa";
            this.Text = "From_Duoc_AnhXa";
            this.Load += new System.EventHandler(this.From_Duoc_AnhXa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel2.ResumeLayout(false);
            this.dockPanel2_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCtrlThuocAX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel2;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraGrid.GridControl grdCtrlThuocAX;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Drug_ID;
        private DevExpress.XtraGrid.Columns.GridColumn UsingDrugId;
        private DevExpress.XtraGrid.Columns.GridColumn Drug_name;
        private DevExpress.XtraGrid.Columns.GridColumn component;
        private DevExpress.XtraGrid.Columns.GridColumn content_name;
        private DevExpress.XtraGrid.Columns.GridColumn unit_name;
        private DevExpress.XtraGrid.Columns.GridColumn Ma_AX;
        private DevExpress.XtraGrid.Columns.GridColumn use_type_id;
        private DevExpress.XtraGrid.Columns.GridColumn service_type_id;
        private DevExpress.XtraGrid.Columns.GridColumn stockid;
        private DevExpress.XtraGrid.Columns.GridColumn mainimexid;
        private DevExpress.XtraGrid.Columns.GridColumn creationdate_drug;
        private DevExpress.XtraGrid.Columns.GridColumn MA_BV;

    }
}