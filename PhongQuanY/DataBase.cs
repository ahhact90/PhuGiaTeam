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
        public static string getHosPath(string Database, string Pass, string IPSrv, string Port, string UID)
        {
            string text = Encrypt("tckt", "2010-01-01;TRUONG ANH VU;COD-FWG-674-ECF", true);
            return string.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};Timeout={5};CommandTimeout={5};", new object[]
			{
				IPSrv,
				Port,
				UID,
				Decrypt(Pass, "29fa797a-d341-4755-af56-8bf5aa6c9e5d", true),
				Database,
				1000
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
                        pass = "oUIJpYLtYPc=";
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
    }
}
