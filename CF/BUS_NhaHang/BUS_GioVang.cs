using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ENTI_NhaHang;
using DAL_NhaHang;

namespace BUS_NhaHang
{
    public class BUS_GioVang
    {
        SQL_GioVang SQL = new SQL_GioVang();
        public DataTable LayThongTinGioVang(EC_GioVang etv)
        {
            return SQL.LayThongTinGioVang(etv);
        }
        public void ThayDoiGioVang(EC_GioVang etgv)
        {
            SQL.ThayDoiGioVang(etgv);
        }
    }
}
