using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QL_KHACH_SAN
{
    public partial class frmDatPhong : Form
    {
        private KetNoi ketNoi = new KetNoi(); // Kết nối cơ sở dữ liệu

        public frmDatPhong()
        {
            InitializeComponent();
            LoadPhong();
            LoadKhachHang();
        }

        // Phương thức để tải danh sách phòng vào ComboBox
        private void LoadPhong()
        {
            try
            {
                // Câu lệnh SQL để lấy danh sách phòng có trạng thái "Trống"
                string sql = "SELECT MaPhong FROM PHONG WHERE TrangThai = 'Trống'";
                SqlParameter[] parameters = null;

                // Lấy dữ liệu từ cơ sở dữ liệu
                DataTable dtPhong = ketNoi.LayDuLieu(sql, parameters);

                // Xóa các mục cũ trong ComboBox
                cboMaPhong.Items.Clear();

                // Thêm mã phòng vào ComboBox
                foreach (DataRow row in dtPhong.Rows)
                {
                    cboMaPhong.Items.Add(row["MaPhong"].ToString());
                }

                // Nếu có ít nhất một phòng, chọn phòng đầu tiên
                if (cboMaPhong.Items.Count > 0)
                {
                    cboMaPhong.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách phòng: " + ex.Message);
            }
        }

        // Phương thức để tải danh sách khách hàng vào ComboBox
        private void LoadKhachHang()
        {
            try
            {
                // Câu lệnh SQL để lấy danh sách khách hàng
                string sql = "SELECT MaKhachHang, HoTen FROM KHACHHANG";
                SqlParameter[] parameters = null;

                // Lấy dữ liệu từ cơ sở dữ liệu
                DataTable dtKhachHang = ketNoi.LayDuLieu(sql, parameters);

                // Xóa các mục cũ trong ComboBox
                cboMaKhachHang.Items.Clear();

                // Thêm khách hàng vào ComboBox
                foreach (DataRow row in dtKhachHang.Rows)
                {
                    cboMaKhachHang.Items.Add(row["MaKhachHang"].ToString());
                }

                // Nếu có ít nhất một khách hàng, chọn khách hàng đầu tiên
                if (cboMaKhachHang.Items.Count > 0)
                {
                    cboMaKhachHang.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách khách hàng: " + ex.Message);
            }
        }

        // Xử lý khi nhấn nút Đặt Phòng
        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ ComboBox và DateTimePicker
                string maKhachHang = cboMaKhachHang.SelectedItem.ToString();
                string maPhong = cboMaPhong.SelectedItem.ToString();
                DateTime ngayNhanPhong = dtpNgayNhanPhong.Value;
                DateTime ngayTraPhong = dtpNgayTraPhong.Value;

                // Kiểm tra thông tin hợp lệ
                if (string.IsNullOrEmpty(maKhachHang) || string.IsNullOrEmpty(maPhong))
                {
                    MessageBox.Show("Vui lòng chọn khách hàng và phòng.");
                    return;
                }

                // Thực hiện thao tác đặt phòng
                string sqlInsert = "INSERT INTO DATPHONG (MaKhachHang, MaPhong, NgayNhanPhong, NgayTraPhong) " +
                                   "VALUES (@MaKhachHang, @MaPhong, @NgayNhanPhong, @NgayTraPhong)";

                SqlParameter[] parameters = {
                    new SqlParameter("@MaKhachHang", maKhachHang),
                    new SqlParameter("@MaPhong", maPhong),
                    new SqlParameter("@NgayNhanPhong", ngayNhanPhong),
                    new SqlParameter("@NgayTraPhong", ngayTraPhong)
                };

                ketNoi.ThucThi(sqlInsert, parameters);

                // Cập nhật trạng thái phòng
                string sqlUpdate = "UPDATE PHONG SET TrangThai = 'Đã đặt' WHERE MaPhong = @MaPhong";
                SqlParameter[] parametersUpdate = {
                    new SqlParameter("@MaPhong", maPhong)
                };

                ketNoi.ThucThi(sqlUpdate, parametersUpdate);

                MessageBox.Show("Đặt phòng thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đặt phòng: " + ex.Message);
            }
        }
    }
}
