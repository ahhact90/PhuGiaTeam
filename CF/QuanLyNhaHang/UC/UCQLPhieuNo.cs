using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ENTI_NhaHang;
using DAL_NhaHang;
using BUS_NhaHang;

namespace QuanLyNhaHang
{
    public partial class UCQLPhieuNo : UserControl
    {
        BUS_PhieuNo bus_PhieuNo = new BUS_PhieuNo();
        EC_PhieuNo etpn = new EC_PhieuNo();
        BUS_PhieuNhap_CT bus_PhieuNhap_ct = new BUS_PhieuNhap_CT();
        EC_PhieuNhap_CT etpnct = new EC_PhieuNhap_CT();
        public UCQLPhieuNo()
        {
            InitializeComponent();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (cbLoai.SelectedIndex == 0)
            {
                etpn.NgayLap = dtpNgayLap.Value;
                etpn.Loai = 0;
                grvDS.DataSource = bus_PhieuNo.PhieuNo_Tim(etpn);
                
            }
            else if (cbLoai.SelectedIndex == 1)
            {
                etpn.NgayLap = dtpNgayLap.Value;
                etpn.Loai = 1;
                grvDS.DataSource = bus_PhieuNo.PhieuNo_Tim(etpn);
            }
            else if (cbLoai.SelectedIndex == 2)
            {
                etpn.NgayLap = dtpNgayLap.Value;
                etpn.Loai = 2;
                grvDS.DataSource = bus_PhieuNo.PhieuNo_Tim(etpn);
            }
        }

        private void UCQLPhieuNo_Load(object sender, EventArgs e)
        {
            dtpNgayLap.Value = DateTime.Today;
        }

        private void grvDS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblSoPhieu.DataBindings.Clear();
            lblSoPhieu.DataBindings.Add("Text",grvDS.DataSource,"SoPhieu");
            grvCT.DataSource = bus_PhieuNhap_ct.TaoBang("where sophieu='"+lblSoPhieu.Text+"'");
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (lblSoPhieu.Text == "")
            {
                MessageBox.Show("Hãy chọn phiều muốn thanh toán !");
            }
            else 
            {
                etpn.SoPhieu = lblSoPhieu.Text;
                bus_PhieuNo.ThanhToanNo(etpn);
                etpn.NgayLap = dtpNgayLap.Value;
                etpn.Loai = 0;
                grvDS.DataSource = bus_PhieuNo.PhieuNo_Tim(etpn);
            }
        }
    }
}
