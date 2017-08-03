using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using Npgsql;
using System.Threading;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net;
using System.Net.Http.Headers;


namespace WebService
{
    public partial class WebService_Update : Form
    {
        public WebService_Update()
        {
            InitializeComponent();
        }
        private void upwebservice()
        {

            //string lashpath = txtPathEx.Text.Trim();
            string lashpath = txtPath.Text.Trim();
            string username = txtUser.Text.Trim();
            //string password = txtPass.Text.Trim();
            string password = UTL.MH.CreateMD5(txtPass.Text.Trim());
            string[] result1;
            string[] ketqua;
            string kq;
            string[] access;
            string access1;
            string[] idtoken;
            string token;


            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://egw.baohiemxahoi.gov.vn");
            //httpClient.get_DefaultRequestHeaders().get_Accept().Clear();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            //httpClient.get_DefaultRequestHeaders().get_Accept().Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            Dictionary<string, string> dictionary = new Dictionary<string, string>
            {
                {
                    "username",
                    username
                },
                {
                    "password",
                    password
                }
            };
            FormUrlEncodedContent formUrlEncodedContent = new FormUrlEncodedContent(dictionary);
            HttpResponseMessage result = httpClient.PostAsync("api/token/take", formUrlEncodedContent).Result;
            string result2 = result.Content.ReadAsStringAsync().Result;
            result1 = result2.Split(new char[]
            {
                ','
            });
            ketqua = result1[0].Split(new char[]
            {
                ':'
            });
            kq = ketqua[1].Substring(1, ketqua[1].Length - 2);
            if (int.Parse(kq) == 401)
            {
                MessageBox.Show("Lỗi xác thực");
            }
            access = result1[1].Split(new char[]
            {
                ':'
            });
            access1 = access[2].Replace("\"", "");
            idtoken = result1[2].Split(new char[]
            {
                ':'
            });
            token = idtoken[1].Replace("\"", "");
            //FileInfo fileInfo = new FileInfo(lashpath);
            if (System.IO.Directory.Exists(lashpath))
            {
                string[] files = System.IO.Directory.GetFiles(lashpath, "*.xml");
                string[] array = files;
                for (int i = 0; i < array.Length; i++)
                {
                    string text = array[i];
                    byte[] fileHS = System.IO.File.ReadAllBytes(text);
                    // string innerText = "";
                    //byte[] value = null;                   
                    string str = string.Format("token={0}&id_token={1}&username={2}&password={3}&loaiHoSo={4}&maTinh={5}&maCSKCB={6}", new object[]
            {
                access1,
                token,
                "92002_BV",
                password,
                "3",
                "92",
                "92002"
            });
                    HttpResponseMessage result3 = httpClient.PostAsJsonAsync("api/egw/guiHoSoGiamDinh?" + str, fileHS).Result;
                    //WriteLog(result3.Content.ReadAsStringAsync().Result);
                    MessageBox.Show("file log noi tiep " + result3.Content.ReadAsStringAsync().Result);
                    File.Delete(lashpath);

                }
            }



        }
        //public void WriteLog(string Contents)
        //{
        //    try
        //    {
        //        //string path = "\\\\172.251.110.194\\Log\\log.txt";
        //        string path = txtBackup.Text.Trim() + string.Format("\\log_{0}_CanTho.txt", System.DateTime.Now.ToString("yyyyMMdd"));
        //        if (File.Exists(path))
        //        {
        //            File.AppendAllText(path, string.Concat(new string[]
        //            {
        //                "### ",
        //                this.FileName,
        //                "|",
        //                Contents,
        //                Environment.NewLine
        //            }));
        //        }
        //        else
        //        {
        //            File.WriteAllText(path, string.Concat(new string[]
        //            {
        //                "### ",
        //                this.FileName,
        //                "|",
        //                Contents,
        //                Environment.NewLine
        //            }));
        //        }
        //    }
        //    catch
        //    {
        //    }
        //}

        private void chkBxPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBxPass.Checked)
            {
                txtPass.PasswordChar = '\0';
            }
            else
            {
                txtPass.PasswordChar = '*';
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            //string lashpath = txtPathEx.Text.Trim();
            string lashpath = txtPath.Text.Trim();
            string username = txtUser.Text.Trim();
            //string password = txtPass.Text.Trim();
            string password = UTL.MH.CreateMD5(txtPass.Text.Trim());
            string[] result1;
            string[] ketqua;
            string kq;
            string[] access;
            string access1;
            string[] idtoken;
            string token;


            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://egw.baohiemxahoi.gov.vn");
            //httpClient.get_DefaultRequestHeaders().get_Accept().Clear();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            //httpClient.get_DefaultRequestHeaders().get_Accept().Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            Dictionary<string, string> dictionary = new Dictionary<string, string>
            {
                {
                    "username",
                    username
                },
                {
                    "password",
                    password
                }
            };
            FormUrlEncodedContent formUrlEncodedContent = new FormUrlEncodedContent(dictionary);
            HttpResponseMessage result = httpClient.PostAsync("api/token/take", formUrlEncodedContent).Result;
            string result2 = result.Content.ReadAsStringAsync().Result;
            result1 = result2.Split(new char[]
            {
                ','
            });
            ketqua = result1[0].Split(new char[]
            {
                ':'
            });
            kq = ketqua[1].Substring(1, ketqua[1].Length - 2);
            if (int.Parse(kq) == 401)
            {
                MessageBox.Show("Lỗi không được xác thực");
            }
            if (int.Parse(kq) == 500)
            {
                MessageBox.Show("An unexpected error occurred");
            }
            access = result1[1].Split(new char[]
            {
                ':'
            });
            access1 = access[2].Replace("\"", "");
            idtoken = result1[2].Split(new char[]
            {
                ':'
            });
            token = idtoken[1].Replace("\"", "");
            //FileInfo fileInfo = new FileInfo(lashpath);
            if (System.IO.Directory.Exists(lashpath))
            {
                string[] files = System.IO.Directory.GetFiles(lashpath, "*.xml");
                string[] array = files;
                for (int i = 0; i < array.Length; i++)
                {
                    string text = array[i];
                    byte[] fileHS = System.IO.File.ReadAllBytes(text);
                    // string innerText = "";
                    //byte[] value = null;                   
                    string str = string.Format("token={0}&id_token={1}&username={2}&password={3}&loaiHoSo={4}&maTinh={5}&maCSKCB={6}", new object[]
                    {
                        access1,
                        token,
                        username,
                        password,
                        "3",
                        "92",
                        "92002"
                    });
                    HttpResponseMessage result3 = httpClient.PostAsJsonAsync("api/egw/guiHoSoGiamDinh?" + str, fileHS).Result;
                    //WriteLog(result3.Content.ReadAsStringAsync().Result);
                    MessageBox.Show("file log noi tiep " + result3.Content.ReadAsStringAsync().Result);
                    //File.Delete(lashpath);  
                }
            }


        }




    }
}


