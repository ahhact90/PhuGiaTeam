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
              var sql = "show databases;";
              return ExecuteQuery(sql);
              //select TABLE_SCHEMA, TABLE_NAME,COLUMN_NAME from information_schema.columns
              //   where table_schema = 'qlnhathuoc'
              //  order by table_name,ordinal_position
              ////var sql = "select TABLE_SCHEMA, TABLE_NAME,COLUMN_NAME from information_schema.columns where table_schema = 'qlnhathuoc'";
              //return ExecuteQuery(sql);

          }
        
        #endregion
    }
}
