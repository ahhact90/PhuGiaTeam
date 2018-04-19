using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ENTI_NhaHang;
using DAL_NhaHang;

namespace BUS_NhaHang
{
    public class BUS_PhieuNhap_CT
    {
        SQL_PhieuNhap_CT SQL = new SQL_PhieuNhap_CT();

        public void ThemDuLieu(EC_PhieuNhap_CT et)
        {
            SQL.ThemDuLieu(et);
        }
        public void SuaDuLieu(EC_PhieuNhap_CT et)
        {
            SQL.SuaDuLieu(et);
        }
        public void XoaDuLieu(EC_PhieuNhap_CT et)
        {
            SQL.XoaDuLieu(et);
        }
        public DataTable TaoBang(String DieuKien)
        {
            return SQL.TaoBang(DieuKien);
        }
        public void LuuPhieu_CT(EC_PhieuNhap_CT etpnct)
        {
            SQL.LuuPhieu_CT(etpnct);
        }
        public void HuyPhieu_CT(EC_PhieuNhap_CT etpnct)
        {
            SQL.HuyPhieu_CT(etpnct);
        }
    }
}
