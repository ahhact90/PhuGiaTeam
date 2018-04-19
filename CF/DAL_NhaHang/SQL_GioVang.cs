using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENTI_NhaHang;
using System.Data;

namespace DAL_NhaHang
{
    public class SQL_GioVang
    {
        ConnectData cn = new ConnectData();
        public DataTable LayThongTinGioVang(EC_GioVang etv)
        {
            return cn.LayDuLieu("SELECT * FROM GioVang");
        }
        public void ThayDoiGioVang(EC_GioVang etgv)
        {
            cn.ThucThiSQL("UPDATE GioVang SET BatDau=CONVERT(time,'" + etgv.BatDau + "',103), KetThuc=CONVERT(time,'" + etgv.KetThuc + "',103)");
        }
    }
}
