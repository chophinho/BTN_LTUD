using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_KHACH_SAN
{
    internal class KetNoi2
    {
        public SqlConnection cnn;
        public SqlCommand cmd;
        public DataTable dta;
        public SqlDataAdapter ada;

        public void KetNoi()
        {
            string strKetNoi = @"Data Source=DESKTOP-VU594HI\PHUONG;Initial Catalog=QLKhachSan;Integrated Security=True";
            cnn = new SqlConnection(strKetNoi);
            cnn.Open();
        }
        public void HuyKetNoi()
        {
            if (cnn.State == ConnectionState.Open) cnn.Close();
        }
        public DataTable LayDuLieu(string Sql)
        {
            KetNoi();
            ada = new SqlDataAdapter(Sql, cnn);
            dta = new DataTable();
            ada.Fill(dta);
            return dta;
        }
        public void ThucThi(string sql)
        {
            KetNoi();
            cmd = new SqlCommand(sql, cnn);
            cmd.ExecuteNonQuery();
            HuyKetNoi();
        }
    }
}
