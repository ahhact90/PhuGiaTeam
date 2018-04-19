using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENTI_NhaHang
{
    public class EC_PhieuNhap_CT
    {
        private Int32 _IDCT;

        public Int32 IDCT
        {
            get { return _IDCT; }
            set { _IDCT = value; }
        }
        private string _SoPhieu;

        public string SoPhieu
        {
            get { return _SoPhieu; }
            set { _SoPhieu = value; }
        }
        private Int32 _MaHang;

        public Int32 MaHang
        {
            get { return _MaHang; }
            set { _MaHang = value; }
        }
        private Int32 _SLNhap;

        public Int32 SLNhap
        {
            get { return _SLNhap; }
            set { _SLNhap = value; }
        }
        private float _GiaNhap;

        public float GiaNhap
        {
            get { return _GiaNhap; }
            set { _GiaNhap = value; }
        }
    }
}
