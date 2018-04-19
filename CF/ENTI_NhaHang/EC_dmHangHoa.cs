using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENTI_NhaHang
{
    public class EC_dmHangHoa
    {
        private Int32 _MaHang;

        public Int32 MaHang
        {
            get { return _MaHang; }
            set { _MaHang = value; }
        }
        private string _TenHang;

        public string TenHang
        {
            get { return _TenHang; }
            set { _TenHang = value; }
        }
        private string _DonViTinh;

        public string DonViTinh
        {
            get { return _DonViTinh; }
            set { _DonViTinh = value; }
        }
        private string _MaNhom;

        public string MaNhom
        {
            get { return _MaNhom; }
            set { _MaNhom = value; }
        }
        private float? _GiaPhong;

        public float? GiaPhong
        {
            get { return _GiaPhong; }
            set { _GiaPhong = value; }
        }
        private float? _GiaBan;

        public float? GiaBan
        {
            get { return _GiaBan; }
            set { _GiaBan = value; }
        }
        private Int32 _GioiHanTon;

        public Int32 GioiHanTon
        {
            get { return _GioiHanTon; }
            set { _GioiHanTon = value; }
        }
        private string _GhiChu;

        public string GhiChu
        {
            get { return _GhiChu; }
            set { _GhiChu = value; }
        }
    }
}
