using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENTI_NhaHang
{
    public class EC_ThongTinNo
    {
        private Int32 _IDThongTin;

        public Int32 IDThongTin
        {
            get { return _IDThongTin; }
            set { _IDThongTin = value; }
        }
        private string _SoPhieu;

        public string SoPhieu
        {
            get { return _SoPhieu; }
            set { _SoPhieu = value; }
        }
        private DateTime _NgayNo;

        public DateTime NgayNo
        {
            get { return _NgayNo; }
            set { _NgayNo = value; }
        }
        private Int32 _MaPhong;

        public Int32 MaPhong
        {
            get { return _MaPhong; }
            set { _MaPhong = value; }
        }
        private string _NguoiNo;

        public string NguoiNo
        {
            get { return _NguoiNo; }
            set { _NguoiNo = value; }
        }
        private Boolean _DaThanhToan;

        public Boolean DaThanhToan
        {
            get { return _DaThanhToan; }
            set { _DaThanhToan = value; }
        }
        private string _Phone;

        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }
        private string _DiaChi;

        public string DiaChi
        {
            get { return _DiaChi; }
            set { _DiaChi = value; }
        }
        private float _SoTien;

        public float SoTien
        {
            get { return _SoTien; }
            set { _SoTien = value; }
        }
        private string _GhiChu;

        public string GhiChu
        {
            get { return _GhiChu; }
            set { _GhiChu = value; }
        }
    }
}
