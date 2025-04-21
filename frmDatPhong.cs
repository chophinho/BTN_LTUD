using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QL_KHACH_SAN
{
    public partial class frmDatPhong : Form
    {
        KetNoi kn = new KetNoi();

        public frmDatPhong()
        {
            InitializeComponent();
            LoadKhachHang();
            LoadPhongTrong();
            LoadNhanVien();
            dtpNgayDat.Value = DateTime.Now;
            dtpNgayNhanPhong.Value = DateTime.Now.AddDays(1);
        }

        private void LoadKhachHang()
        {
            string sql = "SELECT MaKhachHang, HoTen FROM KHACHHANG";
            DataTable dt = kn.LayDuLieu(sql);
            cboKhachHang.DataSource = dt;
            cboKhachHang.DisplayMember = "HoTen";
            cboKhachHang.ValueMember = "MaKhachHang";
        }

        private void LoadPhongTrong()
        {
            string sql = "SELECT P.MaPhong, P.SoPhong, LP.TenLoaiPhong, LP.GiaPhong " +
                          "FROM PHONG P INNER JOIN LOAIPHONG LP ON P.MaLoaiPhong = LP.MaLoaiPhong " +
                          "WHERE P.TrangThai = N'Trống'";
            DataTable dt = kn.LayDuLieu(sql);
            dgvPhong.DataSource = dt;
        }

        private void LoadNhanVien()
        {
            string sql = "SELECT MaNhanVien, HoTen FROM NHANVIEN";
            DataTable dt = kn.LayDuLieu(sql);
            cboNhanVien.DataSource = dt;
            cboNhanVien.DisplayMember = "HoTen";
            cboNhanVien.ValueMember = "MaNhanVien";
        }

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            if (dgvPhong.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn phòng cần đặt!");
                return;
            }

            // Lấy thông tin từ form
            string maKhachHang = cboKhachHang.SelectedValue.ToString();
            string maPhong = dgvPhong.SelectedRows[0].Cells["MaPhong"].Value.ToString();
            string maNhanVien = cboNhanVien.SelectedValue.ToString();
            DateTime ngayDat = dtpNgayDat.Value;
            DateTime ngayNhan = dtpNgayNhanPhong.Value;
            DateTime ngayTra = dtpNgayTraPhong.Value;
            decimal giaPhong = Convert.ToDecimal(dgvPhong.SelectedRows[0].Cells["GiaPhong"].Value);
            MessageBox.Show("Giá phòng: " + giaPhong);  // Debugging giá phòng
                                                        // Tính số ngày thuê
            TimeSpan soNgayThue = ngayTra - ngayNhan;
            if (soNgayThue.Days < 0)
            {
                MessageBox.Show("Ngày trả phòng không thể trước ngày nhận phòng.");
                return;
            }

            int tongTien = (int)(soNgayThue.Days * giaPhong);
            MessageBox.Show("Tổng tiền: " + tongTien);  // Debugging tổng tiền

            try
            {
                kn.KetNoiDatabase();

                // Bắt đầu transaction
                SqlTransaction transaction = kn.cnn.BeginTransaction();

                try
                {
                    // 1. Tạo mã đặt phòng mới
                    string maDatPhong = TaoMaMoi("DP", "DATPHONG", "MaDatPhong", kn.cnn, transaction);

                    // 2. Thêm vào bảng DATPHONG
                    string sqlDatPhong = "INSERT INTO DATPHONG (MaDatPhong, MaKhachHang, MaPhong, NgayDat, NgayNhanPhong, NgayTraPhong, TrangThai) " +
                                        "VALUES (@MaDatPhong, @MaKhachHang, @MaPhong, @NgayDat, @NgayNhanPhong, @NgayTraPhong, N'Đã đặt')";

                    SqlCommand cmdDatPhong = new SqlCommand(sqlDatPhong, kn.cnn, transaction);
                    cmdDatPhong.Parameters.AddWithValue("@MaDatPhong", maDatPhong);
                    cmdDatPhong.Parameters.AddWithValue("@MaKhachHang", maKhachHang);
                    cmdDatPhong.Parameters.AddWithValue("@MaPhong", maPhong);
                    cmdDatPhong.Parameters.AddWithValue("@NgayDat", ngayDat);
                    cmdDatPhong.Parameters.AddWithValue("@NgayNhanPhong", ngayNhan);
                    cmdDatPhong.Parameters.AddWithValue("@NgayTraPhong", ngayTra);
                    cmdDatPhong.ExecuteNonQuery();

                    // 3. Cập nhật trạng thái phòng
                    string sqlUpdatePhong = "UPDATE PHONG SET TrangThai = N'Đang sử dụng' WHERE MaPhong = @MaPhong";
                    SqlCommand cmdUpdatePhong = new SqlCommand(sqlUpdatePhong, kn.cnn, transaction);
                    cmdUpdatePhong.Parameters.AddWithValue("@MaPhong", maPhong);
                    cmdUpdatePhong.ExecuteNonQuery();

                    // 4. Tạo hóa đơn
                    string maHoaDon = TaoMaMoi("HD", "HOADON", "MaHoaDon", kn.cnn, transaction);

                    string sqlHoaDon = "INSERT INTO HOADON (MaHoaDon, MaKhachHang, MaNhanVien, NgayTao, Thue, TongTien, TinhTrangThanhToan) " +
                                      "VALUES (@MaHoaDon, @MaKhachHang, @MaNhanVien, @NgayTao, @Thue, @TongTien, N'Chưa thanh toán')";

                    SqlCommand cmdHoaDon = new SqlCommand(sqlHoaDon, kn.cnn, transaction);
                    cmdHoaDon.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                    cmdHoaDon.Parameters.AddWithValue("@MaKhachHang", maKhachHang);
                    cmdHoaDon.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    cmdHoaDon.Parameters.AddWithValue("@NgayTao", DateTime.Now);
                    cmdHoaDon.Parameters.AddWithValue("@Thue", 10.0); // Thuế 10%
                    cmdHoaDon.Parameters.AddWithValue("@TongTien", tongTien);
                    cmdHoaDon.ExecuteNonQuery();

                    // 5. Thêm chi tiết hóa đơn
                    string maCTHD = TaoMaMoi("CT", "CHITIETHOADON", "MaChiTietHoaDon", kn.cnn, transaction);

                    string sqlCTHD = "INSERT INTO CHITIETHOADON (MaChiTietHoaDon, MaHoaDon, MaPhong, NgayNhanPhong, NgayTraPhong) " +
                 "VALUES (@MaChiTietHoaDon, @MaHoaDon, @MaPhong, @NgayNhanPhong, @NgayTraPhong)";

                    SqlCommand cmdCTHD = new SqlCommand(sqlCTHD, kn.cnn, transaction);
                    cmdCTHD.Parameters.AddWithValue("@MaChiTietHoaDon", maCTHD);
                    cmdCTHD.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                    cmdCTHD.Parameters.AddWithValue("@MaPhong", maPhong);
                    cmdCTHD.Parameters.AddWithValue("@NgayNhanPhong", ngayNhan);
                    cmdCTHD.Parameters.AddWithValue("@NgayTraPhong", ngayTra);
                    cmdCTHD.ExecuteNonQuery();

                    // Commit transaction nếu mọi thứ thành công
                    transaction.Commit();

                    MessageBox.Show("Đặt phòng thành công! Mã hóa đơn: " + maHoaDon);
                    LoadPhongTrong(); // Refresh danh sách phòng
                }
                catch (Exception ex)
                {
                    // Rollback nếu có lỗi
                    transaction.Rollback();
                    MessageBox.Show("Lỗi khi đặt phòng: " + ex.Message);
                }
                finally
                {
                    kn.HuyKetNoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }

        // Hàm tạo mã mới tự động
        private string TaoMaMoi(string prefix, string tableName, string columnName, SqlConnection connection, SqlTransaction transaction)
        {
            string sql = $"SELECT MAX({columnName}) FROM {tableName} WHERE {columnName} LIKE '{prefix}%'";
            SqlCommand cmd = new SqlCommand(sql, connection, transaction);
            string lastCode = cmd.ExecuteScalar()?.ToString();

            if (string.IsNullOrEmpty(lastCode))
            {
                return prefix + "01"; // Giảm số ký tự
            }
            else
            {
                int number = int.Parse(lastCode.Substring(prefix.Length)) + 1;
                return prefix + number.ToString("D2"); // Chỉ dùng 2 chữ số
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}