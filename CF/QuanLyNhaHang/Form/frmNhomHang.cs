using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL_NhaHang;
using ENTI_NhaHang;
using BUS_NhaHang;

namespace QuanLyNhaHang
{
    public partial class frmNhomHang : Form
    {
        Boolean them;
        BUS_NhomHang bus = new BUS_NhomHang();
        EC_NhomHang ech = new EC_NhomHang();
        public frmNhomHang()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            them = true;
            txtTen.Enabled = true;
            txtTen.Text = "";
            txtMa.Enabled = true;
            txtMa.Text = "";
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;

            btnSua.Enabled = false;
            btnThem.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            them = false;
            txtTen.Enabled = true;
            txtMa.Enabled = true;
            btnLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnThem.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                ech.MaNhom = txtMa.Text;
                bus.XoaDuLieu(ech);
                MessageBox.Show("Đã xóa !");
                grvNhomHang.DataSource = bus.TaoBang("");
            }
            catch
            {
                MessageBox.Show("Đã xảy ra lỗi !");
            }
        }

        private void frmNhomHang_Load(object sender, EventArgs e)
        {
            grvNhomHang.DataSource= bus.TaoBang("");
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (them == true)
            {
                ech.MaNhom = txtMa.Text;
                ech.TenNhom = txtTen.Text;
                bus.ThemDuLieu(ech);
                grvNhomHang.DataSource = bus.TaoBang("");
                txtTen.Enabled = false;
                btnLuu.Enabled = false;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btnThem.Enabled = true;
                txtMa.Enabled = false;

            }
            else
            {
                
                ech.MaNhom = txtMa.Text;
                ech.TenNhom = txtTen.Text;
                bus.SuaDuLieu(ech);
                grvNhomHang.DataSource = bus.TaoBang("");
                txtTen.Enabled = false;
                txtMa.Enabled = false;
                btnLuu.Enabled = false;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btnThem.Enabled = true;
            }
        }

        private void grvNhomHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.DataBindings.Clear();
            txtMa.DataBindings.Add("Text",grvNhomHang.DataSource,"MaNhom");
            txtTen.DataBindings.Clear();
            txtTen.DataBindings.Add("Text",grvNhomHang.DataSource,"TenNhom");
        }
    }
}
