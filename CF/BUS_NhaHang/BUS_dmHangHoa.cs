using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENTI_NhaHang;
using DAL_NhaHang;
using System.Data;

namespace BUS_NhaHang
{
    public class BUS_dmHangHoa
    {
        SQL_dmHangHoa SQL = new SQL_dmHangHoa();

        public void ThemDuLieu(EC_dmHangHoa et)
        {
            SQL.ThemDuLieu(et);
        }
        //-------- update data
        public void SuaDuLieu(EC_dmHangHoa et)
        {
            SQL.SuaDuLieu(et);
        }
        // delete data
        public void XoaDuLieu(EC_dmHangHoa et)
        {
            SQL.XoaDuLieu(et);
        }

        public DataTable TaoBang(String DieuKien)
        {
            return SQL.TaoBang(DieuKien);
        }

        public DataTable LoadComboboxNhom(string DieuKien)
        {
            return SQL.LoadComboboxNhom(DieuKien);
        }
        public DataTable LayDanhSanhNhomHang(string DieuKien)
        {
            return SQL.LayDanhSanhNhomHang(DieuKien);
        }
        public DataTable LayThucDon(string DieuKien)
        {
            return SQL.LayThucDon(DieuKien);
        }
        public string GioiHanTon (string DK)
        {
           return SQL.GioiHanTon(DK);
        }
        public string TonKho_HangHoa(EC_dmHangHoa etdm)
        {
            return SQL.TonKho_HangHoa(etdm);
        }
        public DataTable TonKho()
        {
            return SQL.TonKho();
        }
    }
}
