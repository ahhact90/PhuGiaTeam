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
    public partial class frmTimPhieuNhap : Form
    {
        BUS_PhieuNhap bus_pn = new BUS_PhieuNhap();
        EC_PhieuNhap etpn = new EC_PhieuNhap();

        BUS_PhieuNhap_CT bus_pnct = new BUS_PhieuNhap_CT();
        EC_PhieuNhap_CT etct = new EC_PhieuNhap_CT();

        BUS_NhaCungCap bus_Ncc = new BUS_NhaCungCap();
        EC_NhaCungCap etncc = new EC_NhaCungCap();

        public frmTimPhieuNhap()
        {
            InitializeComponent();
        }

        private void frmTimPhieuNhap_Load(object sender, EventArgs e)
        {
            dtpNgayLap.Value = DateTime.Today;
            cbNhaCungCap.DataSource = bus_Ncc.TaoBang("") ;
            cbNhaCungCap.DisplayMember = "TenNhaCC";
            cbNhaCungCap.ValueMember = "IDNhaCC";
        }

        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxX1.Checked)
            {
                cbNhaCungCap.Enabled = false;
            }
            else
                cbNhaCungCap.Enabled = true;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBoxX1.Checked)
                {
                    etpn.NgayNhap = dtpNgayLap.Text;

                    etpn.IDNhaCC = 0;
                    grvDSPhieu.DataSource = bus_pn.TimPhieu(etpn);
                }
                else
                {
                    etpn.NgayNhap = dtpNgayLap.Text;
                    etpn.IDNhaCC = Int32.Parse(cbNhaCungCap.SelectedValue.ToString());
                    grvDSPhieu.DataSource = bus_pn.TimPhieu(etpn);
                }
            }
            catch
            {
 
            }
        }

        private void grvDSPhieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblSoPhieu.DataBindings.Clear();
            lblSoPhieu.DataBindings.Add("Text",grvDSPhieu.DataSource,"SoPhieu");
            grvCTPhieu.DataSource= bus_pnct.TaoBang("where SoPhieu='"+lblSoPhieu.Text+"'");

        }
    }
}
