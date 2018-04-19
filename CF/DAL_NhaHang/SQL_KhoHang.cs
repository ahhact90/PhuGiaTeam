using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ENTI_NhaHang;

namespace DAL_NhaHang
{
    public class SQL_KhoHang
    {
        ConnectData cn = new ConnectData();

        public void ThemDuLieu (EC_KhoHang etkho)
        {
            cn.ThucThiSQL("INSERT INTO KhoHang (TenKho) VALUES (N'"+etkho.TenKho+"')");
        }

        public void SuaDuLieu(EC_KhoHang etkho)
        {
            cn.ThucThiSQL("UPDATE KhoHang SET TenKho =N'" + etkho.TenKho + "' where MaKho="+ etkho.MaKho);
        }
        public void XoaDuLieu(EC_KhoHang etkho)
        {
            cn.ThucThiSQL("DELETE FROM KhoHang where MaKho ="+etkho.MaKho);
        }

        public DataTable TaoBang(string DieuKien)
        {
            return cn.LayDuLieu("SELECT * FROM KhoHang "+DieuKien);
        }
    }
}
