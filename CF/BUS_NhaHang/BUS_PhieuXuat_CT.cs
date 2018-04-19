using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENTI_NhaHang;
using DAL_NhaHang;
using System.Data;

namespace BUS_NhaHang
{
    public class BUS_PhieuXuat_CT
    {
        SQL_PhieuXuat_CT SQL = new SQL_PhieuXuat_CT();
        public void ThenMon(EC_PhieuXuat_CT etct)
        {
            SQL.ThenMon(etct);
        }
        public DataTable ChiTietHoaDon(EC_PhieuXuat_CT etct)
        {
            return SQL.ChiTietHoaDon(etct);
        }
        public void XoaMon(EC_PhieuXuat_CT etct)
        {
            SQL.XoaMon(etct);
        }
        public void HuyBan(EC_PhieuXuat_CT etct)
        {
            SQL.HuyBan(etct);
        }
        public void ThemGhiChu(EC_PhieuXuat_CT etct)
        {
            SQL.ThemGhiChu(etct);
        }
        public DataTable In_Cafe(EC_PhieuXuat_CT etct)
        {
            return SQL.In_Cafe(etct);
        }
    }
}
