namespace From_Report
{
    partial class FromMain
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
            this.documentViewer1 = new DevExpress.XtraPrinting.Preview.DocumentViewer();
            this.btnMau21 = new DevExpress.XtraEditors.SimpleButton();
            this.remoteDocumentSource1 = new DevExpress.ReportServer.Printing.RemoteDocumentSource();
            this.SuspendLayout();
            // 
            // documentViewer1
            // 
            this.documentViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentViewer1.IsMetric = false;
            this.documentViewer1.Location = new System.Drawing.Point(0, 0);
            this.documentViewer1.Name = "documentViewer1";
            this.documentViewer1.Size = new System.Drawing.Size(1038, 609);
            this.documentViewer1.TabIndex = 0;
            // 
            // btnMau21
            // 
            this.btnMau21.Location = new System.Drawing.Point(12, 110);
            this.btnMau21.Name = "btnMau21";
            this.btnMau21.Size = new System.Drawing.Size(102, 41);
            this.btnMau21.TabIndex = 1;
            this.btnMau21.Text = "Mẫu 21 BQP";
            // 
            // FromMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 609);
            this.Controls.Add(this.btnMau21);
            this.Controls.Add(this.documentViewer1);
            this.Name = "FromMain";
            this.Text = "FromMain";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraPrinting.Preview.DocumentViewer documentViewer1;
        private DevExpress.XtraEditors.SimpleButton btnMau21;
        private DevExpress.ReportServer.Printing.RemoteDocumentSource remoteDocumentSource1;
    }
}