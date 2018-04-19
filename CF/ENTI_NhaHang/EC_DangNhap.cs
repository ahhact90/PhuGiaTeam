using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENTI_NhaHang
{
    public class EC_DangNhap
    {
        private Int32 _ID;

        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private string _TaiKhoan;

        public string TaiKhoan
        {
            get { return _TaiKhoan; }
            set { _TaiKhoan = value; }
        }
        private string _MatKhau;

        public string MatKhau
        {
            get { return _MatKhau; }
            set { _MatKhau = value; }
        }
        private Int32 _Quyen;

        public Int32 Quyen
        {
            get { return _Quyen; }
            set { _Quyen = value; }
        }
        private Int32 _MaNV;

        public Int32 MaNV
        {
            get { return _MaNV; }
            set { _MaNV = value; }
        }
    }
}
