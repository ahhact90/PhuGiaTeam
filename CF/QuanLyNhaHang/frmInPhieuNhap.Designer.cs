namespace QuanLyNhaHang
{
    partial class frmInPhieuNhap
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
            this.RPV_PhieuNhap = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.lblTienHang = new DevComponents.DotNetBar.LabelX();
            this.lblDaTra = new DevComponents.DotNetBar.LabelX();
            this.lblConNo = new DevComponents.DotNetBar.LabelX();
            this.NguoiGiao = new DevComponents.DotNetBar.LabelX();
            this.lblNhaCungCap = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // RPV_PhieuNhap
            // 
            this.RPV_PhieuNhap.ActiveViewIndex = -1;
            this.RPV_PhieuNhap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RPV_PhieuNhap.Cursor = System.Windows.Forms.Cursors.Default;
            this.RPV_PhieuNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RPV_PhieuNhap.Location = new System.Drawing.Point(0, 0);
            this.RPV_PhieuNhap.Name = "RPV_PhieuNhap";
            this.RPV_PhieuNhap.Size = new System.Drawing.Size(860, 666);
            this.RPV_PhieuNhap.TabIndex = 0;
            this.RPV_PhieuNhap.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // lblTienHang
            // 
            // 
            // 
            // 
            this.lblTienHang.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTienHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienHang.Location = new System.Drawing.Point(801, 12);
            this.lblTienHang.Name = "lblTienHang";
            this.lblTienHang.Size = new System.Drawing.Size(14, 10);
            this.lblTienHang.TabIndex = 1;
            // 
            // lblDaTra
            // 
            // 
            // 
            // 
            this.lblDaTra.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDaTra.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDaTra.Location = new System.Drawing.Point(821, 12);
            this.lblDaTra.Name = "lblDaTra";
            this.lblDaTra.Size = new System.Drawing.Size(10, 10);
            this.lblDaTra.TabIndex = 1;
            // 
            // lblConNo
            // 
            // 
            // 
            // 
            this.lblConNo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblConNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConNo.Location = new System.Drawing.Point(846, 12);
            this.lblConNo.Name = "lblConNo";
            this.lblConNo.Size = new System.Drawing.Size(12, 10);
            this.lblConNo.TabIndex = 1;
            // 
            // NguoiGiao
            // 
            // 
            // 
            // 
            this.NguoiGiao.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.NguoiGiao.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NguoiGiao.Location = new System.Drawing.Point(864, 12);
            this.NguoiGiao.Name = "NguoiGiao";
            this.NguoiGiao.Size = new System.Drawing.Size(15, 10);
            this.NguoiGiao.TabIndex = 1;
            // 
            // lblNhaCungCap
            // 
            // 
            // 
            // 
            this.lblNhaCungCap.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNhaCungCap.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNhaCungCap.Location = new System.Drawing.Point(785, 12);
            this.lblNhaCungCap.Name = "lblNhaCungCap";
            this.lblNhaCungCap.Size = new System.Drawing.Size(10, 10);
            this.lblNhaCungCap.TabIndex = 2;
            // 
            // frmInPhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 666);
            this.Controls.Add(this.lblNhaCungCap);
            this.Controls.Add(this.NguoiGiao);
            this.Controls.Add(this.lblConNo);
            this.Controls.Add(this.lblDaTra);
            this.Controls.Add(this.lblTienHang);
            this.Controls.Add(this.RPV_PhieuNhap);
            this.Name = "frmInPhieuNhap";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IN PHIẾU NHẬP HÀNG";
            this.Load += new System.EventHandler(this.frmInPhieuNhap_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer RPV_PhieuNhap;
        private DevComponents.DotNetBar.LabelX lblTienHang;
        private DevComponents.DotNetBar.LabelX lblDaTra;
        private DevComponents.DotNetBar.LabelX lblConNo;
        private DevComponents.DotNetBar.LabelX NguoiGiao;
        private DevComponents.DotNetBar.LabelX lblNhaCungCap;
    }
}