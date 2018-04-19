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
    public partial class frmGioVang : Form
    {
        BUS_GioVang bus_GioVang = new BUS_GioVang();
        EC_GioVang etgv = new EC_GioVang();
        public frmGioVang()
        {
            InitializeComponent();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                etgv.BatDau = dtpBatDau.Value;
                etgv.KetThuc = dtpKetThuc.Value;                
                bus_GioVang.ThayDoiGioVang(etgv);
                MessageBox.Show("Đã thay đổi khung giờ vàng !","Đã thay đổi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                lblBatDau.DataBindings.Clear();
                lblBatDau.DataBindings.Add("Text", bus_GioVang.LayThongTinGioVang(etgv), "BatDau");
                lblKetThuc.DataBindings.Clear();
                lblKetThuc.DataBindings.Add("Text", bus_GioVang.LayThongTinGioVang(etgv), "KetThuc");
            }
            catch
            {
                MessageBox.Show("ERROR !");
            }
        }

        private void frmGioVang_Load(object sender, EventArgs e)
        {
            lblBatDau.DataBindings.Clear();
            lblBatDau.DataBindings.Add("Text", bus_GioVang.LayThongTinGioVang(etgv), "BatDau");
            lblKetThuc.DataBindings.Clear();
            lblKetThuc.DataBindings.Add("Text", bus_GioVang.LayThongTinGioVang(etgv),"KetThuc");
        }
    }
}
