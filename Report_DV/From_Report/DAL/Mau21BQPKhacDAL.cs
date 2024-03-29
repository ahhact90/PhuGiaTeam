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
        public DataTable Select_Thuoc_AX()
        {
            var sql = @"SELECT a.id as drug_id,a.usingdrugid,b.drug_name,b.component,b.content_name,b.unit_name,SPLIT_PART(c.description,'|',1) as MA_BV,SPLIT_PART(c.description,'|',2) as Ma_AX,c.use_type_id,c.service_type_id,a.stockid,a.mainimexid,a.creationdate_drug FROM his_drug_ax a " +
                    @"JOIN (SELECT id,drug_name,component,content_name,unit_name FROM his_vw_usingdrug) b  ON a.usingdrugid = b.id JOIN (SELECT id,description,use_type_id,service_type_id FROM his_drug) c on c.id = a.id order by mainimexid,drug_name";
            return ExecuteQuery(sql);
        }
        public int Update_AX(string mAX, Int32 mUse_type,string mService_type,Int32 mDrug)
        {              
            try
            {
                var sql = @"UPDATE his_drug set description = '{0}',use_type_id = {1},service_type_id={2} WHERE id = {3}";
                sql = String.Format(sql, mAX, mUse_type, mService_type,mDrug);
                return ExecuteNonQuery(sql);            
            }
            catch { return -1; }              
        }
        public DataTable Duongdung()
        {
            var sql = "SELECT line,name FROM  his_drug_config WHERE zone ='drug_use_type' ORDER BY line";
            sql = string.Format(sql);
            return ExecuteQuery(sql);
        }
        /// <summary>
        /// Lấy Mã nhóm trong để ánh xạ thuốc
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable MaNhom()
        {
            var sql = "SELECT line,name FROM  his_drug_config WHERE zone ='group_type' ORDER BY line";
            sql = string.Format(sql);
            return ExecuteQuery(sql);
        }
        /// <summary>
        /// Lấy dữ liệu table hms_service
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable Select_Service()
        {
            var sql = "SELECT * FROM hms_service Where hide = 0 ORDER BY id";
            return ExecuteQuery(sql);
        }
        /// <summary>
        /// Truy vân cơ sở dữ liệu trực tiếp trên phần mềm
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public System.Data.DataTable Select_SQL(string sql)
        {           
            return ExecuteQuery(sql);
        }
        /// <summary>
        /// Tìm kiếm thông tin bệnh nhân bằng mã bệnh án
        /// 
        /// </summary>
        /// <param name="sql">ma bệnh án</param>
        /// <returns>DataTable</returns>
        public System.Data.DataTable Select_ThongTinBA(string BA)
        {           
            var sql = "SELECT * FROM his_medical_info_get('{0}|0|0')";
            sql = string.Format(sql, BA);
            return ExecuteQuery(sql);
        }
        /// <summary>
        /// Hàm lấy thông tin chuyển viện ngoại trú
        /// </summary>
        /// <param name="BA"></param>
        /// <returns></returns>
        public System.Data.DataTable Select_CV_NgoaiTru()
        {
            var sql = "SELECT a.id AS medicalrecordid, hm_getname(fname, mname, null) fullname, lname AS name, a.status, CASE WHEN gender = 1 THEN 'Nam' ELSE 'Nữ' END AS sex, birthyear, c.code AS cardcode,CASE WHEN length(subjectofpatient::text) <> 9 THEN 0 ELSE substr(subjectofpatient::text,7,3)::integer END AS discount,age, b.id,  a.examroomid, d.id AS receptionid, d.status AS receptionstatus, ticketnumber, queuenumber, 0 AS chs FROM hms_medicalrecord a JOIN hms_patient b ON a.patientid = b.id LEFT JOIN hms_card c ON a.cardid = c.id JOIN hms_reception d ON a.id = d.medicalrecordid  WHERE a.tohospital <> 0 AND a.treatmentdivisionid = 0 order by a.id desc";
            sql = string.Format(sql);
            return ExecuteQuery(sql);
        }
        /// <summary>
        /// Ham lấy thông tin bệnh nhân chi tiết
        /// </summary>
        /// <param name="BA"></param>
        /// <returns></returns>
        public System.Data.DataTable Select_ThongTinBA_chitiet(string BA)
        {
            var sql = "SELECT *, his_general_full_address(homenumber, address, precinct_name) AS full_address, UPPER(full_name) AS full_name_upper, is_card, CASE WHEN archives_number_home IS NOT NULL OR archives_number_home <> '' THEN 1 ELSE 0 END is_home_treatment_file, CASE WHEN medical_objects = 1 THEN CASE WHEN insurance_discount <> 0 THEN 'BH:' || insurance_discount || '%' ELSE '' END ELSE CASE WHEN medical_objects = 3 THEN 'Chính Sách' ELSE 'Thu Phí ' || (100 - object_remission) || '%' END END || CASE WHEN object_remission <> 0 THEN CASE WHEN insurance_discount = 0 THEN 'Miễn phí:' || object_remission || '%' ELSE '+' || 'Miễn :' || object_remission || '%' END ELSE '' END AS medical_object, CASE WHEN suggestion_policy = 9 THEN finish_plan_time::date + treatment_day ELSE CASE WHEN treatment_id <> 0 THEN finish_plan_time ELSE close_time END END AS date_signal FROM his_medical_info_get('{0}|0|0')";
            sql = string.Format(sql, BA);
            return ExecuteQuery(sql);
        }
        /// <summary>
        /// Hàm lấy thông tin bệnh nhân theo ngày hiện tại
        /// </summary>
        /// <param name="BA"></param>
        /// <returns></returns>
        public System.Data.DataTable Select_ThongTinBA_hientai()
        {
            var sql = "SELECT a.id AS medicalrecordid, hm_getname(fname, mname, null) fullname, lname AS name, a.status, CASE WHEN gender = 1 THEN 'Nam' ELSE 'Nữ' END AS sex, birthyear, c.code AS cardcode,CASE WHEN length(subjectofpatient::text) <> 9 THEN 0 ELSE substr(subjectofpatient::text,7,3)::integer END AS discount,age, b.id,  a.examroomid, d.id AS receptionid, d.status AS receptionstatus, ticketnumber, queuenumber, 0 AS chs FROM hms_medicalrecord a JOIN hms_patient b ON a.patientid = b.id LEFT JOIN hms_card c ON a.cardid = c.id JOIN hms_reception d ON a.id = d.medicalrecordid  WHERE a.tohospital <> 0 AND a.treatmentdivisionid <> 0  AND creationdate::date = current_date order by a.id desc";
            sql = string.Format(sql);
            return ExecuteQuery(sql);
        }
        /// <summary>
        /// Hàm thông tin chuyển viện nội trú
        /// 
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable Select_CV_NoiTru()
        {
            var sql = "SELECT a.id AS medicalrecordid, hm_getname(fname, mname, null) fullname, lname AS name, a.status, CASE WHEN gender = 1 THEN 'Nam' ELSE 'Nữ' END AS sex, birthyear, c.code AS cardcode,CASE WHEN length(subjectofpatient::text) <> 9 THEN 0 ELSE substr(subjectofpatient::text,7,3)::integer END AS discount,age, b.id,  a.examroomid, d.id AS receptionid, d.status AS receptionstatus, ticketnumber, queuenumber, 0 AS chs FROM hms_medicalrecord a JOIN hms_patient b ON a.patientid = b.id LEFT JOIN hms_card c ON a.cardid = c.id JOIN hms_reception d ON a.id = d.medicalrecordid  WHERE a.tohospital <> 0 AND a.treatmentdivisionid <> 0 order by a.id desc";
            sql = string.Format(sql);
            return ExecuteQuery(sql);
        }

        public DataSet Giay_CV(string BA)
        {
            var sql = "SELECT *, his_general_full_address(homenumber, address, precinct_name) AS full_address, UPPER(full_name) AS full_name_upper, is_card, CASE WHEN archives_number_home IS NOT NULL OR archives_number_home <> '' THEN 1 ELSE 0 END is_home_treatment_file,CASE WHEN medical_objects = 1 THEN CASE WHEN insurance_discount <> 0 THEN 'BH:' || insurance_discount || '%' ELSE '' END ELSE CASE WHEN medical_objects = 3 THEN 'Chính Sách' ELSE 'Thu Phí ' || (100 - object_remission) || '%' END END ||CASE WHEN object_remission <> 0 THEN CASE WHEN insurance_discount = 0 THEN 'Miễn phí:' || object_remission || '%' ELSE '+' || 'Miễn :' || object_remission || '%' END ELSE '' END AS medical_object,CASE WHEN suggestion_policy = 9 THEN finish_plan_time::date + treatment_day ELSE CASE WHEN treatment_id <> 0 THEN finish_plan_time ELSE close_time END END AS date_signal FROM his_medical_info_get('{0}|0|0')";
            sql = string.Format(sql, BA);
            return ExecuteDataset(sql);
        }

        #endregion
    }
}
