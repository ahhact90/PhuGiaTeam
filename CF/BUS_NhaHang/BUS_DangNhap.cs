using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENTI_NhaHang;
using DAL_NhaHang;
using System.Data;

namespace BUS_NhaHang
{
    public class BUS_DangNhap
    {
        SQL_DangNhap SQL = new SQL_DangNhap();
        public DataTable GetLogin (EC_DangNhap etli)
        {
            return SQL.GetLogin(etli);
        }
        public void AddUser(EC_DangNhap etli)
        {
            SQL.AddUser(etli);
        }
        public void DeleteUser(EC_DangNhap etli)
        {
            SQL.DeleteUser(etli);
        }
        public string GetQuyen(EC_DangNhap etli)
        {
            return SQL.GetQuyen(etli);
        }
        public string GetHoTen(EC_DangNhap etli)
        {
            return SQL.GetHoTen(etli);
        }
    }
}
