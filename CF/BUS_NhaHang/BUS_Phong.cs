using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL_NhaHang;
using ENTI_NhaHang;
using System.Data;

namespace BUS_NhaHang
{
    public class BUS_Phong
    {
        SQL_Phong SQL = new SQL_Phong();

        public void ThemDuLieu(EC_Phong et)
        {
            SQL.ThemDuLieu(et);
        }
        //-------- update data
        public void SuaDuLieu(EC_Phong et)
        {
            SQL.SuaDuLieu(et);
        }
        // delete data
        public void XoaDuLieu(EC_Phong et)
        {
            SQL.XoaDuLieu(et);
        }

        public DataTable TaoBang(String DieuKien)
        {
            return SQL.TaoBang(DieuKien);
        }
        public string MaHD(EC_Phong et)
        {
            return SQL.MaHD(et);
        }
        public string MaPhong(EC_Phong et)
        {
            return SQL.MaPhong(et);
        }
        public DataTable LoadPhong(string DieuKien)
        {
            return SQL.LoadPhong(DieuKien);
        }
        public string LoadTrangThai(EC_Phong et)
        {
            return SQL.LoadTrangThai(et);
        }
        public void HuyBan(EC_Phong et)
        {
            SQL.HuyBan(et);
        }
        public void ThanhToanBan(EC_Phong et)
        {
            SQL.ThanhToanBan(et);
        }

    }
}
