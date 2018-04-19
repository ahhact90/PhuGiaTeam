using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using DAL_NhaHang;
using ENTI_NhaHang;
using BUS_NhaHang;

namespace QuanLyNhaHang
{
    public partial class frmSaoLuu : Form
    {

        private SqlConnection connect;
        public frmSaoLuu()
        {
            InitializeComponent();
        }

        public void Connect()
        {
            string con = @"Data Source=.\;Initial Catalog=QLNHAHANG;User ID=sa;Password=123456;";

            try
            {
                connect = new SqlConnection(con);
                connect.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi : " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Disconnect()
        {
            connect.Close();
            connect.Dispose();
        }

        private void KhoiPhucCSDL(SqlConnection ketnoi)
        {
            
            try
            {
                ketnoi = new SqlConnection(@"Data Source="+ txtServer.Text+";Persist Security Info=True;User ID="+txtUs.Text+";Password="+txtPas.Text);
                using (ketnoi)
                {
                    string path =txtNoiLuuKP.Text;
                    string sqlRestore = "Use master Restore Database [QL NHAHANG] from disk='" + path + "'";
                    txtSQL.Text = sqlRestore;
                    SqlCommand cmd = new SqlCommand(sqlRestore, ketnoi);
                    ketnoi.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Đã khôi phục cơ sở dữ liệu ! ");
                }
                ketnoi.Close();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi không khôi pục được !");
                return;
            }
           
        }

        public string xoakhoangtrang(string Text)
        {
            string s = Text.Trim();
            while (s.IndexOf(" ") >= 0)    //tim trong chuoi vi tri co 2 khoang trong tro len       
                s = s.Replace(" ", "_");   //sau do thay the bang 1 khoang trong
            return s;
        }
        private void frmSaoLuu_Load(object sender, EventArgs e)
        {
            //Connect();
        }

        private void btnKetNoi_Click(object sender, EventArgs e)
        {

            cbDataName.Enabled = true;
            btnSauLuu.Enabled = true;
            btnKhoiPhuc.Enabled = true;

        }

        private void btnNgatKN_Click(object sender, EventArgs e)
        {

            cbDataName.Enabled = false;
            btnSauLuu.Enabled = false;
            btnKhoiPhuc.Enabled = false;


        }

        private void cbDataName_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSauLuu.Enabled = true;
            btnKhoiPhuc.Enabled = true;
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog drLuu = new FolderBrowserDialog();
            if (drLuu.ShowDialog() == DialogResult.OK)
            {
                txtNoiLuuSL.Text = drLuu.SelectedPath;
            }
        }

        private void btnChon1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "File Backup (*.bak)|*.bak|All File (*.*|*.*)";
            op.FilterIndex = 0;
            if (op.ShowDialog() == DialogResult.OK)
            {
                txtNoiLuuKP.Text = op.FileName;
            }
        }

        private void btnSauLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNoiLuuSL.Text == "")
                {
                    MessageBox.Show("Xin hãy chọn nơi sao lưu !");
                }
                else
                {

                    string sql = " BACKUP DATABASE [" + cbDataName.Text + "] TO DISK= '" + txtNoiLuuSL.Text + "\\" + xoakhoangtrang(cbDataName.Text) + "-" + DateTime.Now.Ticks.ToString() + ".bak'";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connect;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã sao lưu thành công !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void btnKhoiPhuc_Click(object sender, EventArgs e)
        {
            KhoiPhucCSDL(connect);
//            try
//            {
//                if (txtNoiLuuKP.Text == "")
//                {
//                    MessageBox.Show("Xin hãy chọn file sao lưu !");
//                }
//                else
//                {
//                   // Connect();   
//                    string sql = "RESTORE DATABASE [" + cbDataName.Text + "]  FROM DISK ='" + txtNoiLuuKP.Text + "' WITH REPLACE";
//                    SqlCommand cmd = new SqlCommand();
//                    cmd.Connection = connect;
//                    cmd.CommandType = CommandType.Text;
//                    cmd.CommandText = sql;
//                    cmd.ExecuteNonQuery();
//                    MessageBox.Show("Đã Khôi phục Xong  !");
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(@"Không thể khôi phục được, chức năng tạm thời chưa thực hiện. Liên hệ : 01649573828 để được hưỡng dẫn khôi phục thủ công xin lỗi vì sự bất tiện này (^_^)
//                    , xin cảm ơn ! ");
//                MessageBox.Show("ERROR: " + ex.Message);
//            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {

                string str = @"Data Source=" + txtServer.Text + ";User ID=" + txtUs.Text + " ;Password=" + txtPas.Text;
                connect = new SqlConnection(str);
                connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from sys.databases d where d.database_id>4";
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                cbDataName.Items.Clear();
                while (dr.Read())
                {
                    cbDataName.Items.Add(dr[0].ToString());
                }
                dr.Close();
                cbDataName.Enabled = true;
                btnDisconnect.Enabled = true;
                txtServer.Enabled = false;
                txtUs.Enabled = false;
                txtPas.Enabled = false;
                btnConnect.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            connect.Close();
            connect.Dispose();
            txtPas.Enabled = true;
            txtUs.Enabled = true;
            txtServer.Enabled = true;
            btnConnect.Enabled = true;
        }

        private void frmSauLuu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Disconnect();
        }

        private void txtNoiLuuSL_TextChanged(object sender, EventArgs e)
        {
            if (txtNoiLuuSL.Text != "")
            {
                btnSauLuu.Enabled = true;
            }
        }

        private void txtNoiLuuKP_TextChanged(object sender, EventArgs e)
        {
            if (txtNoiLuuKP.Text != "")
            {
                btnKhoiPhuc.Enabled = true;
            }
        }
    }
}
