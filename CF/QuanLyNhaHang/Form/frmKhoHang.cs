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
    public partial class frmKhoHang : Form
    {
        Boolean them;
        EC_KhoHang eckho = new EC_KhoHang();
        BUS_KhoHang bus = new BUS_KhoHang();
        public frmKhoHang()
        {
            InitializeComponent();
        }

        private void frmKhoHang_Load(object sender, EventArgs e)
        {
            grvKho.DataSource = bus.TaoBang("");
        }

        private void grvKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaKho.DataBindings.Clear();
            txtMaKho.DataBindings.Add("text",grvKho.DataSource,"MaKho");
            txtTenKho.DataBindings.Clear();
            txtTenKho.DataBindings.Add("Text",grvKho.DataSource,"TenKho");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            them = true;
            txtTenKho.Enabled = true;
            txtTenKho.Text = "";
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            them = false;
            txtTenKho.Enabled = true;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                eckho.MaKho = Int32.Parse( txtMaKho.Text);
                bus.XoaDuLieu(eckho);
                MessageBox.Show("Đã xóa thành công !");
                grvKho.DataSource = bus.TaoBang("");

            }
            catch
            {
                MessageBox.Show("Lỗi không thể xóa !");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (them == true)
                {
                    eckho.TenKho = txtTenKho.Text;
                    bus.ThemDuLieu(eckho);

                    txtTenKho.Enabled = false;
                    btnLuu.Enabled = false;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnThem.Enabled = true;
                    grvKho.DataSource = bus.TaoBang("");
                }
                else
                {
                    eckho.MaKho = Int32.Parse(txtMaKho.Text);
                    eckho.TenKho = txtTenKho.Text;
                    bus.SuaDuLieu(eckho);

                    txtTenKho.Enabled = false;
                    btnLuu.Enabled = false;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnThem.Enabled = true;
                    grvKho.DataSource = bus.TaoBang("");
                }
            }
            catch
            {
                MessageBox.Show("Lỗi  !");
            }
        }
    }
}
