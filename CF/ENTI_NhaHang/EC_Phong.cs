using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENTI_NhaHang
{
    public class EC_Phong
    {
        Int32 _MaPhong;

        public Int32 MaPhong
        {
            get { return _MaPhong; }
            set { _MaPhong = value; }
        }
        string _TenPhong;

        public string TenPhong
        {
            get { return _TenPhong; }
            set { _TenPhong = value; }
        }
        Int32 _LoaiPhong;

        public Int32 LoaiPhong
        {
            get { return _LoaiPhong; }
            set { _LoaiPhong = value; }
        }
        Int32 _ImgID;

        public Int32 ImgID
        {
            get { return _ImgID; }
            set { _ImgID = value; }
        }
        Int32 _TrangThai;

        public Int32 TrangThai
        {
            get { return _TrangThai; }
            set { _TrangThai = value; }
        }
        string _MaHD;

        public string MaHD
        {
            get { return _MaHD; }
            set { _MaHD = value; }
        }
        string _MaKhu;

        public string MaKhu
        {
            get { return _MaKhu; }
            set { _MaKhu = value; }
        }
        float _Gia1;

        public float Gia1
        {
            get { return _Gia1; }
            set { _Gia1 = value; }
        }
        float _Gia2;

        public float Gia2
        {
            get { return _Gia2; }
            set { _Gia2 = value; }
        }
    }
}
