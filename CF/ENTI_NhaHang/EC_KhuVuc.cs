using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENTI_NhaHang
{
    public class EC_KhuVuc
    {
        string _MaKhu;

        public string MaKhu
        {
            get { return _MaKhu; }
            set { _MaKhu = value; }
        }
        string _TenKhu;

        public string TenKhu
        {
            get { return _TenKhu; }
            set { _TenKhu = value; }
        }
        string _GhiChu;

        public string GhiChu
        {
            get { return _GhiChu; }
            set { _GhiChu = value; }
        }
    }
}
