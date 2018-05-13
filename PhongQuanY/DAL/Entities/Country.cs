using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Country
    {
        public Int32 id { set; get; }
        public string country_code { set; get; }
        public string country_name { set; get; }
    }
}
