using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ENTI_NhaHang;
using DAL_NhaHang;
using BUS_NhaHang;

namespace QuanLyNhaHang
{
    public partial class frmNhaCC : Form
    {
        Boolean them;
        BUS_NhaCungCap bus = new BUS_NhaCungCap();
        EC_NhaCungCap ecncc = new EC_NhaCungCap();

        public frmNhaCC()
        {
            InitializeComponent();
        }

        void khoa()
        {
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;

            txtTen.Enabled = false;
            txtEmail.Enabled = false;
            txtPhone.Enabled = false;
            txtDiaChi.Enabled = false;
        }
        void mokhoa()
        {
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;

            txtTen.Enabled = true;
            txtEmail.Enabled = true;
            txtPhone.Enabled = true;
            txtDiaChi.Enabled = true;
        }
        void setnull()
        {
            txtTen.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
            txtPhone.Text = "";
        }
        void databinding()
        {
            txtID.DataBindings.Clear();
            txtID.DataBindings.Add("Text",grvDSNCC.DataSource,"IDNhaCC");
            txtTen.DataBindings.Clear();
            txtTen.DataBindings.Add("Text",grvDSNCC.DataSource,"TenNhaCC");
            txtEmail.DataBindings.Clear();
            txtEmail.DataBindings.Add("text",grvDSNCC.DataSource,"Email");
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("text",grvDSNCC.DataSource,"DiaChi");
            txtPhone.DataBindings.Clear();
            txtPhone.DataBindings.Add("Text",grvDSNCC.DataSource,"Phone");
        }
        void hienthi(string dieukien)
        {
            grvDSNCC.DataSource = bus.TaoBang(dieukien);
        }
        private void frmNhaCC_Load(object sender, EventArgs e)
        {
            khoa();
            hienthi("");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            them = true;
            mokhoa();
            setnull();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            them = false;
            mokhoa();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                ecncc.IDNhaCC = Int32.Parse(txtID.Text);
                bus.XoaDuLieu(ecncc);
                hienthi("");
                MessageBox.Show("Đã xóa thành công");
            }
            catch
            {
                MessageBox.Show("Lỗi khoogn thể xóa !");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (them == true)
            {
                try
                {
                    ecncc.TenNhaCC = txtTen.Text;
                    ecncc.Email = txtEmail.Text;
                    ecncc.DiaChi = txtDiaChi.Text;
                    ecncc.Phone = txtPhone.Text;
                    bus.ThemDuLieu(ecncc);
                    hienthi("");
                    khoa();
                }
                catch
                {
                    MessageBox.Show("Lỗi khoogn thể thêm !");
                }
            }
            else
            {
                try
                {
                    ecncc.IDNhaCC = Int32.Parse(txtID.Text);
                    ecncc.TenNhaCC = txtTen.Text;
                    ecncc.Email = txtEmail.Text;
                    ecncc.DiaChi = txtDiaChi.Text;
                    ecncc.Phone = txtPhone.Text;
                    bus.SuaDuLieu(ecncc);
                    hienthi("");
                    khoa();
                }
                catch
                {
                    MessageBox.Show("Lỗi khoogn thể sửa !");
                }
            }
        }

        private void grvDSNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            databinding();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            khoa();
            setnull();
        }
    }
}
