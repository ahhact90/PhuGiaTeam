using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TestConnect : BaseDAL
    {  

        #region Contrustor
          public TestConnect(string connectString) : base(connectString) { }
        #endregion

        #region Kiểm tra kết nối đến cơ sở dữ liệu My SQL
          public System.Data.DataTable Showdata()
          {
              var sql = "show databases;";
              return ExecuteQuery(sql);
          }
        
        #endregion
    }
}
