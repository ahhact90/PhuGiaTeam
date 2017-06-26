namespace WebService
{
    partial class WebService_BQP
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtPathEx = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBackup = new System.Windows.Forms.TextBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnExprot = new System.Windows.Forms.Button();
            this.btnbackup = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Xuất File";
            // 
            // txtPathEx
            // 
            this.txtPathEx.Location = new System.Drawing.Point(30, 48);
            this.txtPathEx.Name = "txtPathEx";
            this.txtPathEx.Size = new System.Drawing.Size(417, 20);
            this.txtPathEx.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Backup File";
            // 
            // txtBackup
            // 
            this.txtBackup.Location = new System.Drawing.Point(30, 116);
            this.txtBackup.Name = "txtBackup";
            this.txtBackup.Size = new System.Drawing.Size(417, 20);
            this.txtBackup.TabIndex = 1;
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(29, 164);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(122, 43);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "Export XML";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(255, 164);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(122, 43);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "CanCel";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click_1);
            // 
            // btnExprot
            // 
            this.btnExprot.Location = new System.Drawing.Point(469, 48);
            this.btnExprot.Name = "btnExprot";
            this.btnExprot.Size = new System.Drawing.Size(26, 20);
            this.btnExprot.TabIndex = 4;
            this.btnExprot.Text = "...";
            this.btnExprot.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExprot.UseVisualStyleBackColor = true;
            this.btnExprot.Click += new System.EventHandler(this.btnExprot_Click);
            // 
            // btnbackup
            // 
            this.btnbackup.Location = new System.Drawing.Point(469, 115);
            this.btnbackup.Name = "btnbackup";
            this.btnbackup.Size = new System.Drawing.Size(26, 20);
            this.btnbackup.TabIndex = 4;
            this.btnbackup.Text = "...";
            this.btnbackup.UseVisualStyleBackColor = true;
            this.btnbackup.Click += new System.EventHandler(this.btnbackup_Click);
            // 
            // WebService_BQP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 247);
            this.Controls.Add(this.btnbackup);
            this.Controls.Add(this.btnExprot);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBackup);
            this.Controls.Add(this.txtPathEx);
            this.Controls.Add(this.label1);
            this.Name = "WebService_BQP";
            this.Text = "WebService_BQP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPathEx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBackup;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnExprot;
        private System.Windows.Forms.Button btnbackup;
    }
}