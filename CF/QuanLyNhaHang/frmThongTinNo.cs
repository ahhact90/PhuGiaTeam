using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ENTI_NhaHang;
using BUS_NhaHang;
using DAL_NhaHang;

namespace QuanLyNhaHang
{
    public partial class frmThongTinNo : Form
    {
        BUS_PhieuNo bus_PhieuNo = new BUS_PhieuNo();
        EC_PhieuNo etPhieuNo = new EC_PhieuNo();
        public frmThongTinNo()
        {
            InitializeComponent();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (UCBanHang.Ban)
            {
                etPhieuNo.SoPhieu = UCBanHang.MaHD;
                etPhieuNo.SoTien = UCBanHang.TienNo;
                etPhieuNo.MaPhong = UCBanHang.MaBan;
                etPhieuNo.GhiChu = textBoxX1.Text;
                bus_PhieuNo.ThemPhieuNo_BanHang(etPhieuNo);
                this.Close();
            }
            else
            {
                etPhieuNo.SoPhieu = UCBanHang.MaHD;
                etPhieuNo.SoTien = UCBanHang.TienNo;
                etPhieuNo.MaPhong = UCBanHang.MaPhong;
                etPhieuNo.GhiChu = textBoxX1.Text;
                bus_PhieuNo.ThemPhieuNo_BanHang(etPhieuNo);
                this.Close();
            }
        }
    }
}
