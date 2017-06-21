namespace WebService
{
    partial class WebService
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
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.txtPathEx = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBackup = new System.Windows.Forms.TextBox();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(12, 148);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(140, 33);
            this.btnExport.TabIndex = 0;
            this.btnExport.Text = "Export Auto";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(185, 148);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(122, 33);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "CanCel";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtPathEx
            // 
            this.txtPathEx.Location = new System.Drawing.Point(12, 38);
            this.txtPathEx.Name = "txtPathEx";
            this.txtPathEx.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPathEx.Size = new System.Drawing.Size(314, 20);
            this.txtPathEx.TabIndex = 3;
            this.txtPathEx.Text = "....";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(335, 37);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button1.Size = new System.Drawing.Size(22, 20);
            this.button1.TabIndex = 4;
            this.button1.Text = "....";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(15, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Xuất File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(15, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "Backup File";
            // 
            // txtBackup
            // 
            this.txtBackup.Location = new System.Drawing.Point(12, 105);
            this.txtBackup.Name = "txtBackup";
            this.txtBackup.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBackup.Size = new System.Drawing.Size(314, 20);
            this.txtBackup.TabIndex = 3;
            this.txtBackup.Text = "....";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(335, 105);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(22, 19);
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "..";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // WebService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 226);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtBackup);
            this.Controls.Add(this.txtPathEx);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnExport);
            this.Name = "WebService";
            this.Text = "WebService";
            this.Load += new System.EventHandler(this.WebService_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnExport;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private System.Windows.Forms.TextBox txtPathEx;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBackup;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}

