﻿namespace From_Report.From_CauHinh
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
            this.txtHost = new DevExpress.XtraEditors.TextEdit();
            this.txtPass = new DevExpress.XtraEditors.TextEdit();
            this.txtPort = new DevExpress.XtraEditors.TextEdit();
            this.txtUid = new DevExpress.XtraEditors.TextEdit();
            this.txtServer = new DevExpress.XtraEditors.TextEdit();
            this.btOk = new DevExpress.XtraEditors.SimpleButton();
            this.btCancel = new DevExpress.XtraEditors.SimpleButton();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.txtMa = new DevExpress.XtraEditors.TextEdit();
            this.txtGiaiMa = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHost.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGiaiMa.Properties)).BeginInit();
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
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(113, 31);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(329, 20);
            this.txtHost.TabIndex = 5;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(113, 63);
            this.txtPass.Name = "txtPass";
            this.txtPass.Properties.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(329, 20);
            this.txtPass.TabIndex = 5;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(113, 95);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(329, 20);
            this.txtPort.TabIndex = 5;
            // 
            // txtUid
            // 
            this.txtUid.EditValue = "postgres";
            this.txtUid.Location = new System.Drawing.Point(113, 133);
            this.txtUid.Name = "txtUid";
            this.txtUid.Size = new System.Drawing.Size(329, 20);
            this.txtUid.TabIndex = 5;
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(113, 169);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(329, 20);
            this.txtServer.TabIndex = 5;
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(139, 222);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(89, 32);
            this.btOk.TabIndex = 6;
            this.btOk.Text = "OK";
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(275, 222);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(89, 32);
            this.btCancel.TabIndex = 6;
            this.btCancel.Text = "CANCEL";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(535, 39);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(368, 20);
            this.txtMa.TabIndex = 7;
            // 
            // txtGiaiMa
            // 
            this.txtGiaiMa.Location = new System.Drawing.Point(535, 98);
            this.txtGiaiMa.Name = "txtGiaiMa";
            this.txtGiaiMa.Size = new System.Drawing.Size(368, 20);
            this.txtGiaiMa.TabIndex = 7;
            // 
            // FromCauHinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 280);
            this.Controls.Add(this.txtGiaiMa);
            this.Controls.Add(this.txtMa);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.txtUid);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtHost);
            this.Controls.Add(this.lbServer);
            this.Controls.Add(this.lbUID);
            this.Controls.Add(this.lbPort);
            this.Controls.Add(this.lbPass);
            this.Controls.Add(this.lbHost);
            this.Name = "FromCauHinh";
            this.Text = "FromCauHinh";
            ((System.ComponentModel.ISupportInitialize)(this.txtHost.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGiaiMa.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbHost;
        private DevExpress.XtraEditors.LabelControl lbPass;
        private DevExpress.XtraEditors.LabelControl lbPort;
        private DevExpress.XtraEditors.LabelControl lbUID;
        private DevExpress.XtraEditors.LabelControl lbServer;
        private DevExpress.XtraEditors.TextEdit txtHost;
        private DevExpress.XtraEditors.TextEdit txtPass;
        private DevExpress.XtraEditors.TextEdit txtPort;
        private DevExpress.XtraEditors.TextEdit txtUid;
        private DevExpress.XtraEditors.TextEdit txtServer;
        private DevExpress.XtraEditors.SimpleButton btOk;
        private DevExpress.XtraEditors.SimpleButton btCancel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private DevExpress.XtraEditors.TextEdit txtMa;
        private DevExpress.XtraEditors.TextEdit txtGiaiMa;
    }
}