namespace From_Report.From_CV3360
{
    partial class CV3360_CT
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
            this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.btnXuat = new System.Windows.Forms.Button();
            this.rdoNoiTru = new System.Windows.Forms.RadioButton();
            this.rdobtnTNT = new System.Windows.Forms.RadioButton();
            this.rdobtnNgoaiTru = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tdFrom = new DevExpress.XtraEditors.TimeEdit();
            this.tdTo = new DevExpress.XtraEditors.TimeEdit();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.xtraScrollableControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tdFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tdTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraScrollableControl1
            // 
            this.xtraScrollableControl1.Controls.Add(this.btnXuat);
            this.xtraScrollableControl1.Controls.Add(this.rdoNoiTru);
            this.xtraScrollableControl1.Controls.Add(this.rdobtnTNT);
            this.xtraScrollableControl1.Controls.Add(this.rdobtnNgoaiTru);
            this.xtraScrollableControl1.Controls.Add(this.label2);
            this.xtraScrollableControl1.Controls.Add(this.label1);
            this.xtraScrollableControl1.Controls.Add(this.tdFrom);
            this.xtraScrollableControl1.Controls.Add(this.tdTo);
            this.xtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraScrollableControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraScrollableControl1.Name = "xtraScrollableControl1";
            this.xtraScrollableControl1.Size = new System.Drawing.Size(1032, 637);
            this.xtraScrollableControl1.TabIndex = 0;
            // 
            // btnXuat
            // 
            this.btnXuat.Location = new System.Drawing.Point(19, 119);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(115, 54);
            this.btnXuat.TabIndex = 8;
            this.btnXuat.Text = "Export";
            this.btnXuat.UseVisualStyleBackColor = true;
            this.btnXuat.Click += new System.EventHandler(this.btnXuat_Click);
            // 
            // rdoNoiTru
            // 
            this.rdoNoiTru.AutoSize = true;
            this.rdoNoiTru.Location = new System.Drawing.Point(323, 20);
            this.rdoNoiTru.Name = "rdoNoiTru";
            this.rdoNoiTru.Size = new System.Drawing.Size(87, 23);
            this.rdoNoiTru.TabIndex = 7;
            this.rdoNoiTru.TabStop = true;
            this.rdoNoiTru.Text = "Nội Trú";
            this.rdoNoiTru.UseVisualStyleBackColor = true;
            // 
            // rdobtnTNT
            // 
            this.rdobtnTNT.AutoSize = true;
            this.rdobtnTNT.Location = new System.Drawing.Point(143, 20);
            this.rdobtnTNT.Name = "rdobtnTNT";
            this.rdobtnTNT.Size = new System.Drawing.Size(151, 23);
            this.rdobtnTNT.TabIndex = 6;
            this.rdobtnTNT.TabStop = true;
            this.rdobtnTNT.Text = "Thận Nhân Tạo";
            this.rdobtnTNT.UseVisualStyleBackColor = true;
            // 
            // rdobtnNgoaiTru
            // 
            this.rdobtnNgoaiTru.AutoSize = true;
            this.rdobtnNgoaiTru.Location = new System.Drawing.Point(19, 20);
            this.rdobtnNgoaiTru.Name = "rdobtnNgoaiTru";
            this.rdobtnNgoaiTru.Size = new System.Drawing.Size(107, 23);
            this.rdobtnNgoaiTru.TabIndex = 5;
            this.rdobtnNgoaiTru.TabStop = true;
            this.rdobtnNgoaiTru.Text = "Ngoại Trú";
            this.rdobtnNgoaiTru.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(211, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Đến";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Từ";
            // 
            // tdFrom
            // 
            this.tdFrom.EditValue = new System.DateTime(2017, 7, 25, 0, 0, 0, 0);
            this.tdFrom.Location = new System.Drawing.Point(258, 72);
            this.tdFrom.Name = "tdFrom";
            this.tdFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tdFrom.Properties.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.tdFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.tdFrom.Properties.EditFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.tdFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.tdFrom.Properties.Mask.EditMask = "dd/MM/yyyy HH:mm:ss";
            this.tdFrom.Size = new System.Drawing.Size(142, 20);
            this.tdFrom.TabIndex = 1;
            // 
            // tdTo
            // 
            this.tdTo.EditValue = new System.DateTime(2017, 7, 25, 0, 0, 0, 0);
            this.tdTo.Location = new System.Drawing.Point(49, 72);
            this.tdTo.Name = "tdTo";
            this.tdTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tdTo.Properties.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.tdTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.tdTo.Properties.EditFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.tdTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.tdTo.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Strong;
            this.tdTo.Properties.Mask.EditMask = "dd/MM/yyyy HH:mm:ss";
            this.tdTo.Size = new System.Drawing.Size(147, 20);
            this.tdTo.TabIndex = 0;
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
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
            // CV3360_CT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 637);
            this.Controls.Add(this.xtraScrollableControl1);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "CV3360_CT";
            this.Text = "3360_Cần Thơ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.xtraScrollableControl1.ResumeLayout(false);
            this.xtraScrollableControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tdFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tdTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        private DevExpress.XtraEditors.TimeEdit tdTo;
        private DevExpress.XtraEditors.TimeEdit tdFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnXuat;
        private System.Windows.Forms.RadioButton rdoNoiTru;
        private System.Windows.Forms.RadioButton rdobtnTNT;
        private System.Windows.Forms.RadioButton rdobtnNgoaiTru;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;

    }
}