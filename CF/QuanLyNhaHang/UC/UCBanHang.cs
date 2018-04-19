using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL_NhaHang;
using ENTI_NhaHang;
using BUS_NhaHang;
using System.IO;

namespace QuanLyNhaHang
{
    public partial class UCBanHang : UserControl
    {
        BUS_dmHangHoa bus_DanhMuc = new BUS_dmHangHoa();
        BUS_Phong bus_Phong = new BUS_Phong();
        BUS_NhomHang bus_NhomHang = new BUS_NhomHang();
        BUS_PhieuXuat bus_px = new BUS_PhieuXuat();
        BUS_PhieuXuat_CT bus_pxct = new BUS_PhieuXuat_CT();
        BUS_GioVang bus_GioVang = new BUS_GioVang();

        EC_dmHangHoa etdm = new EC_dmHangHoa();
        EC_Phong etp = new EC_Phong();
        EC_NhomHang etnhom = new EC_NhomHang();
        EC_PhieuXuat etx = new EC_PhieuXuat();
        EC_PhieuXuat_CT etxct = new EC_PhieuXuat_CT();
        EC_GioVang etv = new EC_GioVang();

        public static string TenBan;
        public static string TenPhong;
        public static string TrangThaiB;
        public static string TrangThaiP;
        public static Int32 MaBan;
        public static Int32 MaPhong;
        public static string MaHD;
        public static string[] BatDauGV;
        public static string BatDau;
        public static string Loai;
        public static int a, b;
        public Boolean KetThuc;

        public static Boolean Ban;
        public static float TienNo;


        public UCBanHang()
        {
            InitializeComponent();
        }
        //====================== chuyen hinh anh sang byte =======================
        public static byte[] ImageSangByte(string FileAnh)
        {
            FileStream fs;
            fs = new FileStream(FileAnh, FileMode.Open, FileAccess.Read);
            byte[] Picbyte = new byte[fs.Length];
            fs.Read(Picbyte, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();
            return Picbyte;
        }
        //===============chuyen byte ve hinh anh =======================
        public static Image ByteSangImage(byte[] fileAnh)
        {
            MemoryStream ms = new MemoryStream(fileAnh);
            Image Hinhanh = Image.FromStream(ms);
            return Hinhanh;
        }
        public static void LoadListView(DataTable dt, ListView LV, ImageList IL)
        {
            try
            {

                int imgindex = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    IL.Images.Add(ByteSangImage((byte[])dt.Rows[i][2]));

                    var Vi = new ListViewItem(dt.Rows[i][1].ToString());
                    Vi.ImageIndex = imgindex;

                    LV.Items.Add(Vi);
                    imgindex = imgindex + 1;
                }
                LV.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi :" + ex.Message);
            }

        }
        //==============Load trạng thái bàn cafe==========
        void LoadBan()
        {
            livBan.Clear();
            imlBan.Images.Clear();
            LoadListView(bus_Phong.LoadPhong("where A.LoaiPhong=1"), livBan, imlBan);
            grvDanhMuc.DataSource = bus_NhomHang.TaoBang("");
            grvThucDon.DataSource = bus_DanhMuc.LayThucDon("");
            //----- phòng -------
            livPhong.Clear();
            imlPhong.Images.Clear();
            LoadListView(bus_Phong.LoadPhong("where A.LoaiPhong=2"), livPhong, imlPhong);
            grvNhom.DataSource = bus_NhomHang.TaoBang("");
            grvTD.DataSource = bus_DanhMuc.LayThucDon("");
            lblTu.DataBindings.Clear();
            lblTu.DataBindings.Add("Text",bus_GioVang.LayThongTinGioVang(etv),"BatDau");
            lblDen.DataBindings.Clear();
            lblDen.DataBindings.Add("Text", bus_GioVang.LayThongTinGioVang(etv), "KetThuc");
        }
        //====================khóa các button cafe =========================================
        void khoanut()
        {
            etp.MaPhong = MaBan;
            TrangThaiB = bus_Phong.LoadTrangThai(etp);
            //MessageBox.Show(TrangThai);
            if (TrangThaiB == "0")
            {
                
                btnThemMon.Enabled = false;
                btnHuyBan.Enabled = false;
                btnDonBan.Enabled = false;
                btnGhiNoBan.Enabled = false;
                btnXoaMon.Enabled = false;
                btnThemGhiChu.Enabled = false;
                txtGia.Enabled = false;
                numSLBan.Enabled = false;
                numKMBan.Enabled = false;
                btnDonBan.Enabled = false;

            }
            else if (TrangThaiB == "1")
            {
                btnThemMon.Enabled = true;
                btnHuyBan.Enabled = true;
                btnDonBan.Enabled = true;
                btnGhiNoBan.Enabled = true;
                btnXoaMon.Enabled = true;
                btnThemGhiChu.Enabled = true;
                txtGia.Enabled = true;
                numSLBan.Enabled = true;
                numKMBan.Enabled = true;
                btnTTBan.Enabled = true;
                btnDonBan.Enabled = false;
            }
            else
            {
                btnThemMon.Enabled = false;
                btnHuyBan.Enabled = false;
                btnDonBan.Enabled = false;
                btnGhiNoBan.Enabled = false;
                btnXoaMon.Enabled = false;
                btnThemGhiChu.Enabled = false;
                txtGia.Enabled = false;
                numSLBan.Enabled = false;
                numKMBan.Enabled = false;
                btnTTBan.Enabled = false;
                btnDonBan.Enabled = true;
            }
            
        }
        void khoanutPhong()
        {
            etp.MaPhong = MaPhong;
            TrangThaiP = bus_Phong.LoadTrangThai(etp);
            //MessageBox.Show(TrangThaiP);
            if (TrangThaiP == "0")
            {
                btnKetThuc.Enabled = false;
                btnThemGhiChuP.Enabled = false;
                btnXoaMonP.Enabled = false;
                btnThemMonP.Enabled = false;
                btnHuyPhong.Enabled = false;
                btnTTPhong.Enabled = false;
                btnGhiNoP.Enabled = false;
                numSLP.Enabled = false;
                txtGiaP.Enabled = false;
                txtPhuThup.Enabled = false;
                numKMP.Enabled = false;
                btnDonP.Enabled = false;

            }
            else if (TrangThaiP == "1")
            {
                btnKetThuc.Enabled = true;
                btnThemGhiChuP.Enabled = true;
                btnXoaMonP.Enabled = true;
                btnThemMonP.Enabled = true;
                btnHuyPhong.Enabled = true;
                btnTTPhong.Enabled = true;
                btnGhiNoP.Enabled = true;
                numSLP.Enabled = true;
                txtGiaP.Enabled = true;
                txtPhuThup.Enabled = true;
                numKMP.Enabled = true;
                btnDonP.Enabled = false;
            }
            else
            {
                btnKetThuc.Enabled = false;
                btnThemGhiChuP.Enabled = false;
                btnXoaMonP.Enabled = false;
                btnThemMonP.Enabled = false;
                btnHuyPhong.Enabled = false;
                btnTTPhong.Enabled = false;
                btnGhiNoP.Enabled = false;
                numSLP.Enabled = false;
                txtGiaP.Enabled = false;
                txtPhuThup.Enabled = false;
                numKMP.Enabled = false;
                btnDonP.Enabled = true;
               
            }

        }
        //=================load tien hát =========
        void loadTienHat()
        {
            dtpGioRa.DataBindings.Clear();
            dtpGioRa.DataBindings.Add("Text", bus_px.ThongTinPhieu(etx), "KetThuc");
            txtGio1.DataBindings.Clear();
            txtGio1.DataBindings.Add("Text", bus_px.ThongTinPhieu(etx), "SoGio1");
            txtGio2.DataBindings.Clear();
            txtGio2.DataBindings.Add("Text", bus_px.ThongTinPhieu(etx), "SoGio2");
            txtPhut1.DataBindings.Clear();
            txtPhut1.DataBindings.Add("Text", bus_px.ThongTinPhieu(etx), "SoPhut1");
            txtPhut2.DataBindings.Clear();
            txtPhut2.DataBindings.Add("Text", bus_px.ThongTinPhieu(etx), "SoPhut2");
            txtTienGio.DataBindings.Clear();
            txtTienGio.DataBindings.Add("text", bus_px.ThongTinPhieu(etx), "TienHat");
        }
        private void UCBanHang_Load(object sender, EventArgs e)
        {
            LoadBan();
            //dtpGioVao.Value = DateTime.Now;            
        }

        private void livBan_Click(object sender, EventArgs e)
        {
            TenBan = "-";
            TenBan = livBan.SelectedItems[0].Text;
            txtTenBan.Text = TenBan;
            txtHDBan.Text = "-";
            etp.TenPhong = txtTenBan.Text;
            txtHDBan.Text = bus_Phong.MaHD(etp);
            etp.TenPhong = txtTenBan.Text;
            MaBan = Int32.Parse(bus_Phong.MaPhong(etp));
            etx.SoPhieu = txtHDBan.Text;
            dtpBatDau.DataBindings.Clear();
            dtpBatDau.DataBindings.Add("Text",bus_px.ThongTinPhieu(etx),"BatDau");
            LoadBan();
            khoanut();
        }

        private void livBan_ItemActivate(object sender, EventArgs e)
        {            
            if (txtHDBan.Text == "--")
            {
                etx.MaPhong = MaBan;
                bus_px.TaoPhieuXuat(etx);
            }
            else MessageBox.Show("Bàn này đã có khách !");
            txtHDBan.Text = "-";
            etp.TenPhong = txtTenBan.Text;
            txtHDBan.Text = bus_Phong.MaHD(etp);
            etp.TenPhong = txtTenBan.Text;
            MaBan = Int32.Parse(bus_Phong.MaPhong(etp));
            LoadBan();
            khoanut();
        }

        private void txtTenBan_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void grvDanhMuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblMaNhom.DataBindings.Clear();
            lblMaNhom.DataBindings.Add("Text",grvDanhMuc.DataSource,"MaNhom");
            grvThucDon.DataSource = bus_DanhMuc.LayThucDon("Where MaNhom='"+lblMaNhom.Text+"'");
        }

        private void grvThucDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            lblMaMon.DataBindings.Clear();
            lblMaMon.DataBindings.Add("Text", grvThucDon.DataSource, "MaHang");
            txtGia.DataBindings.Clear();
            txtGia.DataBindings.Add("Text", grvThucDon.DataSource, "Giaban");
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            etxct.SoPhieu = txtHDBan.Text;
            etxct.MaHang =Int32.Parse(lblMaMon.Text);
            etxct.SoLuong = int.Parse( numSLBan.Value.ToString());
            etxct.GiaXuat = Int32.Parse(txtGia.Text);
            bus_pxct.ThenMon(etxct);
            etxct.SoPhieu = txtHDBan.Text;
            grvCTHDBan.DataSource = bus_pxct.ChiTietHoaDon(etxct);
            etx.SoPhieu = txtHDBan.Text;
            txtTienHangBan.DataBindings.Clear();
            txtTienHangBan.DataBindings.Add("Text",bus_px.ThongTinPhieu(etx),"TienHang");
        }

        private void txtHDBan_TextChanged(object sender, EventArgs e)
        {
            etxct.SoPhieu = txtHDBan.Text;
            grvCTHDBan.DataSource= bus_pxct.ChiTietHoaDon(etxct);
            etx.SoPhieu = txtHDBan.Text;
            txtTienHangBan.DataBindings.Clear();
            txtTienHangBan.DataBindings.Add("Text", bus_px.ThongTinPhieu(etx), "TienHang");
        }

        private void txtTienHangBan_TextChanged(object sender, EventArgs e)
        {
            txtTienHangBan.Text = String.Format("{0:#,###0}", float.Parse(txtTienHangBan.Text));
            txtThanhTienBan.Text = (((float.Parse( txtTienHangBan.Text)) +(float.Parse(txtPhuThuBan.Text)))-(float.Parse(txtTienKM.Text))).ToString();
        }

        private void txtGia_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtPhuThuBan_TextChanged(object sender, EventArgs e)
        {
            txtThanhTienBan.Text = (((float.Parse(txtTienHangBan.Text)) + (float.Parse(txtPhuThuBan.Text))) - (float.Parse(txtTienKM.Text))).ToString();
            
        }

        private void txtTienKM_TextChanged(object sender, EventArgs e)
        {
            
            txtThanhTienBan.Text = (((float.Parse(txtTienHangBan.Text)) + (float.Parse(txtPhuThuBan.Text))) - (float.Parse(txtTienKM.Text))).ToString();
            txtTienKM.Text = String.Format("{0:#,###0}", float.Parse(txtTienKM.Text));
        }

        private void numKMBan_ValueChanged(object sender, EventArgs e)
        {
            float a, b, c;
            a = float.Parse(txtTienHangBan.Text);
            b = float.Parse(numKMBan.Value.ToString());
            c= (b*a)/100;
            txtTienKM.Text = c.ToString();
        }

        private void grvCTHDBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblCTPXID.DataBindings.Clear();
            lblCTPXID.DataBindings.Add("Text", grvCTHDBan.DataSource, "CTPXID");
            txtGhiChu.DataBindings.Clear();
            txtGhiChu.DataBindings.Add("Text",grvCTHDBan.DataSource,"GhiChu");
        }

        private void btnXoaMon_Click(object sender, EventArgs e)
        {

        }

        private void grvThucDon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnHuyBan_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc hủy bàn này ?","Hủy bàn",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    etx.SoPhieu = txtHDBan.Text;
                    bus_px.HuyBan(etx);
                    etxct.SoPhieu = txtHDBan.Text;
                    bus_pxct.HuyBan(etxct);
                    etp.MaPhong = MaBan;
                    bus_Phong.HuyBan(etp);
                    LoadBan();
                    grvCTHDBan.DataSource = "";
                    khoanut();
                }
                catch
                {
                    MessageBox.Show("Lỗi không thể hủy bàn");
                }
            }
        }

        private void btnThemGhiChu_Click(object sender, EventArgs e)
        {
            if (btnThemGhiChu.Text == "Thêm ghi chú")
            {
                txtGhiChu.Visible = true;
                btnThemGhiChu.Text = "Lưu Lại";
            }
            else
            {
                if (lblCTPXID.Text == "")
                {
                    MessageBox.Show("Chọn chi tiết món muốn thêm ghi chú !");
                }
                else
                {
                    etxct.CTPXID = int.Parse(lblCTPXID.Text);
                    etxct.GhiChu = txtGhiChu.Text;
                    bus_pxct.ThemGhiChu(etxct);
                    txtGhiChu.Visible = false;
                    btnThemGhiChu.Text = "Thêm ghi chú";
                    etxct.SoPhieu = txtHDBan.Text;
                    grvCTHDBan.DataSource = bus_pxct.ChiTietHoaDon(etxct);
                }
            }
        }

        private void btnTTBan_Click(object sender, EventArgs e)
        {
            try
            {
                MaHD = txtHDBan.Text;
                etx.SoPhieu = txtHDBan.Text;
                etx.PhuThu = float.Parse(txtPhuThuBan.Text);
                etx.KhuyenMai = float.Parse(txtTienKM.Text);
                bus_px.ThanhToan_Cafe(etx);
                etp.MaPhong = MaBan;
                bus_Phong.ThanhToanBan(etp);                
                khoanut();
                LoadBan();
                if (cbin.Checked)
                {
                    Loai = "CaFe";
                    frmThanhToan_InHD _ThanhToan = new frmThanhToan_InHD();
                    _ThanhToan.ShowDialog();
                }
            }
            catch
            {

            }
        }

        private void grvThucDon_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (TrangThaiB == "1")
            {
                etxct.SoPhieu = txtHDBan.Text;
                etxct.MaHang = Int32.Parse(lblMaMon.Text);
                etxct.SoLuong = int.Parse(numSLBan.Value.ToString());
                etxct.GiaXuat = Int32.Parse(txtGia.Text);
                bus_pxct.ThenMon(etxct);
                etxct.SoPhieu = txtHDBan.Text;
                grvCTHDBan.DataSource = bus_pxct.ChiTietHoaDon(etxct);
                etx.SoPhieu = txtHDBan.Text;
                txtTienHangBan.DataBindings.Clear();
                txtTienHangBan.DataBindings.Add("Text", bus_px.ThongTinPhieu(etx), "TienHang");
            }
        }

        private void btnXoaMon_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa món này khỏi hóa đơn ?", "Xóa món", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                etxct.CTPXID = int.Parse(lblCTPXID.Text);
                bus_pxct.XoaMon(etxct);
                etx.SoPhieu = txtHDBan.Text;
                bus_px.CapNhatTienHang(etx);
                etxct.SoPhieu = txtHDBan.Text;
                grvCTHDBan.DataSource = bus_pxct.ChiTietHoaDon(etxct);
                etx.SoPhieu = txtHDBan.Text;
                txtTienHangBan.DataBindings.Clear();
                txtTienHangBan.DataBindings.Add("Text", bus_px.ThongTinPhieu(etx), "TienHang");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblBayGio.Text = DateTime.Now.ToLongTimeString();
            lblNgay.Text = DateTime.Today.ToShortDateString();
            //dtpGioRa.Value = DateTime.Now;
        }


        private void livPhong_Click(object sender, EventArgs e)
        {
            TenPhong= "-";
            TenPhong = livPhong.SelectedItems[0].Text;
            txtTenPhong.Text = TenPhong;
            txtHDPhong.Text = "-";
            etp.TenPhong = txtTenPhong.Text;
            txtHDPhong.Text = bus_Phong.MaHD(etp);
            etp.TenPhong = txtTenPhong.Text;
            MaPhong = int.Parse(bus_Phong.MaPhong(etp));
            //MessageBox.Show(MaPhong.ToString());
            etx.SoPhieu = txtHDPhong.Text;
            dtpGioVao.DataBindings.Clear();
            dtpGioVao.DataBindings.Add("Text", bus_px.ThongTinPhieu(etx), "BatDau");
            LoadBan();
            loadTienHat();
            khoanutPhong();
            if (dtpGioRa.Text == "")
            {
                KetThuc = false;
            }
            else
                KetThuc = true;

            
        }

        private void livPhong_ItemActivate(object sender, EventArgs e)
        {
            if (txtHDPhong.Text == "--")
            {
                etx.MaPhong = MaPhong;
                bus_px.TaoPhieuXuat(etx);
            }
            else MessageBox.Show("Phòng này đã có khách !");
            txtHDPhong.Text = "-";
            etp.TenPhong = txtTenPhong.Text;
            txtHDPhong.Text = bus_Phong.MaHD(etp);
            etp.TenPhong = txtTenPhong.Text;
            MaPhong = Int32.Parse(bus_Phong.MaPhong(etp));
            LoadBan();
            khoanutPhong();
        }

        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            etx.SoPhieu = txtHDPhong.Text;
            etx.KetThuc = DateTime.Now;
            bus_px.KetThuc_Kara(etx);
            //MessageBox.Show("Xong ketThuc");
            etx.MaPhong = MaPhong;
            etx.SoPhieu = txtHDPhong.Text;
            bus_px.TinhGioHat(etx);
            //MessageBox.Show("Xong Tinh gio");
            loadTienHat();
            btnKetThuc.Enabled = false;
            KetThuc = true;

        }

        private void btnThemMonP_Click(object sender, EventArgs e)
        {
            etxct.SoPhieu = txtHDPhong.Text;
            etxct.MaHang = Int32.Parse(lblMonP.Text);
            etxct.SoLuong = int.Parse(numSLP.Value.ToString());
            etxct.GiaXuat = Int32.Parse(txtGiaP.Text);
            bus_pxct.ThenMon(etxct);
            //MessageBox.Show("OK");
            etxct.SoPhieu = txtHDPhong.Text;
            grvCTHDP.DataSource = bus_pxct.ChiTietHoaDon(etxct);
            //MessageBox.Show("Xong CT");
            etx.SoPhieu = txtHDPhong.Text;
            txtTienHangP.DataBindings.Clear();
            txtTienHangP.DataBindings.Add("Text", bus_px.ThongTinPhieu(etx), "TienHang");
        }

        private void grvTD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblMonP.DataBindings.Clear();
            lblMonP.DataBindings.Add("Text", grvTD.DataSource,"MaHang");
            txtGiaP.DataBindings.Clear();
            txtGiaP.DataBindings.Add("Text", grvTD.DataSource,"GiaPhong");
        }

        private void txtTienHangP_TextChanged(object sender, EventArgs e)
        {
            
            txtThanhTienP.Text = (((float.Parse(txtTienHangP.Text)) + (float.Parse(txtPhuThup.Text)) + float.Parse(txtTienGio.Text)) - (float.Parse(txtTienKMP.Text))).ToString();
            txtTienHangP.Text = String.Format("{0:#,###0}", float.Parse(txtTienHangP.Text));
        }

        private void txtTienKMP_TextChanged(object sender, EventArgs e)
        {
            txtThanhTienP.Text = (((float.Parse(txtTienHangP.Text)) + (float.Parse(txtPhuThup.Text)) + float.Parse(txtTienGio.Text)) - (float.Parse(txtTienKMP.Text))).ToString();
            txtTienKMP.Text = String.Format("{0:#,###0}", float.Parse(txtTienKMP.Text));
        }

        private void txtPhuThup_TextChanged(object sender, EventArgs e)
        {
            txtThanhTienP.Text = (((float.Parse(txtTienHangP.Text)) + (float.Parse(txtPhuThup.Text)) + float.Parse(txtTienGio.Text)) - (float.Parse(txtTienKMP.Text))).ToString();
            
        }

        private void txtHDPhong_TextChanged(object sender, EventArgs e)
        {
            etxct.SoPhieu = txtHDPhong.Text;
            grvCTHDP.DataSource = bus_pxct.ChiTietHoaDon(etxct);
            etx.SoPhieu = txtHDPhong.Text;
            txtTienHangP.DataBindings.Clear();
            txtTienHangP.DataBindings.Add("Text", bus_px.ThongTinPhieu(etx), "TienHang");
        }

        private void numKMP_ValueChanged(object sender, EventArgs e)
        {
            float a, b, c;
            a = float.Parse(txtThanhTienP.Text);
            b = float.Parse(numKMP.Value.ToString());
            c = (b * a) / 100;
            txtTienKMP.Text = c.ToString();
        }

        private void txtTienGio_TextChanged(object sender, EventArgs e)
        {
            txtThanhTienP.Text = (((float.Parse(txtTienHangP.Text)) + (float.Parse(txtPhuThup.Text)) + float.Parse(txtTienGio.Text)) - (float.Parse(txtTienKMP.Text))).ToString();
            txtTienGio.Text = String.Format("{0:#,###0}", float.Parse(txtTienGio.Text));
        }

        private void txtThanhTienBan_TextChanged(object sender, EventArgs e)
        {
            txtThanhTienBan.Text = String.Format("{0:#,###0}", float.Parse(txtThanhTienBan.Text));
        }

        private void txtPhuThuBan_Leave(object sender, EventArgs e)
        {
            txtPhuThuBan.Text = String.Format("{0:#,###0}", float.Parse(txtPhuThuBan.Text));
        }

        private void btnDonBan_Click(object sender, EventArgs e)
        {
            etp.MaPhong = MaBan;
            bus_Phong.HuyBan(etp);
            grvCTHDBan.DataSource = "";
            khoanut();
            LoadBan();
        }

        private void btnTTPhong_Click(object sender, EventArgs e)
        {
            if (KetThuc == false)
            {
                MessageBox.Show("Chưa kết thúc !");
            }
            else
            {
                try
                {
                    MaHD = txtHDPhong.Text;
                    etx.SoPhieu = txtHDPhong.Text;
                    etx.PhuThu = float.Parse(txtPhuThup.Text);
                    etx.KhuyenMai = float.Parse(txtTienKMP.Text);
                    bus_px.ThanhToan_Cafe(etx);
                    etp.MaPhong = MaPhong;
                    bus_Phong.ThanhToanBan(etp);
                    khoanutPhong();
                    LoadBan();
                    if (cbInHDP.Checked)
                    {
                        Loai = "KaRa";
                        frmThanhToan_InHD _ThanhToan = new frmThanhToan_InHD();
                        _ThanhToan.ShowDialog();
                    }
                }
                catch
                {

                }
            }
        }

        private void btnHuyPhong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc hủy phòng này ?", "Hủy phòng", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    etx.SoPhieu = txtHDPhong.Text;
                    bus_px.HuyBan(etx);
                    etxct.SoPhieu = txtHDPhong.Text;
                    bus_pxct.HuyBan(etxct);
                    etp.MaPhong = MaPhong;
                    bus_Phong.HuyBan(etp);
                    LoadBan();
                    grvCTHDP.DataSource = "";
                    khoanutPhong();
                }
                catch
                {
                    MessageBox.Show("Lỗi không thể hủy Phòng");
                }
            }
        }

        private void btnDonP_Click(object sender, EventArgs e)
        {
            etp.MaPhong = MaPhong;
            bus_Phong.HuyBan(etp);
            grvCTHDP.DataSource = "";
            khoanutPhong();
            LoadBan();
        }

        private void grvNhom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblNhom.DataBindings.Clear();
            lblNhom.DataBindings.Add("Text", grvDanhMuc.DataSource, "MaNhom");
            grvTD.DataSource = bus_DanhMuc.LayThucDon("Where MaNhom='" + lblNhom.Text + "'");
        }

        private void btnThemGhiChuP_Click(object sender, EventArgs e)
        {
            if (btnThemGhiChuP.Text == "Thêm ghi chú")
            {
                txtGhiChuKara.Visible = true;
                btnThemGhiChuP.Text = "Lưu Lại";
            }
            else
            {
                if (lblID.Text == "")
                {
                    MessageBox.Show("Chọn chi tiết món muốn thêm ghi chú !");
                }
                else
                {
                    etxct.CTPXID = int.Parse(lblID.Text);
                    etxct.GhiChu = txtGhiChuKara.Text;
                    bus_pxct.ThemGhiChu(etxct);
                    txtGhiChu.Visible = false;
                    btnThemGhiChuP.Text = "Thêm ghi chú";
                    etxct.SoPhieu = txtHDPhong.Text;
                    grvCTHDP.DataSource = bus_pxct.ChiTietHoaDon(etxct);
                }
            }
        }

        private void grvCTHDP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblID.DataBindings.Clear();
            lblID.DataBindings.Add("Text", grvCTHDP.DataSource, "CTPXID");
            txtGhiChuKara.DataBindings.Clear();
            txtGhiChuKara.DataBindings.Add("Text", grvCTHDP.DataSource, "GhiChu");
        }

        private void btnXoaMonP_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa món này khỏi hóa đơn ?", "Xóa món", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                etxct.CTPXID = int.Parse(lblID.Text);
                bus_pxct.XoaMon(etxct);
                etx.SoPhieu = txtHDPhong.Text;
                bus_px.CapNhatTienHang(etx);
                etxct.SoPhieu = txtHDPhong.Text;
                grvCTHDP.DataSource = bus_pxct.ChiTietHoaDon(etxct);
                etx.SoPhieu = txtHDPhong.Text;
                txtTienHangP.DataBindings.Clear();
                txtTienHangP.DataBindings.Add("Text", bus_px.ThongTinPhieu(etx), "TienHang");
            }
        }

        private void grvTD_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (TrangThaiP == "1")
            {
                etxct.SoPhieu = txtHDPhong.Text;
                etxct.MaHang = Int32.Parse(lblMonP.Text);
                etxct.SoLuong = int.Parse(numSLP.Value.ToString());
                etxct.GiaXuat = Int32.Parse(txtGiaP.Text);
                bus_pxct.ThenMon(etxct);
                //MessageBox.Show("OK");
                etxct.SoPhieu = txtHDPhong.Text;
                grvCTHDP.DataSource = bus_pxct.ChiTietHoaDon(etxct);
                //MessageBox.Show("Xong CT");
                etx.SoPhieu = txtHDPhong.Text;
                txtTienHangP.DataBindings.Clear();
                txtTienHangP.DataBindings.Add("Text", bus_px.ThongTinPhieu(etx), "TienHang");
            }
        }

        private void txtThanhTienP_TextChanged_1(object sender, EventArgs e)
        {
            txtThanhTienP.Text = String.Format("{0:#,###0}", float.Parse(txtThanhTienP.Text));
        }

        private void txtPhuThup_Leave(object sender, EventArgs e)
        {
            txtPhuThup.Text = String.Format("{0:#,###0}", float.Parse(txtPhuThup.Text));
        }

        private void btnGhiNoBan_Click(object sender, EventArgs e)
        {
            Ban = true;
            MaHD = txtHDBan.Text;
            etp.TenPhong = txtTenBan.Text;
            MaBan =Int32.Parse( bus_Phong.MaPhong(etp));
            TienNo =float.Parse(txtThanhTienBan.Text);

            MaHD = txtHDBan.Text;
            etx.SoPhieu = txtHDBan.Text;
            etx.PhuThu = float.Parse(txtPhuThuBan.Text);
            etx.KhuyenMai = float.Parse(txtTienKM.Text);
            bus_px.ThanhToan_Cafe_No(etx);
            etp.MaPhong = MaBan;
            bus_Phong.ThanhToanBan(etp);
            khoanut();
            LoadBan();


            frmThongTinNo _TTNo = new frmThongTinNo();
            _TTNo.ShowDialog();
        }

        private void btnGhiNoP_Click(object sender, EventArgs e)
        {
            if (KetThuc)
            {
                try
                {
                    Ban = false;
                    MaHD = txtHDPhong.Text;
                    etp.TenPhong = txtTenPhong.Text;
                    MaPhong = Int32.Parse(bus_Phong.MaPhong(etp));
                    TienNo = float.Parse(txtThanhTienP.Text);

                    MaHD = txtHDPhong.Text;
                    etx.SoPhieu = txtHDPhong.Text;
                    etx.PhuThu = float.Parse(txtPhuThup.Text);
                    etx.KhuyenMai = float.Parse(txtTienKMP.Text);
                    bus_px.ThanhToan_Cafe_No(etx);
                    etp.MaPhong = MaPhong;
                    bus_Phong.ThanhToanBan(etp);
                    khoanutPhong();
                    LoadBan();

                    frmThongTinNo _TTNo = new frmThongTinNo();
                    _TTNo.ShowDialog();
                }
                catch
                {
                    MessageBox.Show("Đã xảy ra lỗi !");
                }
            }
            else
                MessageBox.Show("Chưa kết thúc !");

        }
       
        
    }
}
