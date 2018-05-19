namespace GeneralCode
{
    partial class FrmTest
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
            this.lstConnect = new System.Windows.Forms.ListBox();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // lstConnect
            // 
            this.lstConnect.FormattingEnabled = true;
            this.lstConnect.Location = new System.Drawing.Point(152, 12);
            this.lstConnect.Name = "lstConnect";
            this.lstConnect.Size = new System.Drawing.Size(134, 394);
            this.lstConnect.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(26, 26);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(97, 32);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "Kiểm tra kết nối";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FrmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 438);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lstConnect);
            this.Name = "FrmTest";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstConnect;
        private DevExpress.XtraEditors.SimpleButton btnOK;
    }
}

