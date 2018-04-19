using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENTI_NhaHang
{
    public class EC_NhanVien
    {
        private string _MaNV;

        public string MaNV
        {
            get { return _MaNV; }
            set { _MaNV = value; }
        }
        private string _HoLot;

        public string HoLot
        {
            get { return _HoLot; }
            set { _HoLot = value; }
        }
        private string _Ten;

        public string Ten
        {
            get { return _Ten; }
            set { _Ten = value; }
        }
        private Int32 _ImgID;

        public Int32 ImgID
        {
            get { return _ImgID; }
            set { _ImgID = value; }
        }
        private string _Gioi;

        public string Gioi
        {
            get { return _Gioi; }
            set { _Gioi = value; }
        }
        private DateTime _NgaySinh;

        public DateTime NgaySinh
        {
            get { return _NgaySinh; }
            set { _NgaySinh = value; }
        }
        private string _DiaChi;

        public string DiaChi
        {
            get { return _DiaChi; }
            set { _DiaChi = value; }
        }
        private string _Phone;

        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }
        private DateTime _NgayVaoLam;

        public DateTime NgayVaoLam
        {
            get { return _NgayVaoLam; }
            set { _NgayVaoLam = value; }
        }
        private Int32 _MaCA;

        public Int32 MaCA
        {
            get { return _MaCA; }
            set { _MaCA = value; }
        }
    }
}
