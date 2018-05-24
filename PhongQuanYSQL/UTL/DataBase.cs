using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Xml;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace UTL
{
    #region Variable
    
    #endregion
    public static class DataBase
    {
        /// <summary>
        /// doc file cau hinh trong Postgrest
        /// </summary>
        /// <param name="Database"></param>
        /// <param name="Pass"></param>
        /// <param name="IPSrv"></param>
        /// <param name="Port"></param>
        /// <param name="UID"></param>
        /// <returns></returns>
        public static string getHosPath(string Database, string Pass, string IPSrv, string Port, string UID)
        {
            string text = Encrypt("tckt", "2010-01-01;TRUONG ANH VU;COD-FWG-674-ECF", true);
            return string.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};", new object[]
			{
				IPSrv,
				Port,
				UID,
				Decrypt(Pass, "29fa797a-d341-4755-af56-8bf5aa6c9e5d", true),
				Database
				
			});
        }
        /// <summary>
        /// Đọc file cấu hình trong MySQL Workbenk
        /// </summary>
        /// <param name="Database"></param>
        /// <param name="Pass"></param>
        /// <param name="IPSrv"></param>
        /// <param name="Port"></param>
        /// <param name="UID"></param>
        /// <returns></returns>
        public static string getHosPathMySQL(string IPSrv, string Port, string UID, string Pass,string Database)
        {           
            return string.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};", new object[]
			{
				IPSrv,
				Port,
				UID,
				Decrypt(Pass, "29fa797a-d341-4755-af56-8bf5aa6c9e5d", true),
				Database			
			});
        }
        /// <summary>
        /// Doc file cau hinh SQL Express
        /// </summary>
        /// <param name="IPSrv"></param>
        /// <param name="Port"></param>
        /// <param name="UID"></param>
        /// <param name="Pass"></param>
        /// <param name="Database"></param>
        /// <returns></returns>
         public static string getHosPathSQL(string IPSrv, string Port, string UID, string Pass,string Database)
        {           
            return string.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};", new object[]
			{
				IPSrv,
				Port,
				UID,
				Decrypt(Pass, "29fa797a-d341-4755-af56-8bf5aa6c9e5d", true),
				Database			
			});
        }


        public static string Decrypt(string toDecrypt, string key, bool useHashing)
        {
            byte[] array = Convert.FromBase64String(toDecrypt);
            byte[] key2;
            if (useHashing)
            {
                MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
                key2 = mD5CryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(key));
            }
            else
            {
                key2 = Encoding.UTF8.GetBytes(key);
            }
            ICryptoTransform cryptoTransform = new TripleDESCryptoServiceProvider
            {
                Key = key2,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            }.CreateDecryptor();
            byte[] bytes = cryptoTransform.TransformFinalBlock(array, 0, array.Length);
            return Encoding.UTF8.GetString(bytes);
        }

        public static string Encrypt(string toEncrypt, string key, bool useHashing)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(toEncrypt);
            byte[] key2;
            if (useHashing)
            {
                MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
                key2 = mD5CryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(key));
            }
            else
            {
                key2 = Encoding.UTF8.GetBytes(key);
            }
            ICryptoTransform cryptoTransform = new TripleDESCryptoServiceProvider
            {
                Key = key2,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            }.CreateEncryptor();
            byte[] array = cryptoTransform.TransformFinalBlock(bytes, 0, bytes.Length);
            return Convert.ToBase64String(array, 0, array.Length);
        }
        /// <summary>
        /// Đọc file config postgrest
        /// </summary>
        /// <returns></returns>
        public static string GetConfig()
        {
            string strconnection;
            try
            {
                using (DataSet dataSet = new DataSet())
                {
                    string uID;
                    string pass;
                    string port;
                    string database;
                    string text;
                    if (File.Exists(Application.StartupPath + "\\config.xml"))
                    {
                        dataSet.ReadXml(Application.StartupPath + "\\config.xml");
                        uID = dataSet.Tables[0].Rows[0]["UID"].ToString();
                        pass = dataSet.Tables[0].Rows[0]["Pass"].ToString();
                        port = dataSet.Tables[0].Rows[0]["Port"].ToString();
                        database = dataSet.Tables[0].Rows[0]["Host"].ToString();
                        text = dataSet.Tables[0].Rows[0]["Server"].ToString();
                    }
                    else
                    {
                        uID = "postgres";
                        pass = "SebRMrg8c7Y=";  //Pass ket noi co so du lieu 123456
                        port = "5432";
                        database = "HMIS";
                        text = "localhost";
                    }
                    strconnection = getHosPath(database, pass, text, port, uID);
                                   
                }
                return strconnection;    
            }
            catch 
            { return ""; }
        }
        /// <summary>
        /// Doc file config mysql
        /// </summary>
        /// <returns></returns>
        public static string GetConfigMySQL()
        {
            string strconnection;
            try
            {
                using (DataSet dataSet = new DataSet())
                {
                    string uID;
                    string pass;
                    string port;
                    string database;
                    string text;
                    if (File.Exists(Application.StartupPath + "\\config.xml"))
                    {
                        dataSet.ReadXml(Application.StartupPath + "\\config.xml");
                        text = dataSet.Tables[0].Rows[0]["Server"].ToString();
                        port = dataSet.Tables[0].Rows[0]["Port"].ToString();
                        uID = dataSet.Tables[0].Rows[0]["UID"].ToString();
                        pass = dataSet.Tables[0].Rows[0]["Pass"].ToString();                       
                        database = dataSet.Tables[0].Rows[0]["Host"].ToString();                        
                    }
                    else
                    {
                        text = "localhost111";
                        uID = "root";
                        pass = "SebRMrg8c7Y=";  //Pass ket noi co so du lieu 123456
                        port = "3306";
                        database = "qlnhathuoc111";
                        
                    }
                    //strconnection = getHosPath(database, pass, text, port, uID);
                    strconnection = getHosPathMySQL(text, port, uID, pass, database);
                }
                return strconnection;
            }
            catch
            { return ""; }
        }
        /// <summary>
        /// Đọc file cấu hính SQL SQLEXPRESS
        /// </summary>
        /// <returns></returns>
        public static string GetConfigSQL()
        {
            string strconnection;
            try
            {
                using (DataSet dataSet = new DataSet())
                {
                    string uID; // user Id
                    string pass;
                    string port;
                    string database;
                    string server;
                    if (File.Exists(Application.StartupPath + "\\config.xml"))
                    {
                        dataSet.ReadXml(Application.StartupPath + "\\config.xml");
                        server = dataSet.Tables[0].Rows[0]["Server"].ToString();
                        port = dataSet.Tables[0].Rows[0]["Port"].ToString();
                        uID = dataSet.Tables[0].Rows[0]["UID"].ToString();
                        pass = dataSet.Tables[0].Rows[0]["Pass"].ToString();
                        database = dataSet.Tables[0].Rows[0]["Host"].ToString();
                    }
                    else
                    {
                        server = ".\\SQLEXPRESS";
                        uID = "sa";
                        pass = "SebRMrg8c7Y=";  //Pass ket noi co so du lieu 123456
                        port = "1433";
                        database = "qlnhathuoc";

                    }
                    //strconnection = getHosPath(database, pass, text, port, uID);
                    strconnection = getHosPathSQL(server, port, uID, pass, database);
                }
                return strconnection;
            }
            catch
            { return ""; }
        }
    }
}
