using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENTI_NhaHang;
using System.Data;

namespace DAL_NhaHang
{
    public class SQL_NhanVien
    {
        ConnectData cn = new ConnectData();

        public void ThemDuLieu(EC_NhanVien etnv)
        {
            cn.ThucThiSQL(@"INSERT INTO NhanVien (HoLot, Ten, ImgID, Gioi, NgaySinh, Phone, DiaChi, NgayVaoLam, MaCA)
                            VALUES     (N'" + etnv.HoLot + "',N'" + etnv.Ten + "'," + etnv.ImgID + ",N'" + etnv.Gioi +
                                            "', CONVERT(date,'" + etnv.NgaySinh + "',103),'" + etnv.Phone + "',N'" + etnv.DiaChi + "',CONVERT(date,'" + etnv.NgayVaoLam + "',103)," + etnv.MaCA + ")");
        }
        public void SuaDuLieu(EC_NhanVien etnv)
        {
            cn.ThucThiSQL("UPDATE NhanVien SET HoLot = N'" + etnv.HoLot + "', Ten =N'" + etnv.Ten + "', ImgID =" + etnv.ImgID+ ", Gioi =N'" + etnv.Gioi + "', NgaySinh = CONVERT(date,'" + etnv.NgaySinh + "',103), DiaChi = N'" + etnv.DiaChi
                + "', Phone ='" + etnv.Phone + "', NgayVaoLam =CONVERT(date,'" + etnv.NgayVaoLam + "',103)  where MaNV=" + etnv.MaNV);
        }
        public void XoaDuLieu(EC_NhanVien etnv)
        {
            cn.ThucThiSQL("DELETE FROM NhanVien where MaNV="+etnv.MaNV);
        }
        public DataTable TaoBang(string DieKien)
        {
            return cn.LayDuLieu("SELECT * FROM NhanVien "+DieKien);
        }

        public DataTable TaoBangCA(string DieKien)
        {
            return cn.LayDuLieu(@"select A.MaNV,A.HoLot+' '+A.Ten as HoTen,B.GhiChu,CONVERT(varchar(5),B.BatDauCA) as Tu,
                                CONVERT(varchar(5),B.KetThucCA) as Den,B.MaCa
                                 from NhanVien A inner join CALam B on A.MaCA=B.MaCa " + DieKien);
        }
        public void SuaCANhanVien(EC_NhanVien etnv)
        {
            cn.ThucThiSQL("UPDATE NhanVien SET MaCA="+etnv.MaCA +" where MaNV= "+etnv.MaNV);
        }
    }
}
