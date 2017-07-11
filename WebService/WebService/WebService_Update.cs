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
            string lashpath;
            string username;
            string password;
            string [] result1;            
            string [] ketqua;
            string kq;
            string [] access;
            string access1;
            string [] idtoken;
            string token;


            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://egw.baohiemxahoi.gov.vn");
            httpClient.get_DefaultRequestHeaders().get_Accept().Clear();
            httpClient.get_DefaultRequestHeaders().get_Accept().Add(new MediaTypeWithQualityHeaderValue("application/json"));
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
            FileInfo fileInfo = new FileInfo(lashpath);
            byte[] value = null;
            using (FileStream fileStream = fileInfo.OpenRead())
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    fileStream.CopyTo(memoryStream);
                    value = memoryStream.ToArray();
                }
            }
            string str = string.Format("token={0}&id_token={1}&username={2}&password={3}&loaiHoSo={4}&maTinh={5}&maCSKCB={6}", new object[]
            {
                access1,
                token,
                "92002_BV",
                "dfe99ede6292051396d3cbea73f4985d",
                "3",
                "92",
                "92002"
            });
            HttpResponseMessage result3 = httpClient.PostAsJsonAsync("api/egw/guiHoSoGiamDinh?" + str, value).Result;
            //WriteLog(result3.Content.ReadAsStringAsync().Result);
            File.Delete(lashpath);
        }
    }
}
