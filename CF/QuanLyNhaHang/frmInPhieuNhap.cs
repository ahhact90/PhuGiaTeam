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
    public partial class frmInPhieuNhap : Form
    {
        BUS_PhieuNhap bus_PhieuNhap = new BUS_PhieuNhap();
        EC_PhieuNhap etpn = new EC_PhieuNhap();
        BUS_NhaCungCap bus_NhaCC = new BUS_NhaCungCap();
        EC_NhaCungCap etNCC = new EC_NhaCungCap();
        public frmInPhieuNhap()
        {
            InitializeComponent();
        }

        private void frmInPhieuNhap_Load(object sender, EventArgs e)
        {
            etpn.SoPhieu = UCNhapHang.SoPhieu_Nhap;
            etNCC.IDNhaCC = UCNhapHang.IDNhaCC;
            lblTienHang.DataBindings.Clear();
            lblTienHang.DataBindings.Add("Text",bus_PhieuNhap.ThongTinPhieuNhap(etpn),"TienHang");
            lblDaTra.DataBindings.Clear();
            lblDaTra.DataBindings.Add("Text", bus_PhieuNhap.ThongTinPhieuNhap(etpn), "ThanhToan");
            lblConNo.DataBindings.Clear();
            lblConNo.DataBindings.Add("Text", bus_PhieuNhap.ThongTinPhieuNhap(etpn), "ConNo");
            lblNhaCungCap.DataBindings.Clear();
            lblNhaCungCap.DataBindings.Add("Text",bus_NhaCC.LoadNhaCungCap(etNCC),"TenNhaCC");
            
            CRT_INPhieuNhap _InPhieuNhap = new CRT_INPhieuNhap();
            _InPhieuNhap.SetDataSource(bus_PhieuNhap.InPhieuNhap(etpn));

            _InPhieuNhap.SetParameterValue("SoPhieu", UCNhapHang.SoPhieu_Nhap);
            _InPhieuNhap.SetParameterValue("TienHang",lblTienHang.Text + " VND");
            _InPhieuNhap.SetParameterValue("ThanhToan", lblDaTra.Text + " VND");
            _InPhieuNhap.SetParameterValue("ConNo", lblConNo.Text + " VND");
            _InPhieuNhap.SetParameterValue("NguoiGiao", UCNhapHang.NguoiGiao);
            _InPhieuNhap.SetParameterValue("NhaCungCap", lblNhaCungCap.Text);
            _InPhieuNhap.SetParameterValue("NguoiNhap", "ADMIN");
            RPV_PhieuNhap.ReportSource = _InPhieuNhap;
        }

    }
}
