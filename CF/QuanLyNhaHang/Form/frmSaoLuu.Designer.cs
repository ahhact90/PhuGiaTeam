namespace QuanLyNhaHang
{
    partial class frmSaoLuu
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDisconnect = new DevComponents.DotNetBar.ButtonX();
            this.btnConnect = new DevComponents.DotNetBar.ButtonX();
            this.txtPas = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtUs = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtServer = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.cbDataName = new System.Windows.Forms.ComboBox();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSauLuu = new DevComponents.DotNetBar.ButtonX();
            this.btnChon = new DevComponents.DotNetBar.ButtonX();
            this.txtNoiLuuSL = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtSQL = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnKhoiPhuc = new DevComponents.DotNetBar.ButtonX();
            this.btnChon1 = new DevComponents.DotNetBar.ButtonX();
            this.txtNoiLuuKP = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.ucTinhLuong1 = new LQ_NhaHang___Karaoke.UCTinhLuong();
            this.cachedcrt_InHoaDonCaFe1 = new QuanLyNhaHang.Cachedcrt_InHoaDonCaFe();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDisconnect);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.txtPas);
            this.groupBox1.Controls.Add(this.txtUs);
            this.groupBox1.Controls.Add(this.txtServer);
            this.groupBox1.Controls.Add(this.labelX3);
            this.groupBox1.Controls.Add(this.labelX2);
            this.groupBox1.Controls.Add(this.labelX1);
            this.groupBox1.Controls.Add(this.cbDataName);
            this.groupBox1.Controls.Add(this.labelX4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(494, 110);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thiết lập kết nối tới  CSDL SQL Server";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDisconnect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Location = new System.Drawing.Point(385, 81);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(99, 22);
            this.btnDisconnect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDisconnect.TabIndex = 6;
            this.btnDisconnect.Text = "Ngắt Kết Nối";
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnConnect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnConnect.Location = new System.Drawing.Point(385, 24);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(99, 22);
            this.btnConnect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "Kết nối";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtPas
            // 
            // 
            // 
            // 
            this.txtPas.Border.Class = "TextBoxBorder";
            this.txtPas.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPas.ButtonCustom.Tooltip = "";
            this.txtPas.ButtonCustom2.Tooltip = "";
            this.txtPas.Location = new System.Drawing.Point(288, 56);
            this.txtPas.Name = "txtPas";
            this.txtPas.PasswordChar = '*';
            this.txtPas.PreventEnterBeep = true;
            this.txtPas.Size = new System.Drawing.Size(90, 22);
            this.txtPas.TabIndex = 3;
            // 
            // txtUs
            // 
            // 
            // 
            // 
            this.txtUs.Border.Class = "TextBoxBorder";
            this.txtUs.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUs.ButtonCustom.Tooltip = "";
            this.txtUs.ButtonCustom2.Tooltip = "";
            this.txtUs.Location = new System.Drawing.Point(111, 53);
            this.txtUs.Name = "txtUs";
            this.txtUs.PreventEnterBeep = true;
            this.txtUs.Size = new System.Drawing.Size(89, 22);
            this.txtUs.TabIndex = 2;
            // 
            // txtServer
            // 
            // 
            // 
            // 
            this.txtServer.Border.Class = "TextBoxBorder";
            this.txtServer.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtServer.ButtonCustom.Tooltip = "";
            this.txtServer.ButtonCustom2.Tooltip = "";
            this.txtServer.Location = new System.Drawing.Point(111, 24);
            this.txtServer.Name = "txtServer";
            this.txtServer.PreventEnterBeep = true;
            this.txtServer.Size = new System.Drawing.Size(267, 22);
            this.txtServer.TabIndex = 1;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(206, 55);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(92, 23);
            this.labelX3.TabIndex = 5;
            this.labelX3.Text = "PASSWORD :";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(13, 51);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(92, 23);
            this.labelX2.TabIndex = 5;
            this.labelX2.Text = "SERVER SQL :";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(13, 22);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(92, 23);
            this.labelX1.TabIndex = 5;
            this.labelX1.Text = "SERVER SQL :";
            // 
            // cbDataName
            // 
            this.cbDataName.Enabled = false;
            this.cbDataName.FormattingEnabled = true;
            this.cbDataName.Location = new System.Drawing.Point(111, 82);
            this.cbDataName.Name = "cbDataName";
            this.cbDataName.Size = new System.Drawing.Size(267, 23);
            this.cbDataName.TabIndex = 4;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(13, 81);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(98, 23);
            this.labelX4.TabIndex = 3;
            this.labelX4.Text = "CHỌN CSDL : ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSauLuu);
            this.groupBox2.Controls.Add(this.btnChon);
            this.groupBox2.Controls.Add(this.txtNoiLuuSL);
            this.groupBox2.Controls.Add(this.labelX5);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(494, 77);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sao Lưu CSDL";
            // 
            // btnSauLuu
            // 
            this.btnSauLuu.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSauLuu.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSauLuu.Enabled = false;
            this.btnSauLuu.Location = new System.Drawing.Point(385, 49);
            this.btnSauLuu.Name = "btnSauLuu";
            this.btnSauLuu.Size = new System.Drawing.Size(99, 22);
            this.btnSauLuu.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSauLuu.TabIndex = 8;
            this.btnSauLuu.Text = "Sao Lưu";
            this.btnSauLuu.Click += new System.EventHandler(this.btnSauLuu_Click);
            // 
            // btnChon
            // 
            this.btnChon.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnChon.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnChon.Location = new System.Drawing.Point(385, 21);
            this.btnChon.Name = "btnChon";
            this.btnChon.Size = new System.Drawing.Size(99, 22);
            this.btnChon.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnChon.TabIndex = 7;
            this.btnChon.Text = "Chọn";
            this.btnChon.Click += new System.EventHandler(this.btnChon_Click);
            // 
            // txtNoiLuuSL
            // 
            // 
            // 
            // 
            this.txtNoiLuuSL.Border.Class = "TextBoxBorder";
            this.txtNoiLuuSL.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNoiLuuSL.ButtonCustom.Tooltip = "";
            this.txtNoiLuuSL.ButtonCustom2.Tooltip = "";
            this.txtNoiLuuSL.Location = new System.Drawing.Point(111, 24);
            this.txtNoiLuuSL.Name = "txtNoiLuuSL";
            this.txtNoiLuuSL.PreventEnterBeep = true;
            this.txtNoiLuuSL.ReadOnly = true;
            this.txtNoiLuuSL.Size = new System.Drawing.Size(267, 22);
            this.txtNoiLuuSL.TabIndex = 0;
            this.txtNoiLuuSL.TextChanged += new System.EventHandler(this.txtNoiLuuSL_TextChanged);
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(13, 22);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(102, 23);
            this.labelX5.TabIndex = 0;
            this.labelX5.Text = "NƠI SAO LƯU  : ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtSQL);
            this.groupBox3.Controls.Add(this.btnKhoiPhuc);
            this.groupBox3.Controls.Add(this.btnChon1);
            this.groupBox3.Controls.Add(this.txtNoiLuuKP);
            this.groupBox3.Controls.Add(this.labelX6);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 187);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(494, 109);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Khôi phục CSDL";
            // 
            // txtSQL
            // 
            // 
            // 
            // 
            this.txtSQL.Border.Class = "TextBoxBorder";
            this.txtSQL.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSQL.ButtonCustom.Tooltip = "";
            this.txtSQL.ButtonCustom2.Tooltip = "";
            this.txtSQL.Location = new System.Drawing.Point(15, 79);
            this.txtSQL.Name = "txtSQL";
            this.txtSQL.PreventEnterBeep = true;
            this.txtSQL.Size = new System.Drawing.Size(469, 22);
            this.txtSQL.TabIndex = 11;
            // 
            // btnKhoiPhuc
            // 
            this.btnKhoiPhuc.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnKhoiPhuc.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnKhoiPhuc.Enabled = false;
            this.btnKhoiPhuc.Location = new System.Drawing.Point(385, 51);
            this.btnKhoiPhuc.Name = "btnKhoiPhuc";
            this.btnKhoiPhuc.Size = new System.Drawing.Size(99, 22);
            this.btnKhoiPhuc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnKhoiPhuc.TabIndex = 10;
            this.btnKhoiPhuc.Text = "Khôi phục";
            this.btnKhoiPhuc.Click += new System.EventHandler(this.btnKhoiPhuc_Click);
            // 
            // btnChon1
            // 
            this.btnChon1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnChon1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnChon1.Location = new System.Drawing.Point(385, 23);
            this.btnChon1.Name = "btnChon1";
            this.btnChon1.Size = new System.Drawing.Size(99, 22);
            this.btnChon1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnChon1.TabIndex = 9;
            this.btnChon1.Text = "Chọn";
            this.btnChon1.Click += new System.EventHandler(this.btnChon1_Click);
            // 
            // txtNoiLuuKP
            // 
            // 
            // 
            // 
            this.txtNoiLuuKP.Border.Class = "TextBoxBorder";
            this.txtNoiLuuKP.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNoiLuuKP.ButtonCustom.Tooltip = "";
            this.txtNoiLuuKP.ButtonCustom2.Tooltip = "";
            this.txtNoiLuuKP.Location = new System.Drawing.Point(111, 23);
            this.txtNoiLuuKP.Name = "txtNoiLuuKP";
            this.txtNoiLuuKP.PreventEnterBeep = true;
            this.txtNoiLuuKP.ReadOnly = true;
            this.txtNoiLuuKP.Size = new System.Drawing.Size(267, 22);
            this.txtNoiLuuKP.TabIndex = 0;
            this.txtNoiLuuKP.TextChanged += new System.EventHandler(this.txtNoiLuuKP_TextChanged);
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(13, 21);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(92, 23);
            this.labelX6.TabIndex = 3;
            this.labelX6.Text = "NƠI LƯU FILE : ";
            // 
            // ucTinhLuong1
            // 
            this.ucTinhLuong1.Location = new System.Drawing.Point(0, 0);
            this.ucTinhLuong1.Name = "ucTinhLuong1";
            this.ucTinhLuong1.Size = new System.Drawing.Size(736, 474);
            this.ucTinhLuong1.TabIndex = 4;
            // 
            // frmSaoLuu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 296);
            this.Controls.Add(this.ucTinhLuong1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSaoLuu";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "     SAO LƯU - PHỤC HỒI CƠ SỞ DỮ LIỆU";
            this.Load += new System.EventHandler(this.frmSaoLuu_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.ButtonX btnDisconnect;
        private DevComponents.DotNetBar.ButtonX btnConnect;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPas;
        private DevComponents.DotNetBar.Controls.TextBoxX txtUs;
        private DevComponents.DotNetBar.Controls.TextBoxX txtServer;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.ComboBox cbDataName;
        private DevComponents.DotNetBar.LabelX labelX4;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevComponents.DotNetBar.ButtonX btnSauLuu;
        private DevComponents.DotNetBar.ButtonX btnChon;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNoiLuuSL;
        private DevComponents.DotNetBar.LabelX labelX5;
        private System.Windows.Forms.GroupBox groupBox3;
        private DevComponents.DotNetBar.ButtonX btnKhoiPhuc;
        private DevComponents.DotNetBar.ButtonX btnChon1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNoiLuuKP;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSQL;
        private LQ_NhaHang___Karaoke.UCTinhLuong ucTinhLuong1;
        private Cachedcrt_InHoaDonCaFe cachedcrt_InHoaDonCaFe1;

    }
}