using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Column
    {
        public string Name
        {
            get;
            set;
        }

        public string DataType
        {
            get;
            set;
        }

        public bool IsIdentity
        {
            get;
            set;
        }

        public object DataTypeLength
        {
            get;
            set;
        }
    }
}
