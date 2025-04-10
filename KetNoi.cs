using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_KHACH_SAN
{
    internal class KetNoi
    {
        public SqlConnection cnn;
        public SqlCommand cmd;
        public DataTable dta;
        public SqlDataAdapter ada;

        public void KetNoiDatabase()
        {
            
            string strKetNoi = @"Data Source=DESKTOP-VU594HI\PHUONG;Initial Catalog=QL_KhachSan;Integrated Security=True";
            cnn = new SqlConnection(strKetNoi);
            cnn.Open();
        }
        public void HuyKetNoi()
        {
            if (cnn.State == ConnectionState.Open) cnn.Close();
        }
        public DataTable LayDuLieu(string Sql)
        {
            KetNoiDatabase();
            ada = new SqlDataAdapter(Sql, cnn);
            dta = new DataTable();
            ada.Fill(dta);
            return dta;
        }
        public void ThucThi(string sql)
        {
            KetNoiDatabase();
            cmd = new SqlCommand(sql, cnn);
            cmd.ExecuteNonQuery();
            HuyKetNoi();
        }
    }
}
