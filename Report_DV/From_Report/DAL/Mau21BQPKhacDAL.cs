using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class Mau21BQPKhacDAL :  BaseDAL,UTL.IBaseDAL
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

        public DataSet Select_Time(DateTime to, DateTime from)
        {
            var sql = "select * from his_insurance_service_detail_get_bqp_khac('{0}|{1}|21|3')";
            sql = string.Format(sql, to.ToString("yyyy-MM-dd HH:mm:ss"), from.ToString("yyyy-MM-dd HH:mm:ss"));
            return ExecuteDataset(sql);
        }
        public DataSet Select_M21()
        {
            var sql = "select * from his_insurance_service_detail_get('2017-01-01 0:0:0|2017-02-28 23:59:59|21|1')";
            sql = string.Format(sql);
            return ExecuteDataset(sql);
        }
        public DataTable Select_QN_NgTru(DateTime to, DateTime from)
        {
            var sql = "SELECT ma_lk::integer,ho_ten,ngay_sinh,gioi_tinh,dia_chi,ma_the,ma_dkbd,gt_the_tu,gt_the_den,ma_benh,ma_benhkhac,ma_lydo_vvien,ma_noi_chuyen,ngay_vao::text,ngay_ra::text,so_ngay_dtri,ket_qua_dtri,tinh_trang_rv,t_tongchi,t_xn,t_cdha,t_thuoc,t_mau,t_pttt,t_vtyt,t_dvkt_tyle,t_thuoc_tyle,t_vtyt_tyle,t_kham,t_giuong,t_vanchuyen,t_bntt,t_bhtt,t_ngoaids,ma_khoa,nam_qt,thang_qt,ma_khuvuc,ma_loai_kcb,ma_cskcb from his_bhxh_3360_97_get_bqp_khac('{0}|{1}|1^3^4')";
            sql = string.Format(sql, to.ToString("yyyy-MM-dd HH:mm:ss"), from.ToString("yyyy-MM-dd HH:mm:ss"));
            return ExecuteQuery(sql);
        }
        public string tonghop_chiphi_bhyt(long Media)
        {
            var sql = "select his_tonghop_chiphi_bhyt({0})";
            sql = string.Format(sql, Media);
            return ExecuteQuery(sql).Rows[0][0].ToString(); ;
        }
        #endregion
    }
}
