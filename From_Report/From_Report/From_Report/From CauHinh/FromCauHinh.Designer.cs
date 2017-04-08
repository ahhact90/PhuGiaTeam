namespace From_Report.From_CauHinh
{
    partial class FromCauHinh
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
            this.lbHost = new DevExpress.XtraEditors.LabelControl();
            this.lbPass = new DevExpress.XtraEditors.LabelControl();
            this.lbPort = new DevExpress.XtraEditors.LabelControl();
            this.lbUID = new DevExpress.XtraEditors.LabelControl();
            this.lbServer = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // lbHost
            // 
            this.lbHost.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHost.Location = new System.Drawing.Point(24, 33);
            this.lbHost.Name = "lbHost";
            this.lbHost.Size = new System.Drawing.Size(32, 19);
            this.lbHost.TabIndex = 0;
            this.lbHost.Text = "Host";
            // 
            // lbPass
            // 
            this.lbPass.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPass.Location = new System.Drawing.Point(24, 64);
            this.lbPass.Name = "lbPass";
            this.lbPass.Size = new System.Drawing.Size(31, 19);
            this.lbPass.TabIndex = 1;
            this.lbPass.Text = "Pass";
            // 
            // lbPort
            // 
            this.lbPort.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPort.Location = new System.Drawing.Point(24, 96);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(29, 19);
            this.lbPort.TabIndex = 2;
            this.lbPort.Text = "Port";
            // 
            // lbUID
            // 
            this.lbUID.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUID.Location = new System.Drawing.Point(24, 136);
            this.lbUID.Name = "lbUID";
            this.lbUID.Size = new System.Drawing.Size(28, 19);
            this.lbUID.TabIndex = 3;
            this.lbUID.Text = "UID";
            // 
            // lbServer
            // 
            this.lbServer.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbServer.Location = new System.Drawing.Point(24, 172);
            this.lbServer.Name = "lbServer";
            this.lbServer.Size = new System.Drawing.Size(45, 19);
            this.lbServer.TabIndex = 4;
            this.lbServer.Text = "Server";
            // 
            // FromCauHinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 289);
            this.Controls.Add(this.lbServer);
            this.Controls.Add(this.lbUID);
            this.Controls.Add(this.lbPort);
            this.Controls.Add(this.lbPass);
            this.Controls.Add(this.lbHost);
            this.Name = "FromCauHinh";
            this.Text = "FromCauHinh";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbHost;
        private DevExpress.XtraEditors.LabelControl lbPass;
        private DevExpress.XtraEditors.LabelControl lbPort;
        private DevExpress.XtraEditors.LabelControl lbUID;
        private DevExpress.XtraEditors.LabelControl lbServer;
    }
}