using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENTI_NhaHang
{
    public class EC_KhoHang
    {
        private Int32 _MaKho;

        public Int32 MaKho
        {
            get { return _MaKho; }
            set { _MaKho = value; }
        }
        private string _TenKho;

        public string TenKho
        {
            get { return _TenKho; }
            set { _TenKho = value; }
        }
    }
}
