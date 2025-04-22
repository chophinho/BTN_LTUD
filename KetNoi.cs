using System;
using System.Data;
using System.Data.SqlClient;

namespace QL_KHACH_SAN
{
    internal class KetNoi
    {
        public SqlConnection cnn;
        public SqlCommand cmd;
        public DataTable dta;
        public SqlDataAdapter ada;
        // Kết nối vào cơ sở dữ liệu
        public void KetNoiDatabase()
        {
            string strKetNoi = @"Data Source=DESKTOP-VU594HI\PHUONG;Initial Catalog=QLKhachSan;Integrated Security=True";
            cnn = new SqlConnection(strKetNoi);
            cnn.Open();
        }

        // Đóng kết nối
        public void HuyKetNoi()
        {
            if (cnn.State == ConnectionState.Open) cnn.Close();
        }

        // Phương thức lấy dữ liệu với câu lệnh SQL và tham số
        public DataTable LayDuLieu(string Sql, SqlParameter[] prms = null)
        {
            KetNoiDatabase();
            cmd = new SqlCommand(Sql, cnn);

            // Nếu có tham số, thêm tham số vào lệnh SQL
            if (prms != null)
            {
                cmd.Parameters.AddRange(prms);
            }

            ada = new SqlDataAdapter(cmd);
            dta = new DataTable();
            ada.Fill(dta);
            HuyKetNoi();
            return dta;
        }

        // Phương thức thực thi thủ tục có tham số
        public void ThucThi(string query, SqlParameter[] parameters)
        {
            KetNoiDatabase();
            cmd = new SqlCommand(query, cnn);
            cmd.CommandType = CommandType.Text; // Quan trọng

            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }

            cmd.ExecuteNonQuery();
            HuyKetNoi();
        }
        public void ThucThi2(string sql)
        {
            KetNoiDatabase();
            cmd = new SqlCommand(sql, cnn);
            cmd.ExecuteNonQuery();
            HuyKetNoi();
        }
    }
}
