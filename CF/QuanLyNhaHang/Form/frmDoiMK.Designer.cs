namespace QuanLyNhaHang
{
    partial class frmDoiMK
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.btnXacNhan = new DevComponents.DotNetBar.ButtonX();
            this.btnHuy = new DevComponents.DotNetBar.ButtonX();
            this.txtTenDN = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtMKCu = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtMKMoi = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtMKMoi1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(15, 15);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(95, 27);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Tên đăng nhập :";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(15, 48);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(95, 27);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "Mật khẩu Cũ :";
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(15, 81);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(95, 27);
            this.labelX3.TabIndex = 0;
            this.labelX3.Text = "Mật khẩu mới :";
            this.labelX3.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(15, 114);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(95, 27);
            this.labelX4.TabIndex = 0;
            this.labelX4.Text = "Nhập lại MK :";
            this.labelX4.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnXacNhan.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnXacNhan.Location = new System.Drawing.Point(54, 147);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(106, 41);
            this.btnXacNhan.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnXacNhan.TabIndex = 1;
            this.btnXacNhan.Text = "Xác nhận";
            // 
            // btnHuy
            // 
            this.btnHuy.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHuy.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnHuy.Location = new System.Drawing.Point(212, 147);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(109, 41);
            this.btnHuy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnHuy.TabIndex = 1;
            this.btnHuy.Text = "Hủy Bỏ";
            // 
            // txtTenDN
            // 
            // 
            // 
            // 
            this.txtTenDN.Border.Class = "TextBoxBorder";
            this.txtTenDN.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTenDN.ButtonCustom.Tooltip = "";
            this.txtTenDN.ButtonCustom2.Tooltip = "";
            this.txtTenDN.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenDN.Location = new System.Drawing.Point(117, 21);
            this.txtTenDN.Name = "txtTenDN";
            this.txtTenDN.PreventEnterBeep = true;
            this.txtTenDN.ReadOnly = true;
            this.txtTenDN.Size = new System.Drawing.Size(232, 22);
            this.txtTenDN.TabIndex = 2;
            // 
            // txtMKCu
            // 
            // 
            // 
            // 
            this.txtMKCu.Border.Class = "TextBoxBorder";
            this.txtMKCu.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMKCu.ButtonCustom.Tooltip = "";
            this.txtMKCu.ButtonCustom2.Tooltip = "";
            this.txtMKCu.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMKCu.Location = new System.Drawing.Point(117, 48);
            this.txtMKCu.Name = "txtMKCu";
            this.txtMKCu.PasswordChar = '*';
            this.txtMKCu.PreventEnterBeep = true;
            this.txtMKCu.Size = new System.Drawing.Size(232, 22);
            this.txtMKCu.TabIndex = 2;
            // 
            // txtMKMoi
            // 
            // 
            // 
            // 
            this.txtMKMoi.Border.Class = "TextBoxBorder";
            this.txtMKMoi.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMKMoi.ButtonCustom.Tooltip = "";
            this.txtMKMoi.ButtonCustom2.Tooltip = "";
            this.txtMKMoi.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMKMoi.Location = new System.Drawing.Point(117, 81);
            this.txtMKMoi.Name = "txtMKMoi";
            this.txtMKMoi.PasswordChar = '*';
            this.txtMKMoi.PreventEnterBeep = true;
            this.txtMKMoi.Size = new System.Drawing.Size(232, 22);
            this.txtMKMoi.TabIndex = 2;
            // 
            // txtMKMoi1
            // 
            // 
            // 
            // 
            this.txtMKMoi1.Border.Class = "TextBoxBorder";
            this.txtMKMoi1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMKMoi1.ButtonCustom.Tooltip = "";
            this.txtMKMoi1.ButtonCustom2.Tooltip = "";
            this.txtMKMoi1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMKMoi1.Location = new System.Drawing.Point(116, 114);
            this.txtMKMoi1.Name = "txtMKMoi1";
            this.txtMKMoi1.PasswordChar = '*';
            this.txtMKMoi1.PreventEnterBeep = true;
            this.txtMKMoi1.Size = new System.Drawing.Size(232, 22);
            this.txtMKMoi1.TabIndex = 2;
            // 
            // frmDoiMK
            // 
            this.AcceptButton = this.btnXacNhan;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 194);
            this.Controls.Add(this.txtMKMoi1);
            this.Controls.Add(this.txtMKMoi);
            this.Controls.Add(this.txtMKCu);
            this.Controls.Add(this.txtTenDN);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDoiMK";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "THAY ĐỔI MẬT KHẨU";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.ButtonX btnXacNhan;
        private DevComponents.DotNetBar.ButtonX btnHuy;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTenDN;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMKCu;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMKMoi;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMKMoi1;
    }
}