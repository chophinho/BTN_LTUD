using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QL_KHACH_SAN
{
    public partial class frmChiTietHoaDon : Form
    {
        KetNoi ketNoi = new KetNoi(); // Kết nối cơ sở dữ liệu
        public static string MaHoaDon; // Mã hóa đơn truyền từ frmHoaDon

        public frmChiTietHoaDon()
        {
            InitializeComponent();
        }

        // Khi form được load
        private void frmChiTietHoaDon_Load(object sender, EventArgs e)
        {
            LoadChiTietHoaDon(MaHoaDon);
        }

        // Load chi tiết hóa đơn
        private void LoadChiTietHoaDon(string maHoaDon)
        {
            string query = "SELECT * FROM CHITIETHOADON WHERE MaHoaDon = @MaHoaDon";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaHoaDon", maHoaDon)
            };
            DataTable data = ketNoi.LayDuLieu(query, parameters);
            dgvChiTietHoaDon.DataSource = data;
        }

        // Sự kiện khi nhấn nút thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng form Chi Tiết Hóa Đơn
        }
    }
}
