using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENTI_NhaHang;
using System.Data;

namespace DAL_NhaHang
{
    public class SQL_DangNhap
    {
        ConnectData cn = new ConnectData();
        public DataTable GetLogin(EC_DangNhap etli)
        {
            return cn.LayDuLieu("SELECT * FROM DangNhap Where TaiKhoan='" + etli.TaiKhoan + "' and MatKhau= '" + etli.MatKhau + "'");
        }
        public void AddUser(EC_DangNhap etli)
        {
            cn.ThucThiSQL(@"INSERT INTO DangNhap (TaiKhoan, MatKhau, Quyen, MaNV)
                                VALUES ('"+etli.TaiKhoan+"','"+etli.MatKhau+"',"+etli.Quyen+","+etli.MaNV+")");
        }
        public void DeleteUser(EC_DangNhap etli)
        {
            cn.ThucThiSQL("DELETE FROM DangNhap where ID="+etli.ID);
        }
        public string GetQuyen(EC_DangNhap etli)
        {
            return cn.LayGiaTri("SELECT Quyen FROM DangNhap Where TaiKhoan='" + etli.TaiKhoan + "' and MatKhau= '" + etli.MatKhau + "'");
        }
        public string GetHoTen(EC_DangNhap etli)
        {
            return cn.LayGiaTri("SELECT B.HoLot+' '+B.Ten as HoTen FROM DangNhap A inner join NhanVien B on A.MaNV= B.MaNV Where TaiKhoan='" + etli.TaiKhoan + "' and MatKhau= '" + etli.MatKhau + "'");
        }

    }
}
