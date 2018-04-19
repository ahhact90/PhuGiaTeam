using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENTI_NhaHang;
using System.Data;
using System.Data.SqlClient;

namespace DAL_NhaHang
{
    public class SQL_PhieuNo
    {
        ConnectData cn = new ConnectData();
        public void ThemPhieuNo(EC_PhieuNo etpn)
        {
            cn.ThucThiSQL(@"INSERT INTO PhieuNo (SoPhieu, NgayLap, SoTien, IDNhaCC,Loai, GhiChu)
            VALUES  ('"+etpn.SoPhieu+"',CONVERT(datetime,GETDATE(),103),"+etpn.SoTien+","+etpn.IDNhaCC+",1,N'"+etpn.GhiChu+"')");
        }
        public void ThemPhieuNo_BanHang(EC_PhieuNo etpn)
        {
            cn.ThucThiSQL(@"INSERT INTO PhieuNo (SoPhieu, NgayLap, SoTien, MaPhong,Loai, GhiChu)
            VALUES  ('" + etpn.SoPhieu + "',CONVERT(datetime,GETDATE(),103)," + etpn.SoTien + "," + etpn.MaPhong + ",2,N'" + etpn.GhiChu + "')");
        }


        public void ThanhToanNo(EC_PhieuNo etpn)
        {
            cn.ThucThiSQL("UPDATE PhieuNo SET ThanhToan=1 where SoPhieu='"+etpn.SoPhieu+"'");
        }
        public DataTable DanhSachPhieuNo(EC_PhieuNo etpn)
        {
            return cn.LayDuLieu(@"select ROW_NUMBER() over (order by ID) as TT,SoPhieu,NgayLap,SoTien, B.TenNhaCC,B.DiaChi,B.Phone,B.Email,A.GhiChu
                                from PhieuNo A inner join NhaCungCap B on A.IDNhaCC=B.IDNhaCC where A.ThanhToan=0");
        }
        public void CapNhatPhieuNo(EC_PhieuNo etpn)
        {
            cn.ThucThiSQL(@"UPDATE PhieuNo SET SoTien="+etpn.SoTien+",IDNhaCC="+etpn.IDNhaCC+",GhiChu=N'"+etpn.GhiChu+"' where SoPhieu='"+etpn.SoPhieu+"'");
        }
        public void XoaPhieu(EC_PhieuNo etpn)
        {
            cn.ThucThiSQL("DELETE PhieuNo where SoPhieu='"+etpn.SoPhieu+"'");
        }
        public string KiemTraPhieu(EC_PhieuNo etpn)
        {
            return cn.LayGiaTri("select COUNT(*) as KQ from PhieuNo where SoPhieu='"+etpn.SoPhieu+"'");
        }
        public string ThongTinNoNhaCC(EC_PhieuNo etpn)
        {
            return cn.LayGiaTri("select SUM(SoTien) from PhieuNo where IDNhaCC="+etpn.IDNhaCC+" and ThanhToan=0");
        }
        public DataTable PhieuNo_Tim(EC_PhieuNo etpn)
        {
            return cn.LayDuLieu("EXEC SPU_PhieuNo_Tim '"+etpn.NgayLap+"', "+etpn.Loai);
        }
    }
}
