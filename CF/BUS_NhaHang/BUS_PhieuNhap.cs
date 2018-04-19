using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ENTI_NhaHang;
using DAL_NhaHang;

namespace BUS_NhaHang
{
    public class BUS_PhieuNhap
    {
        SQL_PhieuNhap SQL = new SQL_PhieuNhap();

        public void ThemDuLieu(EC_PhieuNhap et)
        {
            SQL.ThemDuLieu(et);
        }
        public void SuaDuLieu(EC_PhieuNhap et)
        {
            SQL.SuaDuLieu(et);
        }
        public void XoaDuLieu(EC_PhieuNhap et)
        {
            SQL.XoaDuLieu(et);
        }
        public string LaySoPhieu(String DieuKien)
        {
            return SQL.TaoPhieu(DieuKien);
        }
        public DataTable LoadComboboxNCC(string DieuKien)
        {
            return SQL.LoadComboboxNCC(DieuKien);
        }
        public DataTable LoadComboboxKhoHang(string DieuKien)
        {
            return SQL.LoadComboboxKhoHang(DieuKien);
        }
        public DataTable LoadComboboxHangHoa(string DieuKien)
        {
            return SQL.LoadComboboxHangHoa(DieuKien);
        }
        public DataTable TimPhieu(EC_PhieuNhap etpn)
        {
            return SQL.TimPhieu(etpn);
        }
        public void LuuPhieu(EC_PhieuNhap etpn)
        {
            SQL.LuuPhieu(etpn);
        }
        public void HuyPhieu(EC_PhieuNhap etpn)
        {
            SQL.HuyPhieu(etpn);
        }
        public DataTable InPhieuNhap(EC_PhieuNhap etpn)
        {
            return SQL.InPhieuNhap(etpn);
        }
        public DataTable ThongTinPhieuNhap(EC_PhieuNhap etpn)
        {
            return SQL.ThongTinPhieuNhap(etpn);
        }
    
    }
}
