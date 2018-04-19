using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENTI_NhaHang;
using System.Data;

namespace DAL_NhaHang
{
    public class SQL_NhomHang
    {
        ConnectData cn = new ConnectData();

        public void ThemDuLieu(EC_NhomHang et)
        {
            cn.ThucThiSQL("INSERT INTO NhomHang (MaNhom,TenNhom) VALUES (N'" + et.MaNhom + "',N'" + et.TenNhom + "')");
        }

        public void SuaDuLieu(EC_NhomHang et)
        {
            cn.ThucThiSQL("UPDATE NhomHang SET TenNhom=N'" + et.TenNhom + "',MaNhom ='"+et.MaNhom+"' where MaNhom="+ et.MaNhom);
        }
        public void XoaDuLieu(EC_NhomHang et)
        {
            cn.ThucThiSQL("DELETE FROM NhomHang where MaNhom ="+et.MaNhom);
        }

        public DataTable TaoBang(string DieuKien)
        {
            return cn.LayDuLieu("SELECT * FROM NhomHang " + DieuKien);
        }
    }
}
