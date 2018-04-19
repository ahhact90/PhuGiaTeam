using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENTI_NhaHang
{
    public class EC_PhieuXuat_CT
    {
        private int _CTPXID;

        public int CTPXID
        {
            get { return _CTPXID; }
            set { _CTPXID = value; }
        }
        private string _SoPhieu;

        public string SoPhieu
        {
            get { return _SoPhieu; }
            set { _SoPhieu = value; }
        }
        private int _MaHang;

        public int MaHang
        {
            get { return _MaHang; }
            set { _MaHang = value; }
        }
        private float _GiaXuat;

        public float GiaXuat
        {
            get { return _GiaXuat; }
            set { _GiaXuat = value; }
        }
        private int _SoLuong;

        public int SoLuong
        {
            get { return _SoLuong; }
            set { _SoLuong = value; }
        }
        private string _GhiChu;

        public string GhiChu
        {
            get { return _GhiChu; }
            set { _GhiChu = value; }
        }

    }
}
