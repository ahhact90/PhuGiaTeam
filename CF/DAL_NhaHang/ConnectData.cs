using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL_NhaHang
{
    public class ConnectData
    {
        public static SqlConnection conn;

        //-------------------mở kết nối CSDL--
        public void MoKetNoi()
        {
            if (ConnectData.conn == null)
                ConnectData.conn = new SqlConnection(@"Data Source=THOMAS\SQLEXPRESS;Initial Catalog=QLNHAHANG;User ID=sa;Password=123456;");
                
                if (ConnectData.conn.State != ConnectionState.Open)
                    ConnectData.conn.Open();
        }
        public void NgatKetNoi()
        {
            if (ConnectData.conn.State == ConnectionState.Open)
                ConnectData.conn.Close();
        }
        public void ThucThiSQL(string SQL)
        {
            MoKetNoi();
            SqlCommand cmd = new SqlCommand(SQL, ConnectData.conn);
            cmd.ExecuteNonQuery();
            NgatKetNoi();
        }

        public DataTable LayDuLieu(string SQL)
        {
            MoKetNoi();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(SQL, ConnectData.conn);
            da.Fill(dt);
            NgatKetNoi();
            return dt;
        }
        public string LayGiaTri(string SQL)
        {
            string tam = null;
            MoKetNoi();
            SqlCommand cmd = new SqlCommand(SQL, ConnectData.conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                tam = dr[0].ToString();
                
            }
            NgatKetNoi();
            return tam;
        }


    }
}
