using QL_KHACH_SAN;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QL_KHACHSAN
{
    public partial class frmThongKeDoanhThu : Form
    {
        KetNoi kn = new KetNoi();

        public frmThongKeDoanhThu()
        {
            InitializeComponent();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            string tieuChi = cboTieuChi.SelectedItem.ToString();
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date;
            string sql = "";

            if (tieuChi == "Ngày")
            {
                sql = @"SELECT NgayTao AS [Thời gian], SUM(TongTien) AS [Doanh thu] 
                        FROM HOADON 
                        WHERE NgayTao BETWEEN @TuNgay AND @DenNgay 
                        GROUP BY NgayTao";
            }
            else if (tieuChi == "Tháng")
            {
                sql = @"SELECT FORMAT(NgayTao, 'MM/yyyy') AS [Thời gian], SUM(TongTien) AS [Doanh thu] 
                        FROM HOADON 
                        WHERE NgayTao BETWEEN @TuNgay AND @DenNgay 
                        GROUP BY FORMAT(NgayTao, 'MM/yyyy')";
            }
            else if (tieuChi == "Năm")
            {
                sql = @"SELECT YEAR(NgayTao) AS [Thời gian], SUM(TongTien) AS [Doanh thu] 
                        FROM HOADON 
                        WHERE NgayTao BETWEEN @TuNgay AND @DenNgay 
                        GROUP BY YEAR(NgayTao)";
            }

            SqlParameter[] prms = new SqlParameter[]
            {
                new SqlParameter("@TuNgay", tuNgay),
                new SqlParameter("@DenNgay", denNgay)
            };

            DataTable dt = kn.LayDuLieu(sql, prms);
            dgvDoanhThu.DataSource = dt;

            // Tính tổng doanh thu
            int tong = 0;
            foreach (DataRow row in dt.Rows)
            {
                tong += Convert.ToInt32(row["Doanh thu"]);
            }

            txtTongTien.Text = tong.ToString("N0") + " VNĐ";
        }
    }
}
