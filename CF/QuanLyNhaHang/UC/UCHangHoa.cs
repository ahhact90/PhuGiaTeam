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
    public partial class UCHangHoa : UserControl
    {
        Boolean them;
        BUS_dmHangHoa bus = new BUS_dmHangHoa();
        EC_dmHangHoa ecdmh = new EC_dmHangHoa();

        public UCHangHoa()
        {
            InitializeComponent();
        }

        void KhoaNut()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;

            txtTen.Enabled = false;
            txtDonVi.Enabled = false;
            txtGhiChu.Enabled = false;
            txtGiaBan.Enabled = false;
            txtGiaPhong.Enabled = false;
            comNhom.Enabled = false;
            txtGHTon.Enabled = false;
        }
        void MoNut()
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            txtTen.Enabled = true;
            txtDonVi.Enabled = true;
            txtGhiChu.Enabled = true;
            txtGiaBan.Enabled = true;
            txtGiaPhong.Enabled = true;
            comNhom.Enabled = true;
            txtGHTon.Enabled = true;
        }
        void SetNull()
        {
            txtTen.Text = "";
            txtDonVi.Text = "";
            txtGiaBan.Text = "";
            txtGiaPhong.Text = "";
            comNhom.Text = "";
            txtGHTon.Text = "";
            txtGhiChu.Text = "";
        }
        void HienThi(string DieuKien)
        {
            grvHH.DataSource =bus.TaoBang(DieuKien);
        }

        private void UCHangHoa_Load(object sender, EventArgs e)
        {
            KhoaNut();
            HienThi("");
            comNhom.DataSource = bus.LoadComboboxNhom("");
            comNhom.DisplayMember = "TenNhom";
            comNhom.ValueMember = "MaNhom";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            them = true;
            MoNut();
            SetNull();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            KhoaNut();
        }

        private void grvHH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.DataBindings.Clear();
            txtMa.DataBindings.Add("Text",grvHH.DataSource,"MaHang");
            comNhom.DataBindings.Clear();
            comNhom.DataBindings.Add("Text",grvHH.DataSource,"TenNhom");
            txtTen.DataBindings.Clear();
            txtTen.DataBindings.Add("Text",grvHH.DataSource,"TenHang");
            txtDonVi.DataBindings.Clear();
            txtDonVi.DataBindings.Add("Text", grvHH.DataSource, "DonViTinh");
            txtGiaPhong.DataBindings.Clear();
            txtGiaPhong.DataBindings.Add("Text", grvHH.DataSource, "GiaPhong");
            txtGiaBan.DataBindings.Clear();
            txtGiaBan.DataBindings.Add("Text", grvHH.DataSource, "GiaBan");
            txtGHTon.DataBindings.Clear();
            txtGHTon.DataBindings.Add("Text", grvHH.DataSource, "GioiHanTon");
            txtGhiChu.DataBindings.Clear();
            txtGhiChu.DataBindings.Add("Text", grvHH.DataSource, "GhiChu");
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (them == true)
            {
                try
                {
                    
                    ecdmh.MaNhom = comNhom.SelectedValue.ToString();
                    ecdmh.TenHang = txtTen.Text;
                    ecdmh.DonViTinh = txtDonVi.Text;
                    ecdmh.GiaBan = float.Parse( txtGiaBan.Text);
                    ecdmh.GiaPhong = float.Parse( txtGiaPhong.Text);
                    ecdmh.GioiHanTon = Int32.Parse( txtGHTon.Text);
                    ecdmh.GhiChu = txtGhiChu.Text;
                    bus.ThemDuLieu(ecdmh);
                    HienThi("");
                    KhoaNut();
                }
                catch
                {
                    MessageBox.Show("Lỗi không thêm được !" );
                }
                
            }
            else
            {
                try
                {
                    ecdmh.MaHang = Int32.Parse(txtMa.Text);
                    ecdmh.MaNhom = comNhom.SelectedValue.ToString();
                    ecdmh.TenHang = txtTen.Text;
                    ecdmh.DonViTinh = txtDonVi.Text;
                    ecdmh.GiaBan = float.Parse(txtGiaBan.Text);
                    ecdmh.GiaPhong = float.Parse(txtGiaPhong.Text);
                    ecdmh.GioiHanTon = Int32.Parse(txtGHTon.Text);
                    ecdmh.GhiChu = txtGhiChu.Text;
                    bus.SuaDuLieu(ecdmh);
                    HienThi("");
                    KhoaNut();
                }
                catch 
                {
                    MessageBox.Show("Lỗi không sửa được !");
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc xóa danh mục này ?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ecdmh.MaHang = Int32.Parse(txtMa.Text);
                    bus.XoaDuLieu(ecdmh);
                    MessageBox.Show("Đã xóa thành công !");
                    HienThi("");
                }
            }
            catch
            {
                MessageBox.Show("Không xóa  được");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            them = false;
            MoNut();
        }
    }
}
