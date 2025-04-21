using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QL_KHACH_SAN
{
    public partial class frmNhanVien : Form
    {
        KetNoi ketNoi = new KetNoi(); // Lớp kết nối cơ sở dữ liệu

        public frmNhanVien()
        {
            InitializeComponent();
            LoadChucVu(); // Load danh sách chức vụ vào ComboBox
            LoadNhanVien(); // Load danh sách nhân viên vào DataGridView
        }

        // Load danh sách chức vụ
        private void LoadChucVu()
        {
            string query = "SELECT MaChucVu, TenChucVu FROM CHUCVU";
            DataTable data = ketNoi.LayDuLieu(query);
            cbMaChucVu.DataSource = data;
            cbMaChucVu.DisplayMember = "TenChucVu";
            cbMaChucVu.ValueMember = "MaChucVu";
        }

        // Load danh sách nhân viên
        private void LoadNhanVien()
        {
            string query = "SELECT * FROM NHANVIEN";
            dgvNhanVien.DataSource = ketNoi.LayDuLieu(query);
        }

        // Thêm nhân viên
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "INSERT INTO NHANVIEN VALUES (@MaNhanVien, @MaChucVu, @HoTen, @GioiTinh, @NgaySinh, @SoDienThoai, @DiaChi)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaNhanVien", txtMaNhanVien.Text),
                    new SqlParameter("@MaChucVu", cbMaChucVu.SelectedValue),
                    new SqlParameter("@HoTen", txtHoTen.Text),
                    new SqlParameter("@GioiTinh", rbNam.Checked ? "Nam" : "Nữ"),
                    new SqlParameter("@NgaySinh", dtNgaySinh.Value),
                    new SqlParameter("@SoDienThoai", txtSoDienThoai.Text),
                    new SqlParameter("@DiaChi", txtDiaChi.Text)
                };
                ketNoi.ThucThi(query, parameters);
                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo");
                LoadNhanVien();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
            }
        }

        // Sửa nhân viên
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "UPDATE NHANVIEN SET MaChucVu = @MaChucVu, HoTen = @HoTen, GioiTinh = @GioiTinh, " +
                               "NgaySinh = @NgaySinh, SoDienThoai = @SoDienThoai, DiaChi = @DiaChi WHERE MaNhanVien = @MaNhanVien";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaNhanVien", txtMaNhanVien.Text),
                    new SqlParameter("@MaChucVu", cbMaChucVu.SelectedValue),
                    new SqlParameter("@HoTen", txtHoTen.Text),
                    new SqlParameter("@GioiTinh", rbNam.Checked ? "Nam" : "Nữ"),
                    new SqlParameter("@NgaySinh", dtNgaySinh.Value),
                    new SqlParameter("@SoDienThoai", txtSoDienThoai.Text),
                    new SqlParameter("@DiaChi", txtDiaChi.Text)
                };
                ketNoi.ThucThi(query, parameters);
                MessageBox.Show("Sửa thông tin nhân viên thành công!", "Thông báo");
                LoadNhanVien();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
            }
        }

        // Xóa nhân viên
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "DELETE FROM NHANVIEN WHERE MaNhanVien = @MaNhanVien";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaNhanVien", txtMaNhanVien.Text)
                };
                ketNoi.ThucThi(query, parameters);
                MessageBox.Show("Xóa nhân viên thành công!", "Thông báo");
                LoadNhanVien();
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
            txtMaNhanVien.Clear();
            txtHoTen.Clear();
            txtSoDienThoai.Clear();
            txtDiaChi.Clear();
            rbNam.Checked = true;
            dtNgaySinh.Value = DateTime.Now;
            cbMaChucVu.SelectedIndex = 0;
        }

        // Khi chọn nhân viên trên DataGridView
        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
                txtMaNhanVien.Text = row.Cells["MaNhanVien"].Value.ToString();
                cbMaChucVu.SelectedValue = row.Cells["MaChucVu"].Value.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                rbNam.Checked = row.Cells["GioiTinh"].Value.ToString() == "Nam";
                rbNu.Checked = row.Cells["GioiTinh"].Value.ToString() == "Nữ";
                dtNgaySinh.Value = DateTime.Parse(row.Cells["NgaySinh"].Value.ToString());
                txtSoDienThoai.Text = row.Cells["SoDienThoai"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
            }
        }
    }
}
