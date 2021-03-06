﻿using System;
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

        #region Kiểm tra kết nối đến cơ sở dữ liệu My SQL
          public System.Data.DataTable Showdata()
          {
              var sql = "show databases;";
              return ExecuteQuery(sql);           

          }
          public DataTable ShowTable(string dbname)
          {
              var sql = @"use {0};show tables;";                          
              sql = string.Format(sql, dbname);
              return ExecuteQuery(sql);       

          }
        
        #endregion
    }
}
