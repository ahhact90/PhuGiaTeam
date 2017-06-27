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
            this.txtBackup_BQP = new System.Windows.Forms.TextBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnExprot = new System.Windows.Forms.Button();
            this.btnbackup = new System.Windows.Forms.Button();
            this.rdoNgTru = new System.Windows.Forms.RadioButton();
            this.rdoTNT = new System.Windows.Forms.RadioButton();
            this.rdoNTru = new System.Windows.Forms.RadioButton();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Xuất File";
            // 
            // txtPathEx
            // 
            this.txtPathEx.Location = new System.Drawing.Point(30, 97);
            this.txtPathEx.Name = "txtPathEx";
            this.txtPathEx.Size = new System.Drawing.Size(417, 20);
            this.txtPathEx.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Backup File";
            // 
            // txtBackup_BQP
            // 
            this.txtBackup_BQP.Location = new System.Drawing.Point(30, 165);
            this.txtBackup_BQP.Name = "txtBackup_BQP";
            this.txtBackup_BQP.Size = new System.Drawing.Size(417, 20);
            this.txtBackup_BQP.TabIndex = 1;
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(29, 213);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(122, 43);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "Export XML";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click_1);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(255, 213);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(122, 43);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "CanCel";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click_1);
            // 
            // btnExprot
            // 
            this.btnExprot.Location = new System.Drawing.Point(469, 97);
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
            this.btnbackup.Location = new System.Drawing.Point(469, 164);
            this.btnbackup.Name = "btnbackup";
            this.btnbackup.Size = new System.Drawing.Size(26, 20);
            this.btnbackup.TabIndex = 4;
            this.btnbackup.Text = "...";
            this.btnbackup.UseVisualStyleBackColor = true;
            this.btnbackup.Click += new System.EventHandler(this.btnbackup_Click);
            // 
            // rdoNgTru
            // 
            this.rdoNgTru.AutoSize = true;
            this.rdoNgTru.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoNgTru.Location = new System.Drawing.Point(31, 25);
            this.rdoNgTru.Name = "rdoNgTru";
            this.rdoNgTru.Size = new System.Drawing.Size(86, 20);
            this.rdoNgTru.TabIndex = 5;
            this.rdoNgTru.TabStop = true;
            this.rdoNgTru.Text = "Ngoại Trú";
            this.rdoNgTru.UseVisualStyleBackColor = true;
            // 
            // rdoTNT
            // 
            this.rdoTNT.AutoSize = true;
            this.rdoTNT.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoTNT.Location = new System.Drawing.Point(164, 25);
            this.rdoTNT.Name = "rdoTNT";
            this.rdoTNT.Size = new System.Drawing.Size(120, 20);
            this.rdoTNT.TabIndex = 6;
            this.rdoTNT.TabStop = true;
            this.rdoTNT.Text = "Thận Nhân Tạo";
            this.rdoTNT.UseVisualStyleBackColor = true;
            // 
            // rdoNTru
            // 
            this.rdoNTru.AutoSize = true;
            this.rdoNTru.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoNTru.Location = new System.Drawing.Point(319, 25);
            this.rdoNTru.Name = "rdoNTru";
            this.rdoNTru.Size = new System.Drawing.Size(70, 20);
            this.rdoNTru.TabIndex = 7;
            this.rdoNTru.TabStop = true;
            this.rdoNTru.Text = "Nội Trú";
            this.rdoNTru.UseVisualStyleBackColor = true;
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoAll.Location = new System.Drawing.Point(431, 25);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(132, 20);
            this.rdoAll.TabIndex = 8;
            this.rdoAll.TabStop = true;
            this.rdoAll.Text = "Tất cả đối tượng";
            this.rdoAll.UseVisualStyleBackColor = true;
            // 
            // WebService_BQP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 285);
            this.Controls.Add(this.rdoAll);
            this.Controls.Add(this.rdoNTru);
            this.Controls.Add(this.rdoTNT);
            this.Controls.Add(this.rdoNgTru);
            this.Controls.Add(this.btnbackup);
            this.Controls.Add(this.btnExprot);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBackup_BQP);
            this.Controls.Add(this.txtPathEx);
            this.Controls.Add(this.label1);
            this.Name = "WebService_BQP";
            this.Text = "WebService_BQP";
            this.Load += new System.EventHandler(this.WebService_BQP_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPathEx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBackup_BQP;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnExprot;
        private System.Windows.Forms.Button btnbackup;
        private System.Windows.Forms.RadioButton rdoNgTru;
        private System.Windows.Forms.RadioButton rdoTNT;
        private System.Windows.Forms.RadioButton rdoNTru;
        private System.Windows.Forms.RadioButton rdoAll;
    }
}