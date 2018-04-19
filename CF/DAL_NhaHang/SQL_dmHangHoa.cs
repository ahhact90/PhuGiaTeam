using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ENTI_NhaHang;

namespace DAL_NhaHang
{
    public class SQL_dmHangHoa
    {
        ConnectData cn = new ConnectData();

        public void ThemDuLieu(EC_dmHangHoa et)
        {
            cn.ThucThiSQL(@"INSERT INTO dmHangHoa (TenHang, DonViTinh, MaNhom, GiaPhong, GiaBan, GioiHanTon, GhiChu)
                          VALUES     (N'" + et.TenHang + "',N'" + et.DonViTinh + "','" + et.MaNhom + "'," + et.GiaPhong + "," + et.GiaBan + "," + et.GioiHanTon + ",N'" + et.GhiChu + "')");
        }
        public void SuaDuLieu(EC_dmHangHoa et)
        {
            cn.ThucThiSQL("UPDATE dmHangHoa SET TenHang =N'" + et.TenHang + "', DonViTinh =N'" + et.DonViTinh + "', MaNhom ='" + et.MaNhom + "', GiaPhong =" + et.GiaPhong + ", GiaBan =" + et.GiaBan + ", GioiHanTon =" + et.GioiHanTon + ", GhiChu = N'" + et.GhiChu + "' where MaHang=" + et.MaHang);
        }
        public void XoaDuLieu(EC_dmHangHoa et)
        {
            cn.ThucThiSQL("DELETE  FROM dmHangHoa where MaHang="+et.MaHang);
        }
        public DataTable TaoBang(string DieuKien)
        {
            return cn.LayDuLieu("select A.MaHang,A.TenHang,A.DonViTinh,B.TenNhom,A.GiaBan,A.GiaPhong,A.GioiHanTon,A.GhiChu from dmHangHoa A inner join NhomHang B on A.MaNhom=B.MaNhom");
        }
        public DataTable LoadComboboxNhom(string DieuKien)
        {
            return cn.LayDuLieu("SELECT * FROM NhomHang");
        }
        public DataTable LayDanhSanhNhomHang (string DieuKien)
        {
            return cn.LayDuLieu("select * from NhomHang");
        }
        public DataTable LayThucDon(string DieuKien)
        {
            return cn.LayDuLieu("select MaHang,TenHang,DonViTinh,GiaPhong,GiaBan,GhiChu from dmHangHoa " + DieuKien);
        }
        public string GioiHanTon(string DK)
        {
            return cn.LayGiaTri("SELECT GioiHanTon FROM dmHangHoa "+DK);
        }
        public string TonKho_HangHoa(EC_dmHangHoa etdm)
        {
            return cn.LayGiaTri("EXEC SPU_TonKho_HangHoa "+etdm.MaHang);
        }
        public DataTable TonKho()
        {
            return cn.LayDuLieu("select * from dbo.FCU_TonKho ()");
        }

    }
}
