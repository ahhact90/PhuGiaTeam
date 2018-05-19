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
            this.cmbDatabase = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.SuspendLayout();
            // 
            // lstConnect
            // 
            this.lstConnect.FormattingEnabled = true;
            this.lstConnect.Location = new System.Drawing.Point(391, 12);
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
            // cmbDatabase
            // 
            this.cmbDatabase.DisplayMember = "Text";
            this.cmbDatabase.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbDatabase.FormattingEnabled = true;
            this.cmbDatabase.ItemHeight = 14;
            this.cmbDatabase.Location = new System.Drawing.Point(139, 26);
            this.cmbDatabase.Name = "cmbDatabase";
            this.cmbDatabase.Size = new System.Drawing.Size(182, 20);
            this.cmbDatabase.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbDatabase.TabIndex = 2;
            this.cmbDatabase.SelectedIndexChanged += new System.EventHandler(this.cmbDatabase_SelectedIndexChanged);
            // 
            // FrmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 438);
            this.Controls.Add(this.cmbDatabase);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lstConnect);
            this.Name = "FrmTest";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstConnect;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbDatabase;
    }
}

