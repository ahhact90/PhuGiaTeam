namespace QuanLyNhaHang
{
    partial class frmKhoiTao
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKhoiTao));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.prcLoad = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(408, 184);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // prcLoad
            // 
            // 
            // 
            // 
            this.prcLoad.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.prcLoad.Location = new System.Drawing.Point(12, 48);
            this.prcLoad.Name = "prcLoad";
            this.prcLoad.Size = new System.Drawing.Size(385, 32);
            this.prcLoad.Step = 2;
            this.prcLoad.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.prcLoad.TabIndex = 1;
            this.prcLoad.Text = "Đang khởi tạo chương trình";
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelX1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("labelX1.BackgroundImage")));
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.ForeColor = System.Drawing.Color.Red;
            this.labelX1.Location = new System.Drawing.Point(63, 86);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(298, 23);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "ĐANG KHỞI TẠO CƠ SỞ DỮ LIỆU";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 16;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmKhoiTao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 184);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.prcLoad);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmKhoiTao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmKhoiTao";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.Controls.ProgressBarX prcLoad;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.Timer timer1;
    }
}