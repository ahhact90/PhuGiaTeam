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

namespace QuanLyNhaHang
{
    public partial class UCNhanVien : UserControl
    {
        Boolean them;
        EC_NhanVien ecnv = new EC_NhanVien();
        BUS_NhanVien Busnv = new BUS_NhanVien();


        public UCNhanVien()
        {
            InitializeComponent();
        }

        void KhoaNV()
        {
            btnThemNV.Enabled = true;
            btnSuaNV.Enabled = true;
            btnXoaNV.Enabled = true;
            btnHuy.Enabled = false;
            btnLuuNV.Enabled = false;

            txtMaNV.Enabled = false;
            txtHoLot.Enabled = false;
            txtTenNV.Enabled = false;
            txtPhone.Enabled = false;
            dtpNgSinh.Enabled = false;
            dtpNgayVaoLam.Enabled = false;
            comGioi.Enabled = false;
            txtdirAnh.Enabled = false;
            txtDiaChi.Enabled = false;
            btnChon.Enabled = false;
        }


        void MoKhoaNV()
        {
            btnThemNV.Enabled = false;
            btnSuaNV.Enabled = false;
            btnXoaNV.Enabled = false;
            btnHuy.Enabled = true;
            btnLuuNV.Enabled = true;

           
            txtHoLot.Enabled = true;
            txtTenNV.Enabled = true;
            txtPhone.Enabled = true;
            dtpNgSinh.Enabled = true;
            dtpNgayVaoLam.Enabled = true;
            comGioi.Enabled = true;
            
            txtDiaChi.Enabled = true;
            btnChon.Enabled = true;
            pibHinhAnh.ImageLocation = "";

        }

        void SetNull()
        {

            
            txtHoLot.Text = "";
            txtTen.Text = "";
            txtPhone.Text = "";
            
            txtdirAnh.Text = "";
            txtDiaChi.Text = "";
            
            pibHinhAnh.ImageLocation = "";

        }
        void HienThi(String DieuKien)
        {
            grvDSNV.DataSource = Busnv.TaoBang(""+ DieuKien);
            grvCA.DataSource = Busnv.TaoBangCA(""+DieuKien);
        }
        private void UCNhanVien_Load(object sender, EventArgs e)
        {
            HienThi("");
            KhoaNV();
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            them = true;
            MoKhoaNV();
            SetNull();
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            MoKhoaNV();
            them = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            KhoaNV();
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            OpenFileDialog path = new OpenFileDialog();
            path.Filter = path.Filter = "File ảnh(*.png)|*.png|All File (*.*)|*.*";
            path.FilterIndex = 0;
            path.RestoreDirectory = true;
            if (path.ShowDialog() == DialogResult.OK)
            {
                pibHinhAnh.ImageLocation = path.FileName;
                txtdirAnh.Text = path.FileName;
            }
        }

        private void btnLuuNV_Click(object sender, EventArgs e)
        {
            if (them == true)
            {
                try
                {
                    ecnv.Ten = txtTenNV.Text;
                    ecnv.HoLot = txtHoLot.Text;
                    ecnv.ImgID = 2;
                    ecnv.Gioi = comGioi.Text;
                    ecnv.NgaySinh = dtpNgSinh.Value;
                    ecnv.NgayVaoLam = dtpNgayVaoLam.Value;
                    ecnv.DiaChi = txtDiaChi.Text;
                    ecnv.Phone = txtPhone.Text;
                    ecnv.MaCA = 1;
                    Busnv.ThemDuLieu(ecnv);
                    HienThi("");
                    KhoaNV();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi không thể thêm !" + ex.Message);
                }
            }
            else
            {
                try
                {
                    ecnv.MaNV = txtMaNV.Text;
                    ecnv.Ten = txtTenNV.Text;
                    ecnv.HoLot = txtHoLot.Text;
                    ecnv.ImgID = 2;
                    ecnv.Gioi = comGioi.Text;
                    ecnv.NgaySinh = dtpNgSinh.Value;
                    ecnv.NgayVaoLam = dtpNgayVaoLam.Value;
                    ecnv.DiaChi = txtDiaChi.Text;
                    ecnv.Phone = txtPhone.Text;
                    ecnv.MaCA = 1;
                    Busnv.SuaDuLieu(ecnv);
                    HienThi("");
                    KhoaNV();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi không thể Sửa !" + ex.Message);
                }
            }
        }

        private void grvDSNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNV.DataBindings.Clear();
            txtMaNV.DataBindings.Add("Text",grvDSNV.DataSource,"MaNV");
            txtHoLot.DataBindings.Clear();
            txtHoLot.DataBindings.Add("Text",grvDSNV.DataSource,"HoLot");
            txtTenNV.DataBindings.Clear();
            txtTenNV.DataBindings.Add("Text",grvDSNV.DataSource,"Ten");
            comGioi.DataBindings.Clear();
            comGioi.DataBindings.Add("Text",grvDSNV.DataSource,"Gioi");
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text",grvDSNV.DataSource,"DiaChi");
            txtPhone.DataBindings.Clear();
            txtPhone.DataBindings.Add("Text",grvDSNV.DataSource,"Phone");
            dtpNgSinh.DataBindings.Clear();
            dtpNgSinh.DataBindings.Add("Text",grvDSNV.DataSource,"NgaySinh");
            dtpNgayVaoLam.DataBindings.Clear();
            dtpNgayVaoLam.DataBindings.Add("Text",grvDSNV.DataSource,"NgayVaoLam");
        }

        private void grvCA_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNVCA.DataBindings.Clear();
            txtMaNVCA.DataBindings.Add("Text",grvCA.DataSource,"MaNV");
            txtTen.DataBindings.Clear();
            txtTen.DataBindings.Add("Text",grvCA.DataSource,"HoTen");
            comCA.DataBindings.Clear();
            comCA.DataBindings.Add("Text",grvCA.DataSource,"GhiChu");
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            comCA.Enabled = true;
            btnLuuCA.Enabled = true;
            btnHuyCA.Enabled = true;
        }

        private void btnLuuCA_Click(object sender, EventArgs e)
        {
            try
            {
                ecnv.MaNV = txtMaNVCA.Text;
                if (comCA.Text == " CA Sáng")
                    ecnv.MaCA = 1;
                else if (comCA.Text == "CA trưa chiều")
                    ecnv.MaCA = 2;
                else if (comCA.Text == "CA tối")
                    ecnv.MaCA = 3;
                Busnv.SuaCANhanVien(ecnv);
                HienThi("");
                MessageBox.Show("Đã cập nhật thành công");
                btnCapNhat.Enabled = true;
                btnLuuCA.Enabled = false;
                btnHuyCA.Enabled = false;
                comCA.Enabled = false;
            }
            catch
            {
                MessageBox.Show("Lỗi không thể sửa được !");
            }
        }

        private void btnHuyCA_Click(object sender, EventArgs e)
        {
            btnHuyCA.Enabled = false;
            btnCapNhat.Enabled = true;
            btnLuuCA.Enabled = false;
            txtTen.Enabled = false;
            comCA.Enabled = false;
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc xóa nhân viên này ?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    ecnv.MaNV = txtMaNV.Text;
                    Busnv.XoaDuLieu(ecnv);
                    MessageBox.Show("Đã xóa thành công");
                    HienThi("");
                }
                catch
                {
                    MessageBox.Show("Không xóa được nhân viên này !");
                }
            }
        }
    }
}
