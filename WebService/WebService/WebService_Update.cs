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
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace WebService
{
    public partial class WebService_Update : Form
    {
        public Topic tmp1;
        public WebService_Update()
        {
            InitializeComponent();
            

        }
        private void upwebservice()
        {
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

        private void btnCheck_Click(object sender, EventArgs e)
        {
           
            string mathe = txtMathe.Text.Trim(); 
            string hoten = txtHoten.Text.Trim();
            string ngaysinh = txtNamsinh.Text.Trim(); 
            if (ngaysinh.Length <= 4)
	            {
                     ngaysinh = System.DateTime.ParseExact(ngaysinh, "yyyy", null).ToString("yyyy");
	            }   
                                 else
	            {
                     ngaysinh = System.DateTime.ParseExact(ngaysinh, "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
	            }                      
            //MessageBox.Show(ngaysinh);
           // int gioitinh = int.Parse(txtsex.Text.Trim());
            int gioitinh = comboSex.SelectedIndex + 1;
            //string tungay = System.DateTime.ParseExact(txtTuNgay.Text.Trim(), "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
            //string denngay = System.DateTime.ParseExact(txtDenngay.Text.Trim(), "dd/MM/yyyy", null).ToString("dd/MM/yyyy");
            string macskcb = txtCskcb.Text.Trim();
            string result5;
            string username = txtUser.Text.Trim();
            string password = UTL.MH.CreateMD5(txtPass.Text.Trim());
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://egw.baohiemxahoi.gov.vn");
            httpClient.MaxResponseContentBufferSize = 2000005000L;
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            System.Collections.Generic.Dictionary<string, string> nameValueCollection = new System.Collections.Generic.Dictionary<string, string>
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
            FormUrlEncodedContent content = new FormUrlEncodedContent(nameValueCollection);
            HttpResponseMessage result = httpClient.PostAsync("api/token/take", content).Result;
            string result2 = result.Content.ReadAsStringAsync().Result;
            string[] array = result2.Split(new char[]
						{
							','
						});
            string[] array2 = array[0].Split(new char[]
						{
							':'
						});
            string s = array2[1].Substring(1, checked(array2[1].Length - 2));
            bool flag = int.Parse(s) == 401;
            int num = 2;
            while (true)
            {
                switch (num)
                {
                    case 0:
                        goto IL_341;
                    case 1:
                        goto IL_352;
                    case 2:
                        {
                            if (flag)
                            {
                                num = 4;
                                continue;
                            }
                            string[] array3 = array[1].Split(new char[]
								{
									':'
								});
                            string text3 = array3[2].Replace("\"", "");
                            string[] array4 = array[2].Split(new char[]
								{
									':'

								});
                            string text4 = array4[1].Replace("\"", "");                            
                            theBHYT value = new theBHYT
                            {
                                maThe = mathe,
                                hoTen = hoten,
                                ngaySinh = ngaysinh,
                                gioiTinh = gioitinh,
                                maCSKCB = macskcb,
                              
                            };
                           
                            string str = string.Format("token={0}&id_token={1}&username={2}&password={3}", new object[]
								{
									text3,
									text4,
									username,
									password
								});
                            HttpResponseMessage result3 = httpClient.PostAsJsonAsync(System.Convert.ToString("api/egw/KQNhanLichSuKCB595?") + str, value).Result;
                            string tmp = result3.Content.ReadAsStringAsync().Result;

                            try
                            {
                               
                                this.tmp1 = (Topic)JsonConvert.DeserializeObject(tmp, typeof(Topic));
                                string kq = "";
                                gridControl1.DataSource = null;
                                string maKetQua = this.tmp1.MaKetQua;
                                switch (maKetQua)
                                {
                                    case "000":
                                        kq = "Thông tin thẻ chính xác";
                                        break;
                                    case "001":
                                        kq = "Thẻ do BHXH Bộ Quốc Phòng quản lý, đề nghị kiểm tra thẻ và thông tin giấy tờ tùy thân";
                                        break;
                                    case "002":
                                        kq = "Thẻ do BHXH Bộ Công An quản lý, đề nghị kiểm tra thẻ và thông tin giấy tờ tùy thân";
                                        break;
                                    case "010":
                                        kq = "Thẻ hết giá trị sử dụng";
                                        break;
                                    case "051":
                                        kq = "Mã Thẻ không đúng";
                                        break;
                                    case "052":
                                        kq = "Mã tỉnh cấp thể ( kí tự 4,5 của mã thẻ ) không đúng";
                                        break;
                                    case "053":
                                        kq = "Mã quyền lợi thẻ (kí tự thứ 3 của mã thẻ ) không đúng";
                                        break;
                                    case "050":
                                        kq = "Không thấy thông tin thẻ";
                                        break;
                                    case "060":
                                        kq = "Thẻ sai họ tên";
                                        break;
                                    case "061":
                                        kq = "Thẻ sai họ tên ( kí tự đầu)";
                                        break;
                                    case "070":
                                        kq = "Thẻ sai ngày sinh";
                                        break;
                                    case "080":
                                        kq = "Thẻ sai giới tính";
                                        break;
                                    case "090":
                                        kq = "Thẻ sai nơi đăng ký KCB ban đầu";
                                        break;
                                    case "100":
                                        kq = "Lỗi khi lấy dữ liệu số thẻ";
                                        break;
                                    case "101":
                                        kq = "Lỗi server";
                                        break;
                                    case "110":
                                        kq = "Thẻ đã thu hồi";
                                        break;
                                    case "120":
                                        kq = "Thẻ đã báo giảm";
                                        break;
                                    case "121":
                                        kq = "Thẻ đã báo giảm. Giảm chuyển ngoại tỉnh";
                                        break;
                                    case "122":
                                        kq = "Thẻ đã báo giảm. Giảm chuyển nội tỉnh";
                                        break;
                                    case "123":
                                        kq = "Thẻ đã báo giảm. Thu hồi do tăng lại cùng đơn vị";
                                        break;
                                    case "124":
                                        kq = "Thẻ đã báo giảm. Ngừng tham gia";
                                        break;
                                    case "130":
                                        kq = "Trẻ em không xuất trình thẻ";
                                        break;
                                }
                                if (this.tmp1.MaKetQua == "000")
                                {
                                    string kq2 = string.Format("Thông Báo : {0} | Họ Tên : {1}| Giới tính : {2}| Địa chỉ : {3}| Nơi KCBBĐ : {4}| Hạn Thẻ : Từ ngày : {5}- Đến Ngày : {6}", new object[]
					{
						kq,
						this.tmp1.hoten,
						this.tmp1.gioitinh,
						this.tmp1.diachi,
						this.tmp1.madkbd,
						this.tmp1.gtTheTu,
						this.tmp1.gtTheDen
					});
                                    this.thongbao.Text = kq2;
                                    //this.code = this.txtmathe.Text + this.tmp1.madkbd;
                                   // this.client2.srv_hms_Log_check_insurance(this.txtmathe.Text, this.txthoten.Text, this.txtngaysinh.Text, this.txtgiotinh.SelectedIndex + 1, this.txttungay.Text, this.txtdenngay.Text, this.txtcskcb.Text, kq2, this.UserID.ToString(), this.IP);
                                    if (this.tmp1.dsLichSuKCB != null)
                                    {
                                        DataTable dt = new DataTable();
                                        dt.Columns.Add("maHoSo");
                                        dt.Columns.Add("maCSKCB");
                                        dt.Columns.Add("tuNgay");
                                        dt.Columns.Add("denNgay");
                                        dt.Columns.Add("tenBenh");
                                        dt.Columns.Add("tinhTrang");
                                        dt.Columns.Add("kqDieuTri");
                                        for (int i = 0; i < this.tmp1.dsLichSuKCB.Length; i++)
                                        {
                                            DataRow dr = dt.NewRow();
                                            dr[0] = this.tmp1.dsLichSuKCB[i].mahoso;
                                            dr[1] = this.tmp1.dsLichSuKCB[i].maCSKCB;
                                            dr[2] = this.tmp1.dsLichSuKCB[i].tuNgay;
                                            dr[3] = this.tmp1.dsLichSuKCB[i].denNgay;
                                            dr[4] = this.tmp1.dsLichSuKCB[i].tenBenh;
                                            dr[5] = this.tmp1.dsLichSuKCB[i].tinhTrang;
                                            dr[6] = this.tmp1.dsLichSuKCB[i].kqDieuTri;
                                            dt.Rows.Add(dr);
                                        }
                                        gridControl1.DataSource = dt;
                                    }
                                }
                                else
                                {
                                   thongbao.Text = kq;
                                    //this.client2.srv_hms_Log_check_insurance(this.txtmathe.Text, this.txthoten.Text, this.txtngaysinh.Text, this.txtgiotinh.SelectedIndex + 1, this.txttungay.Text, this.txtdenngay.Text, this.txtcskcb.Text, kq, this.UserID.ToString(), this.IP);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                                MessageBox.Show("Không thể check thông tuyến,Vui lòng kiểm tra thông tin nhập vào", "ERR");
                            }

                            num = 3;
                            continue;
                        }
                    case 3:
                        goto IL_32D;
                    case 4:
                        result5 = "<THE_BHYT>Lỗi xác thực cổng trực tuyến</THE_BHYT>";
                        MessageBox.Show(result5);
                        num = 0;
                        continue;
                }
                IL_341:
                IL_32D:
                IL_352:
                break;
            }
        }
        public void WriteLog(string Contents)
        {
            try
            {
                string path = "E:\\Log\\log.txt";
                if (File.Exists(path))
                {
                    File.AppendAllText(path, string.Concat(new string[]
					{						
						Contents,
						Environment.NewLine
					}));
                }
                else
                {
                    File.WriteAllText(path, string.Concat(new string[]
					{
						Contents,
						Environment.NewLine
					}));
                }
            }
            catch
            {
            }
        }
        private void WebService_Update_Load(object sender, EventArgs e)
        {
            txtTinh.Text = @"92";
            txtCSKB.Text = @"92002";
            txtUser.Text = @"92002_BV";
            txtPass.Text = @"benhvien@121";
            txtCskcb.Text = @"92002";
        }
        /// <summary>
        /// Tao DataTable mấu
        /// </summary>
        /// <param name="animaltype"></param>
        /// <returns></returns>
        public static DataTable CreateDataTable(Type animaltype)
        {
            DataTable return_Datatable = new DataTable();
            PropertyInfo[] properties = animaltype.GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                PropertyInfo info = properties[i];
                return_Datatable.Columns.Add(new DataColumn(info.Name, info.PropertyType));
            }
            return return_Datatable;
        }
        /// <summary>
        /// Thay đổi định dạng ngày tháng năm
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private string changedate(string date)
        {
            string result;
            try
            {
                if (date.Length == 4)
                {
                    result = date;
                }
                else
                {
                    string[] temp = date.Split(new char[]
					{
						'/'
					});
                    if (int.Parse(temp[0]) > 31)
                    {
                        MessageBox.Show("số ngày không được lớn hơn 31");
                        result = "";
                    }
                    else if (int.Parse(temp[1]) > 12)
                    {
                        MessageBox.Show("số tháng không được lớn hơn 12");
                        result = "";
                    }
                    else
                    {
                        if (temp[0].Length == 1)
                        {
                            temp[0] = "0" + temp[0];
                        }
                        if (temp[1].Length == 1)
                        {
                            temp[1] = "0" + temp[1];
                        }
                        result = string.Format("{0}{1}{2}", temp[2], temp[1], temp[0]);
                    }
                }
            }
            catch
            {
                result = "";
            }
            return result;
        }

    }
}


