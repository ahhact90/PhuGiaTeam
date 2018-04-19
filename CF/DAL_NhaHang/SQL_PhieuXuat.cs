using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ENTI_NhaHang;
using System.Data;

namespace DAL_NhaHang
{
    public class SQL_PhieuXuat
    {
        ConnectData cn = new ConnectData();
        public void TaoPhieuXuat(EC_PhieuXuat etx)
        {
            cn.ThucThiSQL("EXEC SPU_PhieuXuat_Insert "+etx.MaPhong);
        }
        public DataTable ThongTinPhieu(EC_PhieuXuat etx)
        {
            return cn.LayDuLieu("select * from PhieuXuat where SoPhieu='"+etx.SoPhieu+"'");
        }
        public void CapNhatTienHang(EC_PhieuXuat etx)
        {
            cn.ThucThiSQL("EXEC SPU_PhieuXuat_Update_TienHang '"+etx.SoPhieu+"'");
        }
        public void HuyBan(EC_PhieuXuat etx)
        {
            cn.ThucThiSQL("DELETE FROM PhieuXuat where SoPhieu='"+etx.SoPhieu+"'");
        }
        public void ThanhToan_Cafe(EC_PhieuXuat etx)
        {
            cn.ThucThiSQL("EXEC SPU_PhieuXuat_ThanhToan_CaFe '"+etx.SoPhieu+"',"+etx.PhuThu+","+etx.KhuyenMai+",1" );
        }
        public void ThanhToan_Cafe_No(EC_PhieuXuat etx)
        {
            cn.ThucThiSQL("EXEC SPU_PhieuXuat_ThanhToan_CaFe '" + etx.SoPhieu + "'," + etx.PhuThu + "," + etx.KhuyenMai + ",0");
        }
        public void KetThuc_Kara(EC_PhieuXuat etx)
        {
            cn.ThucThiSQL("Update PhieuXuat SET KetThuc =CONVERT(datetime,'"+etx.KetThuc+"',103) where SoPhieu='"+etx.SoPhieu+"'");
        }
        public void TinhGioHat(EC_PhieuXuat etx)
        {
            cn.ThucThiSQL("EXEC SPU_PhieuXuat_Update_Kara '" + etx.SoPhieu + "'," + etx.MaPhong );
        }
        public DataTable ThongKe_In_Cafe(EC_PhieuXuat etx)
        {
            return cn.LayDuLieu(@"select TienHang,TienHat,KhuyenMai,PhuThu,tongtien,DaTra,ConLai
                                from PhieuXuat where SoPhieu='" + etx.SoPhieu + "'");
        }
    }
}
