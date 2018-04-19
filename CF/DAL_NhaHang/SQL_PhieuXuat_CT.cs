using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ENTI_NhaHang;
using System.Data;

namespace DAL_NhaHang
{
    public class SQL_PhieuXuat_CT
    {
        ConnectData cn = new ConnectData();
        public void ThenMon(EC_PhieuXuat_CT etct)
        {
            cn.ThucThiSQL("EXEC SPU_PhieuXuat_CT_Insert '" + etct.SoPhieu + "'," + etct.MaHang + ","+etct.GiaXuat+","+etct.SoLuong);
        }
        public DataTable ChiTietHoaDon(EC_PhieuXuat_CT etct)
        {
            return cn.LayDuLieu(@"select A.CTPXID,B.TenHang,B.DonViTinh,A.SoLuong,A.GiaXuat,A.ThanhTien,A.GhiChu
                                  from PhieuXuat_CT A inner join dmHangHoa B on A.MaHang=B.MaHang
                                  where SoPhieu='"+etct.SoPhieu+"'");
        }
        public void XoaMon(EC_PhieuXuat_CT etct)
        {
            cn.ThucThiSQL("DELETE from PhieuXuat_CT where CTPXID=" + etct.CTPXID);
        }
        public void HuyBan(EC_PhieuXuat_CT etct)
        {
            cn.ThucThiSQL("DELETE FROM PhieuXuat_CT where SoPhieu='"+etct.SoPhieu+"'");
        }
        public void ThemGhiChu(EC_PhieuXuat_CT etct)
        {
            cn.ThucThiSQL("UPDATE PhieuXuat_CT set GhiChu=N'" + etct.GhiChu + "' where CTPXID=" + etct.CTPXID);
        }
        public DataTable In_Cafe(EC_PhieuXuat_CT etct)
        {
            return cn.LayDuLieu("EXEC SPU_PhieuXuat_Cafe_Print '"+etct.SoPhieu+"'");
        }
    }
}
