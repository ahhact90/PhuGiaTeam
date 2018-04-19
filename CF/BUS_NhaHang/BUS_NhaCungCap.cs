using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ENTI_NhaHang;
using DAL_NhaHang;

namespace BUS_NhaHang
{
    public class BUS_NhaCungCap
    {
        SQL_NhaCungCap SQL = new SQL_NhaCungCap();

        public void ThemDuLieu(EC_NhaCungCap et)
        {
            SQL.ThemDuLieu(et);
        }
        public void SuaDuLieu(EC_NhaCungCap et)
        {
            SQL.SuaDuLieu(et);
        }
        public void XoaDuLieu(EC_NhaCungCap et)
        {
            SQL.XoaDuLieu(et);
        }
        public DataTable TaoBang(String DieuKien)
        {
            return SQL.TaoBang(DieuKien);
        }
        public DataTable LoadNhaCungCap(EC_NhaCungCap etNCC)
        {
            return SQL.LoadNhaCungCap(etNCC);
        }
    }
}
