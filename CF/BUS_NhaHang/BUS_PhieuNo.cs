using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENTI_NhaHang;
using DAL_NhaHang;
using System.Data;

namespace BUS_NhaHang
{
    public class BUS_PhieuNo
    {
        SQL_PhieuNo SQL = new SQL_PhieuNo();
        public void ThemPhieuNo(EC_PhieuNo etpn)
        {
            SQL.ThemPhieuNo(etpn);
        }
        public void ThemPhieuNo_BanHang(EC_PhieuNo etpn)
        {
            SQL.ThemPhieuNo_BanHang(etpn);
        }
        public void ThanhToanNo(EC_PhieuNo etpn)
        {
            SQL.ThanhToanNo(etpn);
        }
        public DataTable DanhSachPhieuNo(EC_PhieuNo etpn)
        {
            return SQL.DanhSachPhieuNo(etpn);
        }
        public void CapNhatPhieuNo(EC_PhieuNo etpn)
        {
            SQL.CapNhatPhieuNo(etpn);
        }
        public void XoaPhieu(EC_PhieuNo etpn)
        {
            SQL.XoaPhieu(etpn);
        }
        public string KiemTraPhieu(EC_PhieuNo etpn)
        {
            return SQL.KiemTraPhieu(etpn);
        }
        public string ThongTinNoNhaCC(EC_PhieuNo etpn)
        {
            return SQL.ThongTinNoNhaCC(etpn);
        }
        public DataTable PhieuNo_Tim(EC_PhieuNo etpn)
        {
            return SQL.PhieuNo_Tim(etpn);
        }
    }
}
