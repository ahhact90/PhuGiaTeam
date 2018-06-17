using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.Entities;

namespace DAL.EntitiesDAL
{
    public class Drug_Unit_DAL : BaseDAL, UTL.IBaseDAL
    {
         #region Contrustor
            //public static string StrConnect = UTL.DataBase.GetConfig();
        public static string StrConnect;
        public Drug_Unit_DAL(string StrConnect) : base(StrConnect) { }
        #endregion

        #region Implement

        public int Count()
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            var sql = "Delete From tbl_drugunit Where id = {0}";
            sql = string.Format(sql, id);
            return ExecuteNonQuery(sql) > 0 ? true : false;
        }

        public object GetByKey(object key)
        {
            throw new NotImplementedException();
        }

        public bool Insert(object obj)
        {
            var o = (Drug_Unit)obj;
            var sql = "Insert into  tbl_drugunit (unitname) values ('{0}')";
            sql = string.Format(sql, o.unitname);
            return ExecuteNonQuery(sql) > 0 ? true : false;
        }

        public DataTable Search(string name)
        {
            throw new NotImplementedException();
        }

        public DataTable Select()
        {  
            var sql = "SELECT * FROM tbl_drugunit ";
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
            var o = (Drug_Unit)obj;
            var sql = "Update tbl_drugunit Set unitname = '{0}' Where id = {1}";
            sql = string.Format(sql,o.unitname,o.id);
            return ExecuteNonQuery(sql) > 0 ? true : false;
        }

        #endregion

       
    }
}
