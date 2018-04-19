using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL_NhaHang;
using BUS_NhaHang;
using ENTI_NhaHang;

namespace QuanLyNhaHang
{
    public partial class UCKhuPhongBan : UserControl
    {
        Boolean them;
        EC_KhuVuc eckv = new EC_KhuVuc();
        EC_Phong ecp = new EC_Phong();
        BUS_KhuVuc buskv = new BUS_KhuVuc();
        BUS_Phong busp = new BUS_Phong();
        
        public UCKhuPhongBan()
        {
            InitializeComponent();
        }
        private void KhoaNutKV()
        {
            btnThemKV.Enabled = true;
            btnSuaKV.Enabled = true;
            btnXoaKV.Enabled = true;
            btnLuuKV.Enabled = false;

            
            txtTenKhu.Enabled = false;
            txtGhiChu.Enabled = false;
            
        }

        private void MoNutKV()
        {
            btnThemKV.Enabled = false;
            btnSuaKV.Enabled = false;
            btnXoaKV.Enabled = false;
            btnLuuKV.Enabled = true;

            txtTenKhu.Enabled = true;
            txtGhiChu.Enabled = true;
            
        }
        private void SetNull()
        {
            txtMaKhu.Text = "";
            txtTenKhu.Text = "";
            txtGhiChu.Text = "";
        }

        private void KhoaNutPhong()
        {
            btnThemPhong.Enabled = true;
            btnSuaPhong.Enabled = true;
            btnXoaP.Enabled = true;
            btnLuuPhong.Enabled = false;


            txtTenPhong.Enabled = false;
            txtGia1.Enabled = false;
            txtGia2.Enabled = false;
            comLoai.Enabled = false;

        }

        private void MoNutPhong()
        {
            btnThemPhong.Enabled = false;
            btnSuaPhong.Enabled = false;
            btnXoaP.Enabled = false;
            btnHuy.Enabled = true;
            btnLuuPhong.Enabled = true;

            txtTenPhong.Enabled = true;
            comLoai.Enabled = true;
            txtGia1.Enabled = true;
            txtGia2.Enabled = true;

        }
        private void SetNullPhong()
        {
            txtTenPhong.Text = "";
            txtGia2.Text = "";
            txtGia1.Text = "";
        }

        private void UCKhuPhongBan_Load(object sender, EventArgs e)
        {
            grvKhu.DataSource = buskv.TaoBang("");            
            KhoaNutKV();
            KhoaNutPhong();
            if (txtKhuVuc.Text != "")
                btnThemPhong.Enabled = true;
            else btnThemPhong.Enabled = false;
        }

        private void grvKhu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaKhu.DataBindings.Clear();
            txtMaKhu.DataBindings.Add("Text",grvKhu.DataSource,"MaKhu");
            txtTenKhu.DataBindings.Clear();
            txtTenKhu.DataBindings.Add("Text",grvKhu.DataSource,"TenKhu");
            txtGhiChu.DataBindings.Clear();
            txtGhiChu.DataBindings.Add("Text",grvKhu.DataSource,"GhiChu");
            txtKhuVuc.DataBindings.Clear();
            txtKhuVuc.DataBindings.Add("Text",grvKhu.DataSource,"MaKhu");
            grvPhong.DataSource = busp.TaoBang("where A.MaKhu ='" + txtMaKhu.Text + "'");
        }

        private void grvPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaPhong.DataBindings.Clear();
            txtMaPhong.DataBindings.Add("Text",grvPhong.DataSource,"MaPhong");
            txtTenPhong.DataBindings.Clear();
            txtTenPhong.DataBindings.Add("Text",grvPhong.DataSource,"TenPhong");
            txtGia1.DataBindings.Clear();
            txtGia1.DataBindings.Add("Text",grvPhong.DataSource,"Gia1");
            txtGia2.DataBindings.Clear();
            txtGia2.DataBindings.Add("Text",grvPhong.DataSource,"Gia2");
            txtKhuVuc.DataBindings.Clear();
            txtKhuVuc.DataBindings.Add("Text",grvPhong.DataSource,"MaKhu");
            
        }

        private void txtKhuVuc_TextChanged(object sender, EventArgs e)
        {
            if (txtKhuVuc.Text != "")
                btnThemPhong.Enabled = true;
            else btnThemPhong.Enabled = false;
        }

        private void btnThemKV_Click(object sender, EventArgs e)
        {
            them = true;
            txtMaKhu.Enabled = true;
            MoNutKV();
            SetNull();
        }

        private void btnSuaKV_Click(object sender, EventArgs e)
        {
            them = false;
            txtMaKhu.Enabled = false;
            MoNutKV();            
        }

        private void btnXoaKV_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa ?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    eckv.MaKhu = txtMaKhu.Text;
                    buskv.XoaDuLieu(eckv);
                    grvKhu.DataSource = buskv.TaoBang("");
                    MessageBox.Show("Đã xóa xong !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không thể xóa !"+ex.Message);
            }
        }

        private void btnLuuKV_Click(object sender, EventArgs e)
        {
            if (them == true)
            {
                try
                {
                    eckv.MaKhu = txtMaKhu.Text;
                    eckv.TenKhu = txtTenKhu.Text;
                    eckv.GhiChu = txtGhiChu.Text;
                    buskv.ThemDuLieu(eckv);
                    grvKhu.DataSource = buskv.TaoBang("");
                    KhoaNutKV();
                }
                catch
                {
                    MessageBox.Show("Có lỗi không thể thêm !");
                }
            }
            else
            {
                try
                {
                    eckv.MaKhu = txtMaKhu.Text;
                    eckv.TenKhu = txtTenKhu.Text;
                    eckv.GhiChu = txtGhiChu.Text;
                    buskv.SuaDuLieu(eckv);
                    grvKhu.DataSource = buskv.TaoBang("");
                    KhoaNutKV();
                }
                catch
                {
                    MessageBox.Show("Có lỗi không thể sửa !");
                }
            }
        }

        private void btnThemPhong_Click(object sender, EventArgs e)
        {
            them = true;
            SetNullPhong();
            MoNutPhong();

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            KhoaNutPhong();
            SetNullPhong();
            btnHuy.Enabled = false;
        }

        private void btnXoaP_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này ?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ecp.MaPhong = Int32.Parse(txtMaPhong.Text);
                    busp.XoaDuLieu(ecp);
                    MessageBox.Show("Đã xóa xong !");
                    grvPhong.DataSource = busp.TaoBang("");
                    KhoaNutPhong();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi không xóa được !");
            }
        }

        private void btnSuaPhong_Click(object sender, EventArgs e)
        {
            them = false;
            MoNutPhong();
            
        }

        private void btnLuuPhong_Click(object sender, EventArgs e)
        {
            if (them == true)
            {
                try
                {
                    ecp.TenPhong = txtTenPhong.Text;
                    if (comLoai.Text == "KARAOKE")
                    {
                        ecp.LoaiPhong = 1;
                        ecp.ImgID = 4;
                    }
                    else if (comLoai.Text == "CAFE")
                    {
                        ecp.LoaiPhong = 2;
                        ecp.ImgID = 4;
                    }
                    else if (comLoai.Text == "ẨM THỰC")
                    {
                        ecp.LoaiPhong = 3;
                        ecp.ImgID = 4;
                    }
                    ecp.TrangThai = 0;
                    ecp.MaHD = "--";
                    ecp.Gia1 = float.Parse(txtGia1.Text);
                    ecp.Gia2 = float.Parse(txtGia2.Text);
                    ecp.MaKhu = txtKhuVuc.Text;
                    busp.ThemDuLieu(ecp);
                    KhoaNutPhong();
                    grvPhong.DataSource = busp.TaoBang("where A.MaKhu ='" + txtKhuVuc.Text + "'");
                }
                catch
                {
                    MessageBox.Show("Lỗi không thể thêm !");
                }
            }
            else
            {
                try
                {
                    ecp.MaPhong = Int32.Parse(txtMaPhong.Text);
                    ecp.TenPhong = txtTenPhong.Text;
                    if (comLoai.Text == "KARAOKE")
                    {
                        ecp.LoaiPhong = 1;
                        ecp.ImgID = 4;
                    }
                    else if (comLoai.Text == "CAFE")
                    {
                        ecp.LoaiPhong = 2;
                        ecp.ImgID = 4;
                    }
                    else if (comLoai.Text == "ẨM THỰC")
                    {
                        ecp.LoaiPhong = 3;
                        ecp.ImgID = 4;
                    }
                    ecp.TrangThai = 0;
                    ecp.MaHD = "--";
                    ecp.Gia1 = float.Parse(txtGia1.Text);
                    ecp.Gia2 = float.Parse(txtGia2.Text);
                    ecp.MaKhu = txtKhuVuc.Text;
                    busp.SuaDuLieu(ecp);
                    grvPhong.DataSource = busp.TaoBang("where A.MaKhu ='" + txtKhuVuc.Text + "'");
                    KhoaNutPhong();
                }
                catch
                {
                    MessageBox.Show("Lỗi không thể sửa ! ");
                }
            }
        }
    }
}
