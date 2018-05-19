using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    class Congty
    {       
            public Int32 id { set; get; }
            public string company_code { set; get; }
            public string company_name { set; get; }
            public string company_tax { set; get; }
            public string company_address { set; get; }
            public string company_phone { set; get; }
            public string other_name { set; get; }
            public int hide { set; get; }
            public string full_name { set; get; }
        
    }
}
