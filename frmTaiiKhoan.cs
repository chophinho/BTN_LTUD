using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QL_KHACH_SAN
{
    public partial class frmTaiKhoan : Form
    {
        KetNoi ketNoi = new KetNoi();

        public frmTaiKhoan()
        {
            InitializeComponent();
            LoadNhanVien(); // Load danh sách nhân viên vào ComboBox
            LoadTaiKhoan(); // Load danh sách tài khoản vào DataGridView
        }

        // Load danh sách nhân viên
        private void LoadNhanVien()
        {
            string query = "SELECT MaNhanVien, HoTen FROM NHANVIEN";
            DataTable data = ketNoi.LayDuLieu(query);
            cbMaNhanVien.DataSource = data;
            cbMaNhanVien.DisplayMember = "HoTen";
            cbMaNhanVien.ValueMember = "MaNhanVien";
        }

        // Load danh sách tài khoản
        private void LoadTaiKhoan()
        {
            string query = "SELECT * FROM TAIKHOAN";
            dgvTaiKhoan.DataSource = ketNoi.LayDuLieu(query);
        }

        // Thêm tài khoản
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "INSERT INTO TAIKHOAN VALUES (@MaTaiKhoan, @TenDangNhap, @MatKhau, @MaNhanVien, @VaiTro)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaTaiKhoan", txtMaTaiKhoan.Text),
                    new SqlParameter("@TenDangNhap", txtTenDangNhap.Text),
                    new SqlParameter("@MatKhau", txtMatKhau.Text),
                    new SqlParameter("@MaNhanVien", cbMaNhanVien.SelectedValue),
                    new SqlParameter("@VaiTro", cbVaiTro.Text)
                };
                ketNoi.ThucThi(query, parameters);
                MessageBox.Show("Thêm tài khoản thành công!", "Thông báo");
                LoadTaiKhoan();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
            }
        }

        // Sửa tài khoản
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "UPDATE TAIKHOAN SET TenDangNhap = @TenDangNhap, MatKhau = @MatKhau, " +
                               "MaNhanVien = @MaNhanVien, VaiTro = @VaiTro WHERE MaTaiKhoan = @MaTaiKhoan";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaTaiKhoan", txtMaTaiKhoan.Text),
                    new SqlParameter("@TenDangNhap", txtTenDangNhap.Text),
                    new SqlParameter("@MatKhau", txtMatKhau.Text),
                    new SqlParameter("@MaNhanVien", cbMaNhanVien.SelectedValue),
                    new SqlParameter("@VaiTro", cbVaiTro.Text)
                };
                ketNoi.ThucThi(query, parameters);
                MessageBox.Show("Sửa tài khoản thành công!", "Thông báo");
                LoadTaiKhoan();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
            }
        }

        // Xóa tài khoản
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "DELETE FROM TAIKHOAN WHERE MaTaiKhoan = @MaTaiKhoan";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaTaiKhoan", txtMaTaiKhoan.Text)
                };
                ketNoi.ThucThi(query, parameters);
                MessageBox.Show("Xóa tài khoản thành công!", "Thông báo");
                LoadTaiKhoan();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
            }
        }

        // Làm mới form
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        // Xóa dữ liệu form
        private void ClearForm()
        {
            txtMaTaiKhoan.Clear();
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            cbMaNhanVien.SelectedIndex = 0;
            cbVaiTro.SelectedIndex = 0;
        }

        // Khi chọn tài khoản trên DataGridView
        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTaiKhoan.Rows[e.RowIndex];
                txtMaTaiKhoan.Text = row.Cells["MaTaiKhoan"].Value.ToString();
                txtTenDangNhap.Text = row.Cells["TenDangNhap"].Value.ToString();
                txtMatKhau.Text = row.Cells["MatKhau"].Value.ToString();
                cbMaNhanVien.SelectedValue = row.Cells["MaNhanVien"].Value.ToString();
                cbVaiTro.Text = row.Cells["VaiTro"].Value.ToString();
            }
        }
    }
}
