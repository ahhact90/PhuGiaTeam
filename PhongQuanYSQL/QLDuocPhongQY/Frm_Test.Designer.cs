namespace QLDuocPhongQY
{
    partial class Frm_Test
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
            this.btbConnect = new DevExpress.XtraEditors.SimpleButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.RTxtKQ = new System.Windows.Forms.RichTextBox();
            this.btRead = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblThumuc = new System.Windows.Forms.Label();
            this.textEdit_tenfile = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_tenfile.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btbConnect
            // 
            this.btbConnect.Location = new System.Drawing.Point(12, 12);
            this.btbConnect.Name = "btbConnect";
            this.btbConnect.Size = new System.Drawing.Size(131, 37);
            this.btbConnect.TabIndex = 1;
            this.btbConnect.Text = "Kiemtra Ket Noi";
            this.btbConnect.Click += new System.EventHandler(this.btbConnect_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(161, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(176, 124);
            this.dataGridView1.TabIndex = 2;
            // 
            // RTxtKQ
            // 
            this.RTxtKQ.Location = new System.Drawing.Point(12, 149);
            this.RTxtKQ.Name = "RTxtKQ";
            this.RTxtKQ.Size = new System.Drawing.Size(358, 143);
            this.RTxtKQ.TabIndex = 3;
            this.RTxtKQ.Text = "";
            // 
            // btRead
            // 
            this.btRead.Location = new System.Drawing.Point(12, 318);
            this.btRead.Name = "btRead";
            this.btRead.Size = new System.Drawing.Size(118, 51);
            this.btRead.TabIndex = 4;
            this.btRead.Text = "Đọc file cấu hình";
            this.btRead.UseVisualStyleBackColor = true;
            this.btRead.Click += new System.EventHandler(this.btRead_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 534);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 44);
            this.button1.TabIndex = 5;
            this.button1.Text = "Backup";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblThumuc
            // 
            this.lblThumuc.AutoSize = true;
            this.lblThumuc.Location = new System.Drawing.Point(12, 425);
            this.lblThumuc.Name = "lblThumuc";
            this.lblThumuc.Size = new System.Drawing.Size(56, 13);
            this.lblThumuc.TabIndex = 6;
            this.lblThumuc.Text = "lblThumuc";
            // 
            // textEdit_tenfile
            // 
            this.textEdit_tenfile.Location = new System.Drawing.Point(12, 484);
            this.textEdit_tenfile.Name = "textEdit_tenfile";
            this.textEdit_tenfile.Size = new System.Drawing.Size(503, 20);
            this.textEdit_tenfile.TabIndex = 7;
            // 
            // Frm_Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 760);
            this.Controls.Add(this.textEdit_tenfile);
            this.Controls.Add(this.lblThumuc);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btRead);
            this.Controls.Add(this.RTxtKQ);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btbConnect);
            this.Name = "Frm_Test";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Frm_Test_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_tenfile.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btbConnect;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RichTextBox RTxtKQ;
        private System.Windows.Forms.Button btRead;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblThumuc;
        private DevExpress.XtraEditors.TextEdit textEdit_tenfile;
    }
}

