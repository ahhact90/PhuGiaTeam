using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENTI_NhaHang;
using System.Data;


namespace DAL_NhaHang
{
    public class SQL_KhuVuc
    {
        ConnectData cn = new ConnectData();

        //===============thêm data (insert)===================
        public void ThemDuLieu(EC_KhuVuc etkv)
        {
            cn.ThucThiSQL("INSERT INTO KhuVuc (MaKhu, TenKhu, GhiChu) VALUES ('" + etkv.MaKhu + "',N'" + etkv.TenKhu + "',N'" + etkv.GhiChu + "')");
        }

        //================ update data 
        public void SuaDuLieu(EC_KhuVuc etkv)
        {
            cn.ThucThiSQL("UPDATE    KhuVuc SET  GhiChu = N'" + etkv.GhiChu + "', TenKhu = N'" + etkv.TenKhu + "' where MaKhu= '" + etkv.MaKhu + "'");
        }
        //================delete data
        public void XoaDuLieu(EC_KhuVuc etkv)
        {
            cn.ThucThiSQL("DELETE FROM KhuVuc where MaKhu= '" + etkv.MaKhu + "'");
        }
        //==================== load dữ liệu --------------------
        public DataTable TaoBang(string DieuKien)
        {
            return cn.LayDuLieu("SELECT * FROM KhuVuc "+DieuKien);
        }
    }
}
