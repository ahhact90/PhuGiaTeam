using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENTI_NhaHang;
using System.Data;

namespace DAL_NhaHang
{
    public class SQL_PhieuNhap_CT
    {
        ConnectData cn = new ConnectData();
        public void ThemDuLieu(EC_PhieuNhap_CT et)
        {
            cn.ThucThiSQL(@"EXEC SPU_PhieuNhapCT_Insert '" + et.SoPhieu + "'," + et.MaHang + "," + et.SLNhap + "," + et.GiaNhap );
        }

        public void SuaDuLieu(EC_PhieuNhap_CT et)
        {
            cn.ThucThiSQL("");
        }
        public void XoaDuLieu(EC_PhieuNhap_CT et)
        {
            cn.ThucThiSQL("DELETE FROM PhieuNhapHang_CT where IDCT=" + et.IDCT);
        }

        public DataTable TaoBang(string DieuKien)
        {
            return cn.LayDuLieu("select A.IDCT,A.MaHang,B.TenHang,B.DonViTinh,A.GiaNhap,A.SLNhap,A.ThanhTien from PhieuNhapHang_CT A inner join dmHangHoa B on A.MaHang=B.MaHang " + DieuKien);
        }
        public void LuuPhieu_CT(EC_PhieuNhap_CT etpnct)
        {
            cn.ThucThiSQL("UPDATE PhieuNhapHang_CT Set HieuLuc=1 where SoPhieu='" + etpnct.SoPhieu + "'");
        }
        public void HuyPhieu_CT(EC_PhieuNhap_CT etpnct)
        {
            cn.ThucThiSQL("UPDATE PhieuNhapHang_CT Set HieuLuc=0 where SoPhieu='" + etpnct.SoPhieu + "'");
        }
    }
}
