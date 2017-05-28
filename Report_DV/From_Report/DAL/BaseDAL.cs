using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Npgsql;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using System.Security.Cryptography;



namespace DAL
{
    public abstract class BaseDAL
    {
        #region Contansts
        protected const string STR_BACKUP = @"BACKUP DATABASE {0} " +
            @"TO DISK = N'{1}' WITH NOFORMAT, NOINIT, " +
            @"NAME = N'{2}', SKIP, NOREWIND, NOUNLOAD, STATS = 10";

        protected const string STR_RESTOR = @"USE MASTER; DROP DATABASE {0}; RESTORE DATABASE {0} " +
            @"FROM  DISK = N'{1}' WITH  FILE = 1, NOUNLOAD, STATS = 10";

        protected const string STR_CREATE = @"CREATE DATABASE {0} " +
            @"ON  PRIMARY (NAME = N'{0}', FILENAME = N'{1}\{0}.mdf', SIZE = 3072KB, FILEGROWTH = 1024KB) " +
            @"LOG ON (NAME = N'{0}_log', FILENAME = N'{1}\{0}_log.ldf', SIZE = 1024KB, FILEGROWTH = 10%) " +
            @"COLLATE VIETNAMESE_CI_AI";

        protected const string STR_DBNAME = "master";

        protected const string STR_DFO = "set dateformat dmy";

        private static NpgsqlConnection myPgConnect;

        private NpgsqlCommand myPgCommand;

        private NpgsqlDataAdapter myPgAdapter;

        private static string strconnection;
        //public string strconnection { set; get; }


        #endregion

        #region Default objects
        #endregion

        #region More objects
        #endregion

        #region Properties
        protected NpgsqlConnection Cnn { get; set; }
        protected NpgsqlCommand Cmd { get; set; }
        protected NpgsqlDataAdapter Da { get; set; }

        public static string FileDb { set; get; }
        public static string DbName { set; get; }
        #endregion

        #region Implements
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>

        public BaseDAL()
        {
            //Cnn = new NpgsqlConnection(string.Format(DAL.Properties.Settings.Default.Setting)); // default connection string
            //Cnn = new NpgsqlConnection("server = localhost; port = 5432; user id = postgres; password = P@$121# ; Database = HMIS");
            //Cnn = new NpgsqlConnection("server = 172.251.110.3; port = 5432; user id = bv121; password = @bv121@ ; Database = HMIS");
            //Cmd = new NpgsqlCommand() { Connection = Cnn };
            //Da = new NpgsqlDataAdapter();         

        }

        public BaseDAL(string connectString)
        {
            Cnn = new NpgsqlConnection(connectString);
            Cmd = new NpgsqlCommand() { Connection = Cnn };
            Da = new NpgsqlDataAdapter();

        }
        #endregion

        #region Events
        #endregion

        #region Methods
        /// <summary>
        /// Open connection
        /// </summary>
        /// <returns>True is open successfull else false</returns>
        protected bool Open()
        {
            try
            {
                if (Cnn.State == ConnectionState.Closed)
                    Cnn.Open();
                return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// Close connection
        /// </summary>
        protected void Close()
        {
            if (Cnn.State != ConnectionState.Closed)
                Cnn.Close();
        }

        /// <summary>
        /// Execute query SQL command text
        /// </summary>
        /// <param name="sqlCommand">T-SQL</param>
        /// <param name="tableName">table name</param>
        /// <returns>data</returns>
        protected DataTable ExecuteQuery(string sqlCommand, string tableName = "Tmp")
        {
            try
            {
                Open();
                Cmd.CommandText = sqlCommand;
                var tbl = new DataTable(tableName);
                tbl.Load(Cmd.ExecuteReader());

                return tbl;
            }
            catch { return null; }
            finally { Close(); }
        }

        /// <summary>
        /// Execute non query SQL command text
        /// </summary>
        /// <param name="sqlCommand">T-SQL</param>
        /// <returns>number of records affect</returns>
        protected int ExecuteNonQuery(string sqlCommand)
        {
            try
            {
                Open();
                Cmd.CommandText = sqlCommand;
                return Cmd.ExecuteNonQuery();
            }
            catch { return -1; }
            finally { Close(); }
        }
        
        /// <summary>
        /// Return Dataset
        /// </summary>
        /// <param name="que"></param>
        /// <returns></returns>
        protected DataSet ExecuteDataset(string que)
        {
            try
            {
                Open();
                NpgsqlDataAdapter Da = new NpgsqlDataAdapter(que, Cnn);
                DataSet ds = new DataSet();
                Da.Fill(ds);
                return ds;
            }
            catch { return null; }
            finally { Close(); }
        }

        #endregion

        #region Status
        /// <summary>
        /// Current information connection
        /// </summary>
        public class ConnectInfo
        {
            public string UID { set; get; }
            public string Server { set; get; }
            public string Database { set; get; }
            public string User { set; get; }
            public string Password { set; get; }
        }
        #endregion

        #region More
        public static void GetConfig()
        {
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
                        pass = "0ZrZxcq8x9qiVh3e/zZbVw==";
                        port = "5432";
                        database = "HMIS";
                        text = "172.251.110.3";
                    }
                    strconnection = getHosPath(database, pass, text, port, uID);
                    myPgConnect = new NpgsqlConnection(getHosPath(database, pass, text, port, uID));
                    //this.lb_host.Text = text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

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

        #endregion
    }
}

