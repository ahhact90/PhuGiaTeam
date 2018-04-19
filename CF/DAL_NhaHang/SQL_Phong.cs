using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ENTI_NhaHang;

namespace DAL_NhaHang
{
    public class SQL_Phong
    {
        ConnectData cn = new ConnectData();

        //===============thêm data (insert)===================
        public void ThemDuLieu(EC_Phong etp)
        {
            cn.ThucThiSQL(@"INSERT INTO Phong (TenPhong, LoaiPhong, ImgID, TrangThai, MaHD, Gia1, MaKhu, Gia2)
            VALUES     (N'" + etp.TenPhong + "'," + etp.LoaiPhong + "," + etp.ImgID + "," + etp.TrangThai + ",'" + etp.MaHD + "'," + etp.Gia1 + ",'" + etp.MaKhu + "'," + etp.Gia2 + ")");
        }

        //================ update data 
        public void SuaDuLieu(EC_Phong etp)
        {
            cn.ThucThiSQL("UPDATE Phong SET TenPhong =N'" + etp.TenPhong + "', LoaiPhong =" + etp.LoaiPhong + ", TrangThai =" + etp.TrangThai + ", MaHD ='" + etp.MaHD + "', MaKhu ='" + etp.MaKhu + "', Gia1 =" + etp.Gia1 + ", Gia2 =" + etp.Gia2 + ", ImgID =" + etp.ImgID + " where MaPhong="+etp.MaPhong);
        }
        //================delete data
        public void XoaDuLieu(EC_Phong etp)
        {
            cn.ThucThiSQL("DELETE FROM Phong where MaPhong=" + etp.MaPhong);
        }
        //==================== load dữ liệu --------------------
        public DataTable TaoBang(string DieuKien)
        {
            return cn.LayDuLieu(@"select  ROW_NUMBER() over (order by A.LoaiPhong) as TT,A.MaPhong,A.TenPhong,A.LoaiPhong,B.TenKhu,A.Gia1,A.Gia2,B.GhiChu,A.MaKhu 
                                    from Phong A inner join KhuVuc B on A.MaKhu=B.MaKhu " + DieuKien);
        }
        public string MaHD(EC_Phong et)
        {
            return cn.LayGiaTri("select MaHD from Phong where TenPhong=N'"+et.TenPhong+"'");
        }
        public string MaPhong(EC_Phong et)
        {
            return cn.LayGiaTri("select MaPhong from Phong where TenPhong=N'" + et.TenPhong + "'");
        }
        public DataTable LoadPhong(string DieuKien)
        {
            return cn.LayDuLieu("select A.MaPhong,A.TenPhong,B.HinhAnh,A.LoaiPhong from Phong A inner join HinhAnh B on A.ImgID=B.ImgID "+DieuKien);
        }
        public string LoadTrangThai(EC_Phong et)
        {
            return cn.LayGiaTri("SELECT TrangThai from phong where MaPhong="+et.MaPhong);
        }
        public void HuyBan(EC_Phong et)
        {
            cn.ThucThiSQL("UPDATE Phong SET TrangThai=0,ImgID=4,MaHD='--' where MaPhong="+et.MaPhong);
        }
        public void ThanhToanBan(EC_Phong et)
        {
            cn.ThucThiSQL("UPDATE Phong Set TrangThai =2,ImgID=3 where MaPhong ="+et.MaPhong);
        }
    }
}
