using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ENTI_NhaHang;
using DAL_NhaHang;

namespace BUS_NhaHang
{
    public class BUS_NhomHang
    {
        SQL_NhomHang SQL = new SQL_NhomHang();
        // in ssert dữ liệu ---------------
        public void ThemDuLieu(EC_NhomHang et)
        {
            SQL.ThemDuLieu(et);
        }
        //-------- update data
        public void SuaDuLieu(EC_NhomHang et)
        {
            SQL.SuaDuLieu(et);
        }
        // delete data
        public void XoaDuLieu(EC_NhomHang et)
        {
            SQL.XoaDuLieu(et);
        }

        public DataTable TaoBang(String DieuKien)
        {
            return SQL.TaoBang(DieuKien);
        }

    }
}
