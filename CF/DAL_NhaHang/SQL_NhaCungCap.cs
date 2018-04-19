using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ENTI_NhaHang;

namespace DAL_NhaHang
{
    public class SQL_NhaCungCap
    {
        ConnectData cn = new ConnectData();

        public void ThemDuLieu(EC_NhaCungCap et)
        {
            cn.ThucThiSQL(@"INSERT INTO NhaCungCap (TenNhaCC, DiaChi, Phone, Email)
                                VALUES     (N'" + et.TenNhaCC + "',N'" + et.DiaChi + "',N'" + et.Phone + "',N'" + et.Email + "')");
        }

        public void SuaDuLieu(EC_NhaCungCap et)
        {
            cn.ThucThiSQL(@"UPDATE NhaCungCap SET TenNhaCC =N'" + et.TenNhaCC + "', DiaChi =N'" + et.DiaChi + "', Phone =N'" + et.Phone + "', Email =N'" + et.Email + "' where IDNhaCC="+et.IDNhaCC);
        }
        public void XoaDuLieu(EC_NhaCungCap et)
        {
            cn.ThucThiSQL("DELETE FROM NhaCungCap where IDNhaCC="+et.IDNhaCC);
        }

        public DataTable TaoBang(string DieuKien)
        {
            return cn.LayDuLieu("SELECT * FROM NhaCungCap " + DieuKien);
        }
        public DataTable LoadNhaCungCap(EC_NhaCungCap etNCC)
        {
            return cn.LayDuLieu("SELECT * FROM NhaCungCap where IDNhaCC="+etNCC.IDNhaCC);
        }
    }
}
