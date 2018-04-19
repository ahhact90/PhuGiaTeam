using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENTI_NhaHang
{
    public class EC_NhaCungCap
    {
        private Int32 _IDNhaCC;

        public Int32 IDNhaCC
        {
            get { return _IDNhaCC; }
            set { _IDNhaCC = value; }
        }
        private string _TenNhaCC;

        public string TenNhaCC
        {
            get { return _TenNhaCC; }
            set { _TenNhaCC = value; }
        }
        private string _DiaChi;

        public string DiaChi
        {
            get { return _DiaChi; }
            set { _DiaChi = value; }
        }
        private string _Phone;

        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }
        private string _Email;

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
    }
}
