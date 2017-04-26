namespace From_Report
{
    partial class FrmDMKT
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
            this.grdCtrlDM = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.BtnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdCtrlDM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // grdCtrlDM
            // 
            this.grdCtrlDM.Location = new System.Drawing.Point(3, 2);
            this.grdCtrlDM.MainView = this.gridView1;
            this.grdCtrlDM.Name = "grdCtrlDM";
            this.grdCtrlDM.Size = new System.Drawing.Size(1049, 527);
            this.grdCtrlDM.TabIndex = 0;
            this.grdCtrlDM.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.grdCtrlDM.Resize += new System.EventHandler(this.grdCtrlDM_Resize);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grdCtrlDM;
            this.gridView1.Name = "gridView1";
            // 
            // BtnExport
            // 
            this.BtnExport.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExport.Appearance.Options.UseFont = true;
            this.BtnExport.Location = new System.Drawing.Point(12, 554);
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(156, 36);
            this.BtnExport.TabIndex = 1;
            this.BtnExport.Text = "Export Excel";
            this.BtnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // btnOK
            // 
            this.btnOK.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.Location = new System.Drawing.Point(220, 556);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(142, 33);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FrmDMKT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 633);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.BtnExport);
            this.Controls.Add(this.grdCtrlDM);
            this.Name = "FrmDMKT";
            this.Text = "FrmDMKT";
            ((System.ComponentModel.ISupportInitialize)(this.grdCtrlDM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdCtrlDM;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton BtnExport;
        private DevExpress.XtraEditors.SimpleButton btnOK;
    }
}