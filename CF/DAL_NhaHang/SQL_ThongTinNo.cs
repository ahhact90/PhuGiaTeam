using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENTI_NhaHang;
using System.Data;
namespace DAL_NhaHang
{
    public class SQL_ThongTinNo
    {
        ConnectData cn = new ConnectData();
        public static string SQLN;

        //===============thêm data (insert)===================
        public void ThemDuLieu(EC_ThongTinNo etn)
        {
            SQLN = @"INSERT INTO ThongTinNo (SoPhieu, NgayNo, MaPhong, NguoiNo, DaThanhToan, Phone, DiaChi, SoTien, GhiChu)
                       VALUES ('" + etn.SoPhieu + "',CONVERT(datetime,'" + etn.NgayNo + "',103)," + etn.MaPhong + ",'" + etn.NguoiNo + "',0,'" + etn.Phone + "',N'" + etn.DiaChi + "'," + etn.SoTien + ",N'" + etn.GhiChu + "')";
            cn.ThucThiSQL(SQLN);
        }

        //================ update data 
        public void SuaDuLieu(EC_ThongTinNo etn)
        {
            cn.ThucThiSQL("UPDATE ThongTinNo SET DaThanhToan=1 where IDThongTin="+etn.IDThongTin);
        }
        //================delete data
        public void XoaDuLieu(EC_ThongTinNo etn)
        {
            cn.ThucThiSQL("DELETE FROM ThongTinNo where IDThongTin="+etn.IDThongTin);
        }
        //==================== load dữ liệu --------------------
        public DataTable TaoBang(string DieuKien)
        {
            return cn.LayDuLieu("SELECT * FROM ThongTinNo "+DieuKien);
        }
    }
}
