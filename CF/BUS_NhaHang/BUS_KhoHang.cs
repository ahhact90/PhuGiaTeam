using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENTI_NhaHang;
using DAL_NhaHang;
using System.Data;

namespace BUS_NhaHang
{
    public class BUS_KhoHang
    {
        SQL_KhoHang SQL = new SQL_KhoHang();

        public void ThemDuLieu(EC_KhoHang et)
        {
            SQL.ThemDuLieu(et);
        }
        public void SuaDuLieu(EC_KhoHang et)
        {
            SQL.SuaDuLieu(et);
        }
        public void XoaDuLieu(EC_KhoHang et)
        {
            SQL.XoaDuLieu(et);
        }
        public DataTable TaoBang(String DieuKien)
        {
            return SQL.TaoBang(DieuKien);
        }
    }
}
