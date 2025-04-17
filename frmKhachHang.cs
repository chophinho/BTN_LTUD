using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QL_KHACH_SAN
{
    public partial class frmKhachHang : Form
    {
        KetNoi kn = new KetNoi();

        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            LoadDanhSachKhachHang();
        }

        private void LoadDanhSachKhachHang()
        {
            string sql = "SELECT * FROM KHACHHANG";
            dgvKhachHang.DataSource = kn.LayDuLieu(sql);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string sql = "sp_ThemKhachHang";
            SqlParameter[] prms = new SqlParameter[]
            {
                new SqlParameter("@MaKhachHang", txtMaKH.Text),
                new SqlParameter("@HoTen", txtHoTen.Text),
                new SqlParameter("@GioiTinh", cboGioiTinh.Text),
                new SqlParameter("@NgaySinh", dtpNgaySinh.Value),
                new SqlParameter("@SoDienThoai", txtSDT.Text),
                new SqlParameter("@CCCD", txtCCCD.Text),
                new SqlParameter("@Email", txtEmail.Text),
                new SqlParameter("@DiaChi", txtDiaChi.Text)
            };

            try
            {
                kn.ThucThi(sql, prms);
                MessageBox.Show("Thêm khách hàng thành công!");
                LoadDanhSachKhachHang();
                LamMoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void LamMoi()
        {
            txtMaKH.Clear();
            txtHoTen.Clear();
            cboGioiTinh.SelectedIndex = -1;
            txtSDT.Clear();
            txtCCCD.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            dtpNgaySinh.Value = DateTime.Today;
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];
                txtMaKH.Text = row.Cells["MaKhachHang"].Value.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                cboGioiTinh.Text = row.Cells["GioiTinh"].Value.ToString();
                dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
                txtSDT.Text = row.Cells["SoDienThoai"].Value.ToString();
                txtCCCD.Text = row.Cells["CCCD"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
            }
        }
    }
}