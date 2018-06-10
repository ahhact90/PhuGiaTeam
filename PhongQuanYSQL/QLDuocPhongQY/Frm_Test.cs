using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using SECURITY;

namespace QLDuocPhongQY
{
    public partial class Frm_Test : Form
    {
        #region Variable        
        public static string StrConnect = UTL.DataBase.GetConfigSQL();
        DAL.TestConnectDAL _TestConnect = new DAL.TestConnectDAL(StrConnect);
        private string string_0= Application.StartupPath + "\\config.dat";
        private string string_1;
        #endregion
        public Frm_Test()
        {
            InitializeComponent();
        }

        private void btbConnect_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable result2 = new DataTable();
                result2 = _TestConnect.Showdata();
                
                if (result2.Rows.Count > 0)
                {
                    dataGridView1.DataSource = result2;                  
                    MessageBox.Show("Kết nối CSDL thành công");
                }
                else
                {
                    MessageBox.Show("Kết nối thất bại");
                }
               
               
                            }
            catch
            {
                MessageBox.Show("Lỗi kết nối CSDL");

            }
        }

        private string method_0()
        {
            string result = "";
            if (File.Exists(string_0))
            {
                byte[] cipher = File.ReadAllBytes(string_0);
                string s = Encription.decryptByte_1(cipher);                
                MessageBox.Show(s);
                MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(s));
                DataSet dataSet = new DataSet("Config");
                dataSet.ReadXml((Stream)stream);
                if (dataSet != null)
                {
                    result = "Data Source=" + dataSet.Tables[0].Rows[0]["SERVER"].ToString();
                    result = result + ";Initial Catalog=" + dataSet.Tables[0].Rows[0]["DATABASE"].ToString();
                    if (dataSet.Tables[0].Rows[0]["USERNAME"].ToString() != "")
                    {
                        result = result + ";User ID=" + dataSet.Tables[0].Rows[0]["USERNAME"].ToString();
                    }
                    if (dataSet.Tables[0].Rows[0]["PASSWORD"].ToString() != "")
                    {
                        result = result + ";Password=" + dataSet.Tables[0].Rows[0]["PASSWORD"].ToString();
                    }
                    result += ";Connection Timeout=300";
                    MessageBox.Show(result);
                    string_1 = string.Concat(dataSet.Tables[0].Rows[0]["SERVER"]);
                    string_1 = string_1.Split('\\')[0];
                }
            }
            return result;
           
        }

        private void btRead_Click(object sender, EventArgs e)
        {
            RTxtKQ.Text = method_0();
        }
    }
}
