namespace From_Report.From_CauHinh
{
    partial class FrmMH
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
            this.lbText = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtNhap = new DevExpress.XtraEditors.TextEdit();
            this.txtXuat = new DevExpress.XtraEditors.TextEdit();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btDec = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtNhap2 = new DevExpress.XtraEditors.TextEdit();
            this.txtXuat2 = new DevExpress.XtraEditors.TextEdit();
            this.btOk2 = new DevExpress.XtraEditors.SimpleButton();
            this.btDec2 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtNhap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtXuat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNhap2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtXuat2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lbText
            // 
            this.lbText.Location = new System.Drawing.Point(27, 37);
            this.lbText.Name = "lbText";
            this.lbText.Size = new System.Drawing.Size(55, 13);
            this.lbText.TabIndex = 0;
            this.lbText.Text = "Chuỗi Nhập";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(27, 88);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Chuỗi Xuất";
            // 
            // txtNhap
            // 
            this.txtNhap.Location = new System.Drawing.Point(133, 30);
            this.txtNhap.Name = "txtNhap";
            this.txtNhap.Size = new System.Drawing.Size(264, 20);
            this.txtNhap.TabIndex = 2;
            // 
            // txtXuat
            // 
            this.txtXuat.Location = new System.Drawing.Point(133, 85);
            this.txtXuat.Name = "txtXuat";
            this.txtXuat.Size = new System.Drawing.Size(264, 20);
            this.txtXuat.TabIndex = 3;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(133, 143);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(95, 34);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Mã hóa";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btDec
            // 
            this.btDec.Location = new System.Drawing.Point(284, 143);
            this.btDec.Name = "btDec";
            this.btDec.Size = new System.Drawing.Size(113, 34);
            this.btDec.TabIndex = 5;
            this.btDec.Text = "Giải Mã";
            this.btDec.Click += new System.EventHandler(this.btDec_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(27, 263);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(64, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Chuỗi Nhập 2";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(27, 314);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(61, 13);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "Chuỗi Xuất 2";
            // 
            // txtNhap2
            // 
            this.txtNhap2.Location = new System.Drawing.Point(133, 256);
            this.txtNhap2.Name = "txtNhap2";
            this.txtNhap2.Size = new System.Drawing.Size(264, 20);
            this.txtNhap2.TabIndex = 2;
            // 
            // txtXuat2
            // 
            this.txtXuat2.Location = new System.Drawing.Point(133, 311);
            this.txtXuat2.Name = "txtXuat2";
            this.txtXuat2.Size = new System.Drawing.Size(264, 20);
            this.txtXuat2.TabIndex = 3;
            // 
            // btOk2
            // 
            this.btOk2.Location = new System.Drawing.Point(133, 369);
            this.btOk2.Name = "btOk2";
            this.btOk2.Size = new System.Drawing.Size(95, 34);
            this.btOk2.TabIndex = 4;
            this.btOk2.Text = "Mã hóa 2";
            this.btOk2.Click += new System.EventHandler(this.btOk2_Click);
            // 
            // btDec2
            // 
            this.btDec2.Location = new System.Drawing.Point(284, 369);
            this.btDec2.Name = "btDec2";
            this.btDec2.Size = new System.Drawing.Size(113, 34);
            this.btDec2.TabIndex = 5;
            this.btDec2.Text = "Giải Mã 2";
            this.btDec2.Click += new System.EventHandler(this.btDec2_Click);
            // 
            // FrmMH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 636);
            this.Controls.Add(this.btDec2);
            this.Controls.Add(this.btOk2);
            this.Controls.Add(this.btDec);
            this.Controls.Add(this.txtXuat2);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtNhap2);
            this.Controls.Add(this.txtXuat);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtNhap);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.lbText);
            this.Name = "FrmMH";
            this.Text = "FrmMH";
            ((System.ComponentModel.ISupportInitialize)(this.txtNhap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtXuat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNhap2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtXuat2.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbText;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtNhap;
        private DevExpress.XtraEditors.TextEdit txtXuat;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btDec;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtNhap2;
        private DevExpress.XtraEditors.TextEdit txtXuat2;
        private DevExpress.XtraEditors.SimpleButton btOk2;
        private DevExpress.XtraEditors.SimpleButton btDec2;
    }
}