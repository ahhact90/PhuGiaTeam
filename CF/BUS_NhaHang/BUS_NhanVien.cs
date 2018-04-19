using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL_NhaHang;
using ENTI_NhaHang;
using System.Data;

namespace BUS_NhaHang
{
    public class BUS_NhanVien
    {
        SQL_NhanVien SQL = new SQL_NhanVien();

        public void ThemDuLieu(EC_NhanVien et)
        {
            SQL.ThemDuLieu(et);
        }
        //-------- update data
        public void SuaDuLieu(EC_NhanVien et)
        {
            SQL.SuaDuLieu(et);
        }
        // delete data
        public void XoaDuLieu(EC_NhanVien et)
        {
            SQL.XoaDuLieu(et);
        }

        public DataTable TaoBang(String DieuKien)
        {
            return SQL.TaoBang(DieuKien);
        }
        public DataTable TaoBangCA(String DieuKien)
        {
            return SQL.TaoBangCA(DieuKien);
        }
        public void SuaCANhanVien(EC_NhanVien et)
        {
            SQL.SuaCANhanVien(et);
        }
    }
}
