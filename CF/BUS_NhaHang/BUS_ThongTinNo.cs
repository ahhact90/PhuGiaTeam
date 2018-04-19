using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENTI_NhaHang;
using DAL_NhaHang;
using System.Data;

namespace BUS_NhaHang
{
    public class BUS_ThongTinNo
    {
        SQL_ThongTinNo SQL = new SQL_ThongTinNo();

        public void ThemDuLieu(EC_ThongTinNo et)
        {
            SQL.ThemDuLieu(et);
        }
        //-------- update data
        public void SuaDuLieu(EC_ThongTinNo et)
        {
            SQL.SuaDuLieu(et);
        }
        // delete data
        public void XoaDuLieu(EC_ThongTinNo et)
        {
            SQL.XoaDuLieu(et);
        }

        public DataTable TaoBang(String DieuKien)
        {
            return SQL.TaoBang(DieuKien);
        }
    }
}
