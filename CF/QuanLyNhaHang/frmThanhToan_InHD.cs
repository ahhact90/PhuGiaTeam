using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL_NhaHang;
using BUS_NhaHang;
using ENTI_NhaHang;

namespace QuanLyNhaHang
{
    public partial class frmThanhToan_InHD : Form
    {
        BUS_PhieuXuat_CT bus_pxct = new BUS_PhieuXuat_CT();
        EC_PhieuXuat_CT etct = new EC_PhieuXuat_CT();
        BUS_PhieuXuat bus_px = new BUS_PhieuXuat();
        EC_PhieuXuat etx = new EC_PhieuXuat();

        public frmThanhToan_InHD()
        {
            InitializeComponent();
        }

        private void frmThanhToan_InHD_Load(object sender, EventArgs e)
        {
            etx.SoPhieu = UCBanHang.MaHD;
            DataTable dt = new DataTable("ThongKe");
            dt = bus_px.ThongKe_In_Cafe(etx);
            TienHang.DataBindings.Clear();
            TienHang.DataBindings.Add("Text",dt,"TienHang");
            TongTien.DataBindings.Clear();
            TongTien.DataBindings.Add("Text", dt, "TongTien");
            PhuThu.DataBindings.Clear();
            PhuThu.DataBindings.Add("Text", dt, "PhuThu");
            KM.DataBindings.Clear();
            KM.DataBindings.Add("Text", dt, "KhuyenMai");
            DaTra.DataBindings.Clear();
            DaTra.DataBindings.Add("Text", dt, "DaTra");
            ConLai.DataBindings.Clear();
            ConLai.DataBindings.Add("Text", dt, "ConLai");
            TienHat.DataBindings.Clear();
            TienHat.DataBindings.Add("Text", dt, "TienHat");
            if (UCBanHang.Loai == "CaFe")
            {
                etct.SoPhieu = UCBanHang.MaHD;
                crt_InHoaDonCaFe _InHDBan = new crt_InHoaDonCaFe();
                _InHDBan.SetDataSource(bus_pxct.In_Cafe(etct));
                _InHDBan.SetParameterValue("TienHang", TienHang.Text + " VND");
                _InHDBan.SetParameterValue("TongTien", TongTien.Text + " VND");
                _InHDBan.SetParameterValue("KM", KM.Text + " VND");
                _InHDBan.SetParameterValue("DaTra", DaTra.Text + " VND");
                _InHDBan.SetParameterValue("PhuThu", PhuThu.Text + " VND");
                _InHDBan.SetParameterValue("ConLai", ConLai.Text + " VND");
                crystalReportViewer1.ReportSource = _InHDBan;
            }
            else if (UCBanHang.Loai == "KaRa")
            {
                etct.SoPhieu = UCBanHang.MaHD;
                crt_InHoaDonKara _InHDKaRa = new crt_InHoaDonKara();
                _InHDKaRa.SetDataSource(bus_pxct.In_Cafe(etct));
                _InHDKaRa.SetParameterValue("TienHang", TienHang.Text + " VND");
                _InHDKaRa.SetParameterValue("TongTien", TongTien.Text + " VND");
                _InHDKaRa.SetParameterValue("KM", KM.Text + " VND");
                _InHDKaRa.SetParameterValue("DaTra", DaTra.Text + " VND");
                _InHDKaRa.SetParameterValue("PhuThu", PhuThu.Text + " VND");
                _InHDKaRa.SetParameterValue("ConLai", ConLai.Text + " VND");
                _InHDKaRa.SetParameterValue("TienHat", TienHat.Text + " VND");
                crystalReportViewer1.ReportSource = _InHDKaRa;
            }
        }

        private void crystalReportViewer1_ReportRefresh(object source, CrystalDecisions.Windows.Forms.ViewerEventArgs e)
        {
            etx.SoPhieu = UCBanHang.MaHD;
            DataTable dt = new DataTable("ThongKe");
            dt = bus_px.ThongKe_In_Cafe(etx);
            TienHang.DataBindings.Clear();
            TienHang.DataBindings.Add("Text", dt, "TienHang");
            TongTien.DataBindings.Clear();
            TongTien.DataBindings.Add("Text", dt, "TongTien");
            etct.SoPhieu = UCBanHang.MaHD;
            crt_InHoaDonCaFe _InHDBan = new crt_InHoaDonCaFe();
            _InHDBan.SetDataSource(bus_pxct.In_Cafe(etct));
            _InHDBan.SetParameterValue("TienHang", TienHang.Text);
            _InHDBan.SetParameterValue("TongTien", TongTien.Text);
            crystalReportViewer1.ReportSource = _InHDBan;
        }         
    }
}
