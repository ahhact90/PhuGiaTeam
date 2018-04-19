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
    public partial class UCNhapHang : UserControl
    {
        BUS_PhieuNhap buspn = new BUS_PhieuNhap();
        BUS_PhieuNhap_CT busct = new BUS_PhieuNhap_CT();
        EC_PhieuNhap ecpn = new EC_PhieuNhap();
        EC_PhieuNhap_CT ecct = new EC_PhieuNhap_CT();
        BUS_dmHangHoa bus_dmHamng = new BUS_dmHangHoa();
        EC_dmHangHoa etdm = new EC_dmHangHoa();
        BUS_PhieuNo bus_PhieuNo = new BUS_PhieuNo();
        EC_PhieuNo etPhieuNo = new EC_PhieuNo();

        Boolean ThemPhieu; 
        float TienHang;
        public static string SoPhieu_Nhap;
        public static Int32 IDNhaCC;
        public static string NguoiGiao;
        public UCNhapHang()
        {
            InitializeComponent();
        }

        void khoa()
        {
            btnThem.Enabled = false;           
            btnXoa.Enabled = false;            
            btnLap.Enabled = true;
            btnLuuPhieu.Enabled = false;

            btnHuy.Enabled = false;
           
            btnHuyPhieu.Enabled = false;
            btnTim.Enabled = true;
            btntt.Enabled = false;
            dtpNgayNhap.Enabled = false;

            txtNguoiGiao.Enabled = false;
            comNCC.Enabled = false;
            comKho.Enabled = false;
            comHang.Enabled = false;
            txtPhone.Enabled = false;
            txtEmail.Enabled = false;
            numSL.Enabled = false;
            txtDonGia.Enabled = false;
            txtGhiChu.Enabled = false;
            txtTienTT.Enabled = false;
            
        }
        void Mokhoa()
        {
            btnThem.Enabled = true;
            
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;
            btnLap.Enabled = false;
            btnLuuPhieu.Enabled = true;
            btnSuaPhieu.Enabled = true;
            btnIn.Enabled = true;
            btnHuyPhieu.Enabled = true;
            btnTim.Enabled = false;
            btntt.Enabled = true;
            dtpNgayNhap.Enabled = true;
            dtpNgayNhap.Value = DateTime.Now;

            txtNguoiGiao.Enabled = true;
            comNCC.Enabled = true;
            comKho.Enabled = true;
            comHang.Enabled = true;
            txtPhone.Enabled = true;
            txtEmail.Enabled = true;
            numSL.Enabled = true;
            txtDonGia.Enabled = true;
            txtTienTT.Enabled = true;
            txtGhiChu.Enabled = true;
        }
        void SetNull()
        {
            txtSoPhieu.Text = "";
            txtNguoiGiao.Text = "";
            txtGhiChu.Text = "";
            comNCC.Text = "";
            txtEmail.Text = "";
            txtDC.Text = "";
            txtPhone.Text = "";
            comHang.Text = "";
            txtMaHang.Text = "";
            txtDonVi.Text = "";
            txtDonGia.Text = "1";
            txtTienHang.Text = "0";
            txtTienTT.Text = "0";
            txtConLai.Text = "0";

        }

        void DataBinding()
        {
            txtIDCT.DataBindings.Clear();
            txtIDCT.DataBindings.Add("text",grvCT.DataSource,"IDCT");
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            frmNhaCC _NCC = new frmNhaCC();
            _NCC.ShowDialog();
        }

        private void btnLap_Click(object sender, EventArgs e)
        {
            try
            {
                ThemPhieu = true;
                Mokhoa();
                SetNull();
                btnSuaPhieu.Enabled = false;
                txtSoPhieu.Text = "";
                txtSoPhieu.Text = buspn.LaySoPhieu("");
                
                comNCC.DataSource = buspn.LoadComboboxNCC("");
                comNCC.DisplayMember = "TenNhaCC";
                comNCC.ValueMember = "IDNhaCC";
                comKho.DataSource = buspn.LoadComboboxKhoHang("");
                comKho.DisplayMember = "TenKho";
                comKho.ValueMember = "MaKho";
                comHang.DataSource = buspn.LoadComboboxHangHoa("");
                comHang.DisplayMember = "TenHang";
                comHang.ValueMember = "MaHang";
                grvCT.DataSource = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi : " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UCNhapHang_Load(object sender, EventArgs e)
        {
            grvTonKho.DataSource= bus_dmHamng.TonKho();            
            khoa();
        }

        private void btnLuuPhieu_Click(object sender, EventArgs e)
        {
            try
                {
                    if (txtNguoiGiao.Text == "")
                    {
                        MessageBox.Show("Nhập tên người giao hàng !","Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        txtNguoiGiao.Focus();
                    }
                    else if (comNCC.SelectedValue.ToString() == "")
                    {
                        MessageBox.Show("Chọn nhà cung cấp !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        comNCC.Focus();
                    }
                    else if (comKho.SelectedValue.ToString() == "")
                    {
                        MessageBox.Show("Hãy chọn kho hàng !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        comKho.Focus();
                    }
                    else
                    {
                        if (Int32.Parse(txtTienHang.Text) > Int32.Parse(txtTienTT.Text))
                        {
                            if (MessageBox.Show("Chú ý phiếu này chưa thanh toán,thêm vào sổ ghi nợ ! ", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            {
                                if (ThemPhieu)
                                {
                                    etPhieuNo.SoPhieu = txtSoPhieu.Text;
                                    etPhieuNo.SoTien = Int32.Parse(txtConLai.Text);
                                    etPhieuNo.IDNhaCC = Int32.Parse(comNCC.SelectedValue.ToString());
                                    etPhieuNo.GhiChu = txtGhiChu.Text;
                                    bus_PhieuNo.ThemPhieuNo(etPhieuNo);
                                }
                                else
                                {
                                    etPhieuNo.SoPhieu = txtSoPhieu.Text;
                                    etPhieuNo.SoTien = Int32.Parse(txtConLai.Text);
                                    etPhieuNo.IDNhaCC = Int32.Parse(comNCC.SelectedValue.ToString());
                                    etPhieuNo.GhiChu = txtGhiChu.Text;
                                    bus_PhieuNo.CapNhatPhieuNo(etPhieuNo);
                                }

                                ecpn.SoPhieu = txtSoPhieu.Text;
                                ecpn.NgayNhap = dtpNgayNhap.Text;
                                ecpn.NguoiGiao = txtNguoiGiao.Text;
                                ecpn.GhiChu = txtGhiChu.Text;
                                ecpn.IDNhaCC = Int32.Parse(comNCC.SelectedValue.ToString());
                                ecpn.MaKho = Int32.Parse(comKho.SelectedValue.ToString());
                                ecpn.NguoiLap = "ADMIN";                               
                                ecpn.TienHang = float.Parse(txtTienHang.Text);
                                ecpn.ThanhToan = float.Parse(txtTienTT.Text);
                                ecpn.ConNo = float.Parse(txtTienHang.Text) - float.Parse(txtTienTT.Text);
                                ecpn.GhiChu = txtGhiChu.Text;
                                grvTonKho.DataSource = bus_dmHamng.TonKho();

                                buspn.SuaDuLieu(ecpn);
                                buspn.LuuPhieu(ecpn);
                                busct.LuuPhieu_CT(ecct);
                                btnSuaPhieu.Enabled = true;
                                khoa();
                                grvTonKho.DataSource = bus_dmHamng.TonKho();
                            }
                        }
                        else
                        {
                            ecpn.SoPhieu = txtSoPhieu.Text;
                            ecpn.NgayNhap = dtpNgayNhap.Text;
                            ecpn.NguoiGiao = txtNguoiGiao.Text;
                            ecpn.GhiChu = txtGhiChu.Text;
                            ecpn.IDNhaCC = Int32.Parse(comNCC.SelectedValue.ToString());
                            ecpn.MaKho = Int32.Parse(comKho.SelectedValue.ToString());
                            ecpn.NguoiLap = "ADMIN";
                            ecpn.TienHang = float.Parse(txtTienHang.Text);
                            ecpn.ThanhToan = float.Parse(txtTienTT.Text);
                            ecpn.ConNo = float.Parse(txtTienHang.Text) - float.Parse(txtTienTT.Text);
                            ecpn.GhiChu = txtGhiChu.Text;
                            grvTonKho.DataSource = bus_dmHamng.TonKho();
                            buspn.SuaDuLieu(ecpn);
                            buspn.LuuPhieu(ecpn);
                            busct.LuuPhieu_CT(ecct);
                            btnSuaPhieu.Enabled = true;
                            etPhieuNo.SoPhieu = txtSoPhieu.Text;
                            if (bus_PhieuNo.KiemTraPhieu(etPhieuNo) != "0")
                            {
                                etPhieuNo.SoPhieu = txtSoPhieu.Text;
                                bus_PhieuNo.XoaPhieu(etPhieuNo);
                            }
                            khoa();
                            grvTonKho.DataSource = bus_dmHamng.TonKho();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi không thể thêm được !"+ex.Message,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }

        private void btnSuaPhieu_Click(object sender, EventArgs e)
        {
            ThemPhieu = false;
            Mokhoa();
            btnSuaPhieu.Enabled = false;
            btnLuuPhieu.Enabled = true;
            
            
        }

        private void btnHuyPhieu_Click(object sender, EventArgs e)
        {
            khoa();
            SetNull();
        }

        private void comNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDC.DataBindings.Clear();
            txtDC.DataBindings.Add("text",comNCC.DataSource,"DiaChi");
            txtPhone.DataBindings.Clear();
            txtPhone.DataBindings.Add("text", comNCC.DataSource, "Phone");
            txtEmail.DataBindings.Clear();
            txtEmail.DataBindings.Add("text", comNCC.DataSource, "Email");
            txtIDNhaCC.DataBindings.Clear();
            txtIDNhaCC.DataBindings.Add("Text",comNCC.DataSource,"IDNhaCC");
            
        }

        private void comHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMaHang.DataBindings.Clear();
            txtMaHang.DataBindings.Add("text",comHang.DataSource,"MaHang");
            txtDonVi.DataBindings.Clear();
            txtDonVi.DataBindings.Add("text", comHang.DataSource, "DonViTinh");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                etdm.MaHang =Int32.Parse(txtMaHang.Text);
                string TonKho = bus_dmHamng.TonKho_HangHoa(etdm);
                string GH = bus_dmHamng.GioiHanTon("where MaHang="+txtMaHang.Text);
                TonKho = (Int32.Parse(TonKho) + numSL.Value).ToString();
                if (Int32.Parse(TonKho) <=Int32.Parse(GH))
                {
                    ecct.MaHang = Int32.Parse(txtMaHang.Text);
                    ecct.SoPhieu = txtSoPhieu.Text;
                    ecct.SLNhap = Int32.Parse(numSL.Value.ToString());
                    ecct.GiaNhap = float.Parse(txtDonGia.Text);
                    busct.ThemDuLieu(ecct);
                    grvCT.DataSource = busct.TaoBang("Where SoPhieu ='" + txtSoPhieu.Text + "'");
                    TienHang = 0;
                    for (int i = 0; i < grvCT.Rows.Count; ++i)
                    {
                        //MessageBox.Show(grvCT.Rows[i].Cells[6].Value.ToString());
                        TienHang += float.Parse(grvCT.Rows[i].Cells[6].Value.ToString());
                        txtTienHang.Text = TienHang.ToString();
                    }
                }
                else
                    MessageBox.Show("Mặt hàng này đã vượt quá giới hạn tồn kho không cần thiết phải nhập !","Vượi quá Tồn kho",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không thêm được " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grvCT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataBinding();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtIDCT.Text == "")
                MessageBox.Show("Chưa chọn hàng hóa muốn xóa !");
            else
            {
                try
                {
                    ecct.IDCT = Int32.Parse(txtIDCT.Text);
                    busct.XoaDuLieu(ecct);
                    grvCT.DataSource = busct.TaoBang("Where SoPhieu ='" + txtSoPhieu.Text + "'");
                    TienHang = 0;
                    for (int i = 0; i < grvCT.Rows.Count; ++i)
                    {
                        TienHang += float.Parse(grvCT.Rows[i].Cells[6].Value.ToString());
                        txtTienHang.Text = TienHang.ToString();
                    }
                }
                catch
                {
                    MessageBox.Show("Lỗi không thể xóa được !", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtTienTT_TextChanged(object sender, EventArgs e)
        {
            if (txtTienTT.Text == "")
            {
                txtTienTT.Text = "0";
            }
            float a = float.Parse(txtTienHang.Text);
            float b = float.Parse(txtTienTT.Text) ;
            txtConLai.Text = (a - b).ToString();

        }

        private void btntt_Click(object sender, EventArgs e)
        {
            txtTienTT.Text = txtTienHang.Text;
        }

        private void txtTienHang_TextChanged(object sender, EventArgs e)
        {
            txtConLai.Text = txtTienHang.Text;           
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            frmTimPhieuNhap _TimPN = new frmTimPhieuNhap();
            _TimPN.ShowDialog();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ecpn.SoPhieu = txtSoPhieu.Text;
            ecct.SoPhieu = txtSoPhieu.Text;
            busct.HuyPhieu_CT(ecct);
            buspn.HuyPhieu(ecpn);
            khoa();
        }

        private void txtConLai_TextChanged(object sender, EventArgs e)
        {
            if (txtNoCu.Text == "") txtNoCu.Text = "0";
            float a = float.Parse(txtNoCu.Text);
            float b = float.Parse(txtConLai.Text);
            txtNoMoi.Text = (a + b).ToString();
        }

        private void txtIDNhaCC_TextChanged(object sender, EventArgs e)
        {
            etPhieuNo.IDNhaCC = Int32.Parse(txtIDNhaCC.Text);
            txtNoCu.Text = bus_PhieuNo.ThongTinNoNhaCC(etPhieuNo);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            SoPhieu_Nhap = txtSoPhieu.Text;
            NguoiGiao = txtNguoiGiao.Text;
            IDNhaCC = Int32.Parse(comNCC.SelectedValue.ToString());
            frmInPhieuNhap _InPN = new frmInPhieuNhap();
            _InPN.ShowDialog();
        }

        private void txtNoCu_TextChanged(object sender, EventArgs e)
        {
            if (txtNoCu.Text == "")
            {
                txtNoCu.Text = "0";
            }
            else
                txtNoCu.Text = txtNoCu.Text;
        }

    }
}
