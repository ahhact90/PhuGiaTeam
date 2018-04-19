using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Data.SqlClient;
using System.Threading;
using Microsoft.Win32;

namespace QuanLyNhaHang
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            if (KiemTraTonTaiCSDL(conn, "QLNHAHANG") == false)
            {
                Thread t = new Thread(new ThreadStart(LoadApp));
                t.Start();
                KhoiPhucCSDL(conn);
                Thread.Sleep(2500);
                InitializeComponent();
                t.Abort();
            }
            else
            {
                InitializeComponent();
            }
        }
        public static string TenDangNhap;
        public static string Quyen;
        public static string HoTen;
        public static Thread t2;
        public static Boolean DangNhap;
        public static SqlConnection conn;
        public static string DK;

        public void LoadApp()
        {
            Application.Run(new frmKhoiTao());
        }
        public void LoadLogin()
        {
            Application.Run(new frmLogin());
        }
        public  void KhoaMenu()
        {
            btnThietLap.Enabled = false;
            btnQLUser.Enabled = false;
            btnQLMayIn.Enabled = false;
            btnBanHang.Enabled = false; 
            btnDanhMuc.Enabled = false;
            btnTTNo.Enabled = false;
            btnNhapHang.Enabled = false;
            

            rbaBanHang.Enabled = false;
            rbaHeThong.Enabled = false;
            rbaBaoCao.Enabled = false;
            rbaHangHoa.Enabled = false;
            rbaNCC.Enabled = false;
            rbaNhapHang.Enabled = false;
            rbaNV.Enabled = false;
            rbaTienIch.Enabled = false;
            lblQuyen.Text = "Chưa đăng nhập  !";
            lblHoTen.Text = "Chưa đăng nhập  !";
        }

        public void MoMenu()
        {
            if (Quyen == "100")
            {
                btnThietLap.Enabled = true;
                btnQLUser.Enabled = true;
                btnQLMayIn.Enabled = true;
                btnBanHang.Enabled = true;
                btnDanhMuc.Enabled = true;
                btnTTNo.Enabled = true;
                btnNhapHang.Enabled = true;


                rbaBanHang.Enabled = true;
                rbaHeThong.Enabled = true;
                rbaBaoCao.Enabled = true;
                rbaHangHoa.Enabled = true;
                rbaNCC.Enabled = true;
                rbaNhapHang.Enabled = true;
                rbaNV.Enabled = true;
                rbaTienIch.Enabled = true;
                lblQuyen.Text = "Quản trị viên !";
                lblHoTen.Text = HoTen;
            }
            else
            {
                btnThietLap.Enabled = false;
                btnQLUser.Enabled = false;
                btnQLMayIn.Enabled = false;
                btnBanHang.Enabled = true;
                btnDanhMuc.Enabled = true;
                btnTTNo.Enabled = true;
                btnNhapHang.Enabled = true;

                rbaBanHang.Enabled = true;
                rbaHeThong.Enabled = false;
                rbaBaoCao.Enabled = true;
                rbaHangHoa.Enabled = true;
                rbaNCC.Enabled = true;
                rbaNhapHang.Enabled = true;
                rbaNV.Enabled = true;
                rbaTienIch.Enabled = true;
                lblQuyen.Text = "Nhân viên cửa hàng !";
                lblHoTen.Text = HoTen;
            }
        }
        //============================ thêm tab mới =======================
        /// <summary>
        /// 
        /// </summary>
        /// <param name="TenTab"></param>
        /// <param name="TenUSControl"></param>
        private void AddNewTab(String TenTab, UserControl TenUSControl)
        {
            foreach (TabItem tabpage in tbMain.Tabs)
                if (tabpage.Text == TenTab)
                {
                    tbMain.SelectedTab = tabpage;
                    return;
                }
            TabControlPanel newtabpanel = new DevComponents.DotNetBar.TabControlPanel();
            TabItem newtabpage = new TabItem(this.components);
            newtabpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            newtabpanel.Location = new System.Drawing.Point(0, 26);
            newtabpanel.Name = "panel" + TenTab;
            newtabpanel.Padding = new System.Windows.Forms.Padding(1);
            newtabpanel.Size = new System.Drawing.Size(1203, 384);
            newtabpanel.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            newtabpanel.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            newtabpanel.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            newtabpanel.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            newtabpanel.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            newtabpanel.Style.GradientAngle = 90;
            newtabpanel.TabIndex = 2;
            newtabpanel.TabItem = newtabpage;

            //==================================================================

            Random ra = new Random();
            newtabpage.Name = TenTab + ra.Next(100000) + ra.Next(22342);
            newtabpage.AttachedControl = newtabpanel;
            newtabpage.Text = TenTab;
            TenUSControl.Dock = DockStyle.Fill;
            newtabpanel.Controls.Add(TenUSControl);
            //=========================================================\
            tbMain.Controls.Add(newtabpanel);
            tbMain.Tabs.Add(newtabpage);
            tbMain.SelectedTab = newtabpage;

        }
        
        //------------------------ghi registry ---------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="KeyName"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        public bool DinhDangNgayThang(string KeyName, object Value)
        {
            try
            {
                RegistryKey rk = Registry.CurrentUser;
                RegistryKey sk1 = rk.CreateSubKey(@"Control Panel\International");
                sk1.SetValue(KeyName.ToUpper(), Value);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Writing registry " + KeyName.ToUpper() + e.Message);
                return false;
            }
        }
        //============================= kiểm tra sự tồn tại của CSDL =========================================================
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tmpConn"></param>
        /// <param name="databaseName"></param>
        /// <returns></returns>
        private static bool KiemTraTonTaiCSDL(SqlConnection tmpConn, string databaseName)
        {
            string sqlCreateDBQuery;
            bool result = false;

            try
            {
                tmpConn = new SqlConnection(@"Data Source=THOMAS\SQLEXPRESS;Initial Catalog=QLNHAHANG;User ID=sa;Password=123456;");

                sqlCreateDBQuery = string.Format(@"SELECT database_id FROM sys.databases WHERE Name 
		            = '{0}'", databaseName);

                using (tmpConn)
                {
                    using (SqlCommand sqlCmd = new SqlCommand(sqlCreateDBQuery, tmpConn))
                    {
                        tmpConn.Open();
                        int databaseID = (int)sqlCmd.ExecuteScalar();
                        tmpConn.Close();
                        result = (databaseID > 0);
                    }
                }
                tmpConn.Close();
            }
            catch
            {
                result = false;
            }

            return result;
        }

        //====================== khôi phục CSDL khi không tồn tại ==================================
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ketnoi"></param>
        private static void KhoiPhucCSDL( SqlConnection ketnoi)
        {
            if (KiemTraTonTaiCSDL(conn, "QLNHAHANG") == false)
            {
                try
                {
                    ketnoi = new SqlConnection(@"Data Source=.\;Initial Catalog=QLNHAHANG;Integrated Security=True;Persist Security Info=True");
                    using (ketnoi)
                    {
                        string path = @"E:\SoftWare\36 A Lan\cf3lop\cf3lop\DATABASE_28-12-14.bak";
                        string sqlRestore = "Use master Restore Database [QLNHAHANG] from disk='" + path + "'";
                        SqlCommand cmd = new SqlCommand(sqlRestore, ketnoi);
                        ketnoi.Open();
                        cmd.ExecuteNonQuery();                       
                        MessageBox.Show("Đã khôi phục cơ sở dữ liệu ! ");
                    }
                    ketnoi.Close();

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi không khôi phục được !");
                    return;
                }
            }
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            
            DinhDangNgayThang("sShortDate", "dd/MM/yyyy");
            frmLogin _Login = new frmLogin();
            _Login.ShowDialog();
            if (DangNhap)
            {
                MoMenu();
            }
            else
            {
                KhoaMenu();
            }

        }

        private void buttonItem20_Click(object sender, EventArgs e)
        {
            UCNhanVien _NhanVien = new UCNhanVien();
            AddNewTab("Thông tin nhân viên",_NhanVien);
        }

        private void buttonItem23_Click(object sender, EventArgs e)
        {
            UCHangHoa _HH = new UCHangHoa();
            AddNewTab("Danh mục hàng hóa",_HH);
        }

        private void buttonItem38_Click(object sender, EventArgs e)
        {
            frmNhaCC _NhaCC = new frmNhaCC();
            _NhaCC.ShowDialog();
        }

        private void buttonItem27_Click(object sender, EventArgs e)
        {
            UCNhapHang _NhapHang = new UCNhapHang();
            AddNewTab("Lập phiếu nhập hàng",_NhapHang);
        }

        private void buttonItem25_Click(object sender, EventArgs e)
        {
            UCBanHang _BanHang = new UCBanHang();
            AddNewTab("Quầy bán hàng",_BanHang);
        }

        private void tbMain_TabItemClose(object sender, TabStripActionEventArgs e)
        {
            tbMain.Tabs.Remove(tbMain.SelectedTab);
        }

        private void buttonItem14_Click(object sender, EventArgs e)
        {
            frmDoiMK _DoiMK = new frmDoiMK();
            _DoiMK.ShowDialog();
        }

        private void buttonItem15_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonItem16_Click(object sender, EventArgs e)
        {
            frmSaoLuu _saoLuu = new frmSaoLuu();
            _saoLuu.ShowDialog();
        }

        private void buttonItem17_Click(object sender, EventArgs e)
        {
            frmThongTinDonVi _TT = new frmThongTinDonVi();
            _TT.ShowDialog();
        }

        private void buttonItem22_Click(object sender, EventArgs e)
        {
            frmNhomHang _NhomHang = new frmNhomHang();
            _NhomHang.ShowDialog();

        }

        private void buttonItem21_Click(object sender, EventArgs e)
        {
            frmKhoHang _Kho = new frmKhoHang();
            _Kho.ShowDialog();
        }

        private void buttonItem24_Click(object sender, EventArgs e)
        {
            frmNhaCC _NhomNCC = new frmNhaCC();
            _NhomNCC.ShowDialog();
        }

        private void buttonItem39_Click(object sender, EventArgs e)
        {
            frmNhomKhach _NhomKhachHang = new frmNhomKhach();
            _NhomKhachHang.ShowDialog();
        }

        private void buttonItem40_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem19_Click(object sender, EventArgs e)
        {
            UCKhuPhongBan _KPB = new UCKhuPhongBan();
            AddNewTab("Thông tin phòng - bàn",_KPB);
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            UCBanHang _BanHang = new UCBanHang();
            AddNewTab("Quầy bán hàng", _BanHang);
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            UCHangHoa _HH = new UCHangHoa();
            AddNewTab("Danh mục hàng hóa", _HH);
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            UCNhapHang _NhapHang = new UCNhapHang();
            AddNewTab("Lập phiếu nhập hàng", _NhapHang);
        }

        private void buttonItem32_Click(object sender, EventArgs e)
        {
            UCBaoCaoThuChi _BCThuChi = new UCBaoCaoThuChi();
            AddNewTab("BÁO CÁO THU CHI",_BCThuChi);
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            UCQLPhieuNo _qlphieuno = new UCQLPhieuNo();
            AddNewTab("QL PHIẾU NỢ ", _qlphieuno);
        }

        private void buttonItem13_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muỗn thoát khỏi ứng dụng ?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            frmQLUser _QLUser = new frmQLUser();
            _QLUser.ShowDialog();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muỗn thoát khỏi ứng dụng ?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
                e.Cancel = true;
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            frmGioVang _GioVang = new frmGioVang();
            _GioVang.ShowDialog();
        }
    }
}
