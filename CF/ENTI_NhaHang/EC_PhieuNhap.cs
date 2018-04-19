using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENTI_NhaHang
{
    public class EC_PhieuNhap
    {
        private string _SoPhieu;

        public string SoPhieu
        {
            get { return _SoPhieu; }
            set { _SoPhieu = value; }
        }
        private Int32 _MaKho;

        public Int32 MaKho
        {
            get { return _MaKho; }
            set { _MaKho = value; }
        }

        private string _NgayNhap;

        public string NgayNhap
        {
            get { return _NgayNhap; }
            set { _NgayNhap = value; }
        }
        private string _NguoiLap;

        public string NguoiLap
        {
            get { return _NguoiLap; }
            set { _NguoiLap = value; }
        }
        private string _NguoiGiao;

        public string NguoiGiao
        {
            get { return _NguoiGiao; }
            set { _NguoiGiao = value; }
        }
       
        private float _TienHang;

        public float TienHang
        {
            get { return _TienHang; }
            set { _TienHang = value; }
        }
        private float _ThanhToan;

        public float ThanhToan
        {
            get { return _ThanhToan; }
            set { _ThanhToan = value; }
        }
        private float _ConNo;

        public float ConNo
        {
            get { return _ConNo; }
            set { _ConNo = value; }
        }
        private string _GhiChu;

        public string GhiChu
        {
            get { return _GhiChu; }
            set { _GhiChu = value; }
        }
        private Int32 _IDNhaCC;

        public Int32 IDNhaCC
        {
            get { return _IDNhaCC; }
            set { _IDNhaCC = value; }
        }
    }
}
