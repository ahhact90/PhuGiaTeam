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
using System.Data.SqlClient;

namespace QuanLyNhaHang
{
    public partial class frmLogin : Form
    {
        BUS_DangNhap bus_DangNhap = new BUS_DangNhap();
        EC_DangNhap etli = new EC_DangNhap();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            etli.TaiKhoan = txtUser.Text;
            etli.MatKhau = txtPass.Text;
            DataTable dt = bus_DangNhap.GetLogin(etli);
            
            if (dt.Rows.Count==1)
            {
                frmMain.DangNhap = true;
                frmMain.Quyen = bus_DangNhap.GetQuyen(etli);
                frmMain.HoTen = bus_DangNhap.GetHoTen(etli);
                frmMain _Main = new frmMain();
                _Main.MoMenu();
                Close();
                frmMain.DK = "0";
                
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu sai hãy kiểm tra lại !","LOGIN FAIL",MessageBoxButtons.OK,MessageBoxIcon.Error);
                frmMain.DangNhap = false;
                frmMain _Main = new frmMain();
                _Main.KhoaMenu();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muỗn thoát khỏi ứng dụng ?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

    }
}
