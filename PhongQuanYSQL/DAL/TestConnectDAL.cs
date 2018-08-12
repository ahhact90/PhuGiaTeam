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
              var sql = "SELECT name FROM sys.databases;";
              return ExecuteQuery(sql);            

          }

          public DataTable BackupData(string database, string disk)
          {
              var sql = @"BACKUP DATABASE {0} TO DISK='{1}'";
              sql = string.Format(sql, database, disk);
              return ExecuteQuery(sql);

          }
        
        #endregion
    }
}
