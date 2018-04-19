using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENTI_NhaHang
{
    public class EC_GioVang
    {
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
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
    }
}
