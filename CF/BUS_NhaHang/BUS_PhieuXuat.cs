using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ENTI_NhaHang;
using DAL_NhaHang;
using System.Data;

namespace BUS_NhaHang
{
    public class BUS_PhieuXuat
    {
        SQL_PhieuXuat SQL = new SQL_PhieuXuat();
        public void TaoPhieuXuat(EC_PhieuXuat etx)
        {
            SQL.TaoPhieuXuat(etx);
        }
        public DataTable ThongTinPhieu(EC_PhieuXuat etx)
        {
            return SQL.ThongTinPhieu(etx);
        }
        public void CapNhatTienHang(EC_PhieuXuat etx)
        {
            SQL.CapNhatTienHang(etx);
        }
        public void HuyBan(EC_PhieuXuat etx)
        {
            SQL.HuyBan(etx);
        }
        public void ThanhToan_Cafe(EC_PhieuXuat etx)
        {
            SQL.ThanhToan_Cafe(etx);
        }
        public void ThanhToan_Cafe_No(EC_PhieuXuat etx)
        {
            SQL.ThanhToan_Cafe_No(etx);
        }
        public void KetThuc_Kara(EC_PhieuXuat etx)
        {
            SQL.KetThuc_Kara(etx);
        }
        public void TinhGioHat(EC_PhieuXuat etx)
        {
            SQL.TinhGioHat(etx);
        }
        public DataTable ThongKe_In_Cafe(EC_PhieuXuat etx)
        {
            return SQL.ThongKe_In_Cafe(etx);
        }
    }
}
