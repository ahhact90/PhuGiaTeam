﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class Mau21BQPKhacDAL :  BaseDAL, UTL.IBaseDAL
    {
        #region Implement

        public int Count()
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public object GetByKey(object key)
        {
            throw new NotImplementedException();
        }

        public bool Insert(object obj)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataTable Search(string name)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataTable Select() 
        {
            var sql = "SELECT CASE WHEN b.id IS NOT NULL THEN b.servicename ELSE c.name END As group_name, a.servicename AS name, a.servicegroupline, a.id, c.line, price, insprice FROM hms_service a  LEFT JOIN (SELECT id, servicename FROM hms_service WHERE category = 'GROUP' AND hide = 0) b ON a.servicegroup::integer = b.id  LEFT JOIN (SELECT line, name FROM hms_selection WHERE zone = 'srvcon' AND sector = 'sergrp') c ON SUBSTR(a.accesskey::text,1,2)::integer = c.line  WHERE hide = 0  AND price<>0 ORDER BY CASE WHEN b.id IS NOT NULL THEN b.servicename ELSE c.name END, a.servicename";
            return ExecuteQuery(sql);
        }

        public System.Data.DataTable Select(object obj)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Report Danh mục kỹ thuật đang dùng
        /// </summary>
        /// <returns></returns>
        public System.Data.DataSet Select_non()
        {
            var sql = "SELECT CASE WHEN b.id IS NOT NULL THEN b.servicename ELSE c.name END As group_name, a.servicename AS name, a.servicegroupline, a.id, c.line, price, insprice FROM hms_service a  LEFT JOIN (SELECT id, servicename FROM hms_service WHERE category = 'GROUP' AND hide = 0) b ON a.servicegroup::integer = b.id  LEFT JOIN (SELECT line, name FROM hms_selection WHERE zone = 'srvcon' AND sector = 'sergrp') c ON SUBSTR(a.accesskey::text,1,2)::integer = c.line  WHERE hide = 0  AND price<>0 ORDER BY CASE WHEN b.id IS NOT NULL THEN b.servicename ELSE c.name END, a.servicename";
            return ExecuteDataset(sql);
        }
        /// <summary>
        /// DataGridView Danh mục kỹ thuật đang dùng
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable Select_DMKT()
        {
            var sql = "SELECT CASE WHEN b.id IS NOT NULL THEN b.servicename ELSE c.name END As group_name, a.servicename AS name, a.servicegroupline, a.id, c.line, price, insprice,optprice,insname FROM hms_service a  LEFT JOIN (SELECT id, servicename FROM hms_service WHERE category = 'GROUP' AND hide = 0) b ON a.servicegroup::integer = b.id  LEFT JOIN (SELECT line, name FROM hms_selection WHERE zone = 'srvcon' AND sector = 'sergrp') c ON SUBSTR(a.accesskey::text,1,2)::integer = c.line  WHERE hide = 0  AND price<>0 ORDER BY CASE WHEN b.id IS NOT NULL THEN b.servicename ELSE c.name END, a.servicename";
            return ExecuteQuery(sql);
        }

        public System.Data.DataSet Select_non2(string n)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataSet Select_non3(DateTime to, DateTime from)
        {
            throw new NotImplementedException();
        }

        public bool Update(object obj)
        {
            throw new NotImplementedException();
        }

        #endregion


        #region Contrustor
        public Mau21BQPKhacDAL(string connectString) : base(connectString) { }
        #endregion


        #region Mau 21 BQP Khac

        
        public string his_fee_sync_tonghop(long Media)
        {
            try
            {
                var sql = "select his_fee_sync_tonghop_all({0})";
                sql = string.Format(sql, Media);
                return ExecuteQuery(sql).Rows[0][0].ToString();
            }
            catch 
            {
                
                return "-1";
            }
             
        }
        
        public long Select_Medical()
        {
            try
            {
                var sql = "select sohoso from his_chitiet_bhyt where exportxml = 0 and sohoso > 17000000 and SUBSTR(mathe,4,2)::integer <> 97 order by ngaybc limit 1";
                sql = string.Format(sql);
                return long.Parse(ExecuteQuery(sql).Rows[0][0].ToString());

            }
            catch
            {

                return -1;
            }
            
        }
       
        public DataTable Select_Bang1(long Media)
        {
            var sql = "select * from his_chitieu_tonghop_bang1 where \"MA_LK\" = '{0}' ";
            sql = string.Format(sql, Media);
            return ExecuteQuery(sql);
        }
        public DataTable Select_Bang2(long Media)
        {
            var sql = "select * from his_chitiet_thuoc_bang2 where \"MA_LK\" = '{0}' ";
            sql = string.Format(sql, Media);
            return ExecuteQuery(sql);
        }
        public DataTable Select_Bang3(long Media)
        {
            var sql = "select * from his_chitiet_dv_vt_bang3 where \"MA_LK\" = '{0}' ";
            sql = string.Format(sql, Media);
            return ExecuteQuery(sql);
        }
        /// <summary>
        /// update trang thai sao khi xuat thanh cong
        /// </summary>
        /// <param name="mMedia"></param>
        /// <returns></returns>
        public int FinishMed(long mMedia)
        {
            try
            {
                var sql = "UPDATE his_chitiet_bhyt SET exportxml = 1 WHERE sohoso = {0}";
                sql = String.Format(sql, mMedia);
                return ExecuteNonQuery(sql);
            }
            catch { return -1; }
        }

        #endregion
    }
}
