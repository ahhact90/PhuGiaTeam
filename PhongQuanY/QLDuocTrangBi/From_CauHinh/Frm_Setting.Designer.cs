namespace QLDuocTrangBi.From_CauHinh
{
    partial class Frm_Setting
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
            this.txtNhap = new DevExpress.XtraEditors.TextEdit();
            this.txtXuat = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btn_Enc = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Dec = new DevExpress.XtraEditors.SimpleButton();
            this.txtConnect = new DevExpress.XtraEditors.SimpleButton();
            this.lst_database = new DevExpress.XtraEditors.ListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtNhap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtXuat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lst_database)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNhap
            // 
            this.txtNhap.Location = new System.Drawing.Point(181, 19);
            this.txtNhap.Name = "txtNhap";
            this.txtNhap.Size = new System.Drawing.Size(375, 20);
            this.txtNhap.TabIndex = 0;
            // 
            // txtXuat
            // 
            this.txtXuat.Location = new System.Drawing.Point(181, 55);
            this.txtXuat.Name = "txtXuat";
            this.txtXuat.Size = new System.Drawing.Size(375, 20);
            this.txtXuat.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(69, 22);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(65, 16);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Chuỗi Nhập";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(69, 59);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(62, 16);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Chuỗi Xuất";
            // 
            // btn_Enc
            // 
            this.btn_Enc.Location = new System.Drawing.Point(181, 101);
            this.btn_Enc.Name = "btn_Enc";
            this.btn_Enc.Size = new System.Drawing.Size(106, 44);
            this.btn_Enc.TabIndex = 2;
            this.btn_Enc.Text = "Mã Hóa";
            this.btn_Enc.Click += new System.EventHandler(this.btn_Enc_Click);
            // 
            // btn_Dec
            // 
            this.btn_Dec.Location = new System.Drawing.Point(450, 101);
            this.btn_Dec.Name = "btn_Dec";
            this.btn_Dec.Size = new System.Drawing.Size(106, 44);
            this.btn_Dec.TabIndex = 2;
            this.btn_Dec.Text = "Giải Mã";
            this.btn_Dec.Click += new System.EventHandler(this.btn_Dec_Click);
            // 
            // txtConnect
            // 
            this.txtConnect.Location = new System.Drawing.Point(29, 222);
            this.txtConnect.Name = "txtConnect";
            this.txtConnect.Size = new System.Drawing.Size(210, 41);
            this.txtConnect.TabIndex = 3;
            this.txtConnect.Text = "Kiểm tra Kết nối cơ sở dữ liệu";
            this.txtConnect.Click += new System.EventHandler(this.txtConnect_Click);
            // 
            // lst_database
            // 
            this.lst_database.Location = new System.Drawing.Point(307, 196);
            this.lst_database.Name = "lst_database";
            this.lst_database.Size = new System.Drawing.Size(202, 164);
            this.lst_database.TabIndex = 4;
            // 
            // Frm_Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 469);
            this.Controls.Add(this.lst_database);
            this.Controls.Add(this.txtConnect);
            this.Controls.Add(this.btn_Dec);
            this.Controls.Add(this.btn_Enc);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtXuat);
            this.Controls.Add(this.txtNhap);
            this.Name = "Frm_Setting";
            this.Text = "Frm_Setting";
            ((System.ComponentModel.ISupportInitialize)(this.txtNhap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtXuat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lst_database)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtNhap;
        private DevExpress.XtraEditors.TextEdit txtXuat;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btn_Enc;
        private DevExpress.XtraEditors.SimpleButton btn_Dec;
        private DevExpress.XtraEditors.SimpleButton txtConnect;
        private DevExpress.XtraEditors.ListBoxControl lst_database;
    }
}