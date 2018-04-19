using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ENTI_NhaHang;

namespace DAL_NhaHang
{
    public class SQL_PhieuNhap
    {
        ConnectData cn = new ConnectData();
        public void ThemDuLieu(EC_PhieuNhap et)
        {
            cn.ThucThiSQL(@"");
        }

        public void SuaDuLieu(EC_PhieuNhap et)
        {
            cn.ThucThiSQL(@"UPDATE  PhieuNhapHang SET MaKho ="+et.MaKho+", IDNhaCC ="+et.IDNhaCC+", NgayNhap ='"+et.NgayNhap+"', NguoiNhap =N'"+et.NguoiLap+"', NguoiGiao =N'"+et.NguoiGiao+"',TienHang ="+et.TienHang+", ThanhToan ="+et.ThanhToan+", ConNo ="+et.ConNo+", GhiChu =N'"+et.GhiChu+"' where SoPhieu='"+et.SoPhieu+"'");
        }
        public void XoaDuLieu(EC_PhieuNhap et)
        {
            cn.ThucThiSQL("DELETE FROM PhieuNhapHang where SoPhieu='" + et.SoPhieu+"'");
        }

        public string TaoPhieu(string DieuKien)
        {
            return cn.LayGiaTri("SPU_PhieuNhap_Insert " + DieuKien);
        }
        public DataTable LoadNhaCungCap(string DieuKien)
        {
            return cn.LayDuLieu("SELECT * FROM NhaCungCap " + DieuKien);
        }

        public DataTable LoadNhaKhoHang(string DieuKien)
        {
            return cn.LayDuLieu("SELECT * FROM KhoHang " + DieuKien);
        }
        public DataTable LoadComboboxNCC(string DieuKien)
        {
            return cn.LayDuLieu("SELECT * FROM NhaCungCap");
        }
        public DataTable LoadComboboxKhoHang(string DieuKien)
        {
            return cn.LayDuLieu("SELECT * FROM KhoHang");
        }
        public DataTable LoadComboboxHangHoa(string DieuKien)
        {
            return cn.LayDuLieu("SELECT * FROM dmHangHoa");
        }
        public DataTable TimPhieu(EC_PhieuNhap etpn)
        {
            return cn.LayDuLieu("EXEC SPU_TimPhieu_Nhap '"+etpn.NgayNhap+"',"+etpn.IDNhaCC);
        }
        public void LuuPhieu(EC_PhieuNhap etpn)
        {
            cn.ThucThiSQL("UPDATE PhieuNhapHang Set HieuLuc=1 where SoPhieu='"+etpn.SoPhieu+"'");
        }
        public void HuyPhieu(EC_PhieuNhap etpn)
        {
            cn.ThucThiSQL("UPDATE PhieuNhapHang Set HieuLuc=0 where SoPhieu='" + etpn.SoPhieu + "'");
        }
        public DataTable InPhieuNhap(EC_PhieuNhap etpn)
        {
            return cn.LayDuLieu("EXEC SPU_PhieuNhap_Print '"+etpn.SoPhieu+"'");
        }
        public DataTable ThongTinPhieuNhap(EC_PhieuNhap etpn)
        {
            return cn.LayDuLieu("SELECT * FROM PhieuNhapHang Where SoPhieu='"+etpn.SoPhieu+"'");
        }
    }
}
