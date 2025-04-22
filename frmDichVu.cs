using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QL_KHACH_SAN
{
    public partial class frmDichVu : Form
    {
        KetNoi kn = new KetNoi();

        public frmDichVu()
        {
            InitializeComponent();
            LoadDanhSachDichVu();
            LoadPhongDangThue();
        }

        private void LoadDanhSachDichVu()
        {
            string sql = "SELECT * FROM DICHVU";
            DataTable dt = kn.LayDuLieu(sql);
            dgvDichVu.DataSource = dt;
        }

        private void LoadPhongDangThue()
        {
            string sql = @"SELECT P.MaPhong, P.SoPhong, LP.TenLoaiPhong, DP.MaDatPhong, KH.HoTen AS TenKhachHang
                          FROM PHONG P
                          INNER JOIN LOAIPHONG LP ON P.MaLoaiPhong = LP.MaLoaiPhong
                          INNER JOIN DATPHONG DP ON P.MaPhong = DP.MaPhong
                          INNER JOIN KHACHHANG KH ON DP.MaKhachHang = KH.MaKhachHang
                          WHERE P.TrangThai = N'Đang sử dụng'";
            DataTable dt = kn.LayDuLieu(sql);
            cboPhong.DataSource = dt;
            cboPhong.DisplayMember = "SoPhong";
            cboPhong.ValueMember = "MaPhong";
        }

        private void btnThemDichVu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenDichVu.Text) || string.IsNullOrEmpty(txtGiaDichVu.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin dịch vụ");
                return;
            }

            try
            {
                string maDichVu = TaoMaMoi("DV", "DICHVU", "MaDichVu");
                string tenDichVu = txtTenDichVu.Text;
                int giaDichVu = Convert.ToInt32(txtGiaDichVu.Text);
                string moTa = txtMoTa.Text;

                string sql = "INSERT INTO DICHVU (MaDichVu, TenDichVu, GiaDichVu, MoTa) " +
                             "VALUES (@MaDichVu, @TenDichVu, @GiaDichVu, @MoTa)";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaDichVu", maDichVu),
                    new SqlParameter("@TenDichVu", tenDichVu),
                    new SqlParameter("@GiaDichVu", giaDichVu),
                    new SqlParameter("@MoTa", moTa)
                };

                kn.ThucThi(sql, parameters);
                MessageBox.Show("Thêm dịch vụ mới thành công!");
                LoadDanhSachDichVu();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dịch vụ: " + ex.Message);
            }
        }

        private void btnThemVaoPhong_Click(object sender, EventArgs e)
        {
            if (dgvDichVu.SelectedRows.Count == 0 || cboPhong.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn phòng và dịch vụ cần thêm");
                return;
            }

            string maPhong = cboPhong.SelectedValue.ToString();
            string maDichVu = dgvDichVu.SelectedRows[0].Cells["MaDichVu"].Value.ToString();
            int soLuong = (int)nudSoLuong.Value;
            int giaDichVu = Convert.ToInt32(dgvDichVu.SelectedRows[0].Cells["GiaDichVu"].Value);

            try
            {
                kn.KetNoiDatabase();

                // 1. Tìm hóa đơn chưa thanh toán của phòng này
                string sqlTimHoaDon = @"SELECT TOP 1 HD.MaHoaDon 
                                      FROM HOADON HD
                                      INNER JOIN CHITIETHOADON CTHD ON HD.MaHoaDon = CTHD.MaHoaDon
                                      WHERE CTHD.MaPhong = @MaPhong AND HD.TinhTrangThanhToan = N'Chưa thanh toán'";

                SqlCommand cmdTimHoaDon = new SqlCommand(sqlTimHoaDon, kn.cnn);
                cmdTimHoaDon.Parameters.AddWithValue("@MaPhong", maPhong);
                string maHoaDon = cmdTimHoaDon.ExecuteScalar()?.ToString();

                if (string.IsNullOrEmpty(maHoaDon))
                {
                    MessageBox.Show("Không tìm thấy hóa đơn chưa thanh toán cho phòng này");
                    return;
                }

                // 2. Thêm dịch vụ vào chi tiết dịch vụ
                string maCTDV = TaoMaMoi("CT", "CHITIETDICHVU", "MaChiTietDichVu", kn.cnn, null);

                string sqlThemDV = "INSERT INTO CHITIETDICHVU (MaChiTietDichVu, MaHoaDon, MaDichVu, SoLuong) " +
                                  "VALUES (@MaChiTietDichVu, @MaHoaDon, @MaDichVu, @SoLuong)";

                SqlCommand cmdThemDV = new SqlCommand(sqlThemDV, kn.cnn);
                cmdThemDV.Parameters.AddWithValue("@MaChiTietDichVu", maCTDV);
                cmdThemDV.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                cmdThemDV.Parameters.AddWithValue("@MaDichVu", maDichVu);
                cmdThemDV.Parameters.AddWithValue("@SoLuong", soLuong);
                cmdThemDV.ExecuteNonQuery();

                // 3. Cập nhật tổng tiền hóa đơn
                int thanhTien = soLuong * giaDichVu;

                string sqlUpdateHoaDon = "UPDATE HOADON SET TongTien = TongTien + @ThanhTien WHERE MaHoaDon = @MaHoaDon";
                SqlCommand cmdUpdateHoaDon = new SqlCommand(sqlUpdateHoaDon, kn.cnn);
                cmdUpdateHoaDon.Parameters.AddWithValue("@ThanhTien", thanhTien);
                cmdUpdateHoaDon.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                cmdUpdateHoaDon.ExecuteNonQuery();

                MessageBox.Show("Thêm dịch vụ vào phòng thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dịch vụ vào phòng: " + ex.Message);
            }
            finally
            {
                kn.HuyKetNoi();
            }
        }

        private string TaoMaMoi(string prefix, string tableName, string columnName, SqlConnection connection = null, SqlTransaction transaction = null)
        {
            bool isExternalConnection = connection != null;
            SqlConnection conn = connection ?? new SqlConnection(kn.cnn.ConnectionString);
            SqlCommand cmd = new SqlCommand($"SELECT MAX({columnName}) FROM {tableName} WHERE {columnName} LIKE '{prefix}%'", conn);

            if (connection == null) conn.Open();
            if (transaction != null) cmd.Transaction = transaction;

            string lastCode = cmd.ExecuteScalar()?.ToString();

            if (string.IsNullOrEmpty(lastCode))
            {
                return prefix + "01";
            }
            else
            {
                int number = int.Parse(lastCode.Substring(prefix.Length)) + 1;
                return prefix + number.ToString("D3");
            }
        }

        private void ClearFields()
        {
            txtTenDichVu.Text = "";
            txtGiaDichVu.Text = "";
            txtMoTa.Text = "";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDichVu_Load(object sender, EventArgs e)
        {

        }
    }
}