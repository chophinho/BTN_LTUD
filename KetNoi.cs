﻿using System;
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
            string strKetNoi = @"Data Source=DESKTOP-BVO9EPH\SQLEXPRESS;Initial Catalog=QLKhachSan;Integrated Security=True";
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

        // Phương thức thực thi câu lệnh SQL mà không trả về dữ liệu
        public void ThucThi(string sql, SqlParameter[] parameters)
        {
            KetNoiDatabase();
            cmd = new SqlCommand(sql, cnn);

            // Thêm các tham số vào lệnh SQL
            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }

            cmd.ExecuteNonQuery();
            HuyKetNoi();
        }
    }
}
