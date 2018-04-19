using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENTI_NhaHang;
using DAL_NhaHang;
using System.Data;

namespace BUS_NhaHang
{
    public class BUS_KhuVuc
    {
        SQL_KhuVuc SQL = new SQL_KhuVuc();

        // in ssert dữ liệu ---------------
        public void ThemDuLieu(EC_KhuVuc et)
        {
            SQL.ThemDuLieu(et);
        }
        //-------- update data
        public void SuaDuLieu(EC_KhuVuc et)
        {
            SQL.SuaDuLieu(et);
        }
        // delete data
        public void XoaDuLieu(EC_KhuVuc et)
        {
            SQL.XoaDuLieu(et);
        }

        public DataTable TaoBang(String DieuKien)
        {
            return SQL.TaoBang(DieuKien);
        }

    }
}
