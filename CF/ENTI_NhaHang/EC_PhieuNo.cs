using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENTI_NhaHang
{
    public class EC_PhieuNo
    {
        private string _SoPhieu;

        public string SoPhieu
        {
            get { return _SoPhieu; }
            set { _SoPhieu = value; }
        }
        private DateTime _NgayLap;

        public DateTime NgayLap
        {
            get { return _NgayLap; }
            set { _NgayLap = value; }
        }
        private float _SoTien;

        public float SoTien
        {
            get { return _SoTien; }
            set { _SoTien = value; }
        }
        private Int32 _IDNhaCC;

        public Int32 IDNhaCC
        {
            get { return _IDNhaCC; }
            set { _IDNhaCC = value; }
        }
        private int _MaPhong;

        public int MaPhong
        {
            get { return _MaPhong; }
            set { _MaPhong = value; }
        }
        private Boolean _ThanhToan;

        public Boolean ThanhToan
        {
            get { return _ThanhToan; }
            set { _ThanhToan = value; }
        }
        private Int32 _Loai;

        public Int32 Loai
        {
            get { return _Loai; }
            set { _Loai = value; }
        }
        private string _GhiChu;

        public string GhiChu
        {
            get { return _GhiChu; }
            set { _GhiChu = value; }
        }
    }
}
