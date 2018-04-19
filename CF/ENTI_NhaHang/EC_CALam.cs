using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENTI_NhaHang
{
    public class EC_CALam
    {
        private Int32 _MaCA;

        public Int32 MaCA
        {
            get { return _MaCA; }
            set { _MaCA = value; }
        }
        private DateTime _BatDau;

        public DateTime BatDau
        {
            get { return _BatDau; }
            set { _BatDau = value; }
        }
        private DateTime _KetThuc;

        public DateTime KetThuc
        {
            get { return _KetThuc; }
            set { _KetThuc = value; }
        }
        private float _LuongCA;

        public float LuongCA
        {
            get { return _LuongCA; }
            set { _LuongCA = value; }
        }
        private string _GhiChu;

        public string GhiChu
        {
            get { return _GhiChu; }
            set { _GhiChu = value; }
        }
    }
}
