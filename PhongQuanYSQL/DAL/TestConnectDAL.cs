using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class TestConnectDAL : BaseDAL
    {  

        #region Contrustor
          public TestConnectDAL(string connectString) : base(connectString) { }
        #endregion

        #region Kiểm tra kết nối đến cơ sở dữ liệu SQL
          public DataTable Showdata()
          {
              var sql = "SP_DATABASES;";
              return ExecuteQuery(sql);             

          }
        
        #endregion
    }
}
