using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.Entities;

namespace DAL.EntitiesDAL
{
    public class Country_DAL: BaseDAL, UTL.IBaseDAL
    {
        #region Contrustor
            //public static string StrConnect = UTL.DataBase.GetConfig();
        public static string StrConnect;
        public Country_DAL(string StrConnect) : base(StrConnect) { }
        #endregion

        #region Implement

        public int Count()
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            var sql = "Delete From tbl_country Where id = {0}";
            sql = string.Format(sql, id);
            return ExecuteNonQuery(sql) > 0 ? true : false;
        }

        public object GetByKey(object key)
        {
            throw new NotImplementedException();
        }

        public bool Insert(object obj)
        {
            var o = (Country)obj;
            var sql = "Insert into  tbl_country (country_code,country_name) values ('{0}','{1}')";
            sql = string.Format(sql,o.country_code, o.country_name);
            return ExecuteNonQuery(sql) > 0 ? true : false;
        }

        public DataTable Search(string name)
        {
            throw new NotImplementedException();
        }

        public DataTable Select()
        {
            var sql = "SELECT * FROM tbl_country";
            sql = string.Format(sql);
            return ExecuteQuery(sql);
        }

        public DataTable Select(object obj)
        {
            throw new NotImplementedException();
        }

        public DataSet Select_non()
        {
            throw new NotImplementedException();
        }

        public DataSet Select_non2(string n)
        {
            throw new NotImplementedException();
        }

        public DataSet Select_non3(DateTime to, DateTime from)
        {
            throw new NotImplementedException();
        }

        public bool Update(object obj)
        {
            var o = (Country)obj;
            var sql = "Update tbl_country Set country_code = '{0}',country_name ='{1}' Where country_code = {0}";
            sql = string.Format(sql, o.country_code, o.country_name);
            return ExecuteNonQuery(sql) > 0 ? true : false;
        }

        #endregion
    }
}
