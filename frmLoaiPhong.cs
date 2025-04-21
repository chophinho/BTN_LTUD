using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QL_KHACH_SAN
{
    public partial class frmLoaiPhong : Form
    {
        KetNoi kn = new KetNoi();

        public frmLoaiPhong()
        {
            InitializeComponent();
        }

        private void frmLoaiPhong_Load(object sender, EventArgs e)
        {
            LoadLoaiPhong();
        }

        private void LoadLoaiPhong()
        {
            dgvLoaiPhong.DataSource = kn.LayDuLieu("SELECT * FROM LOAIPHONG");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO LOAIPHONG VALUES (@MaLoaiPhong, @TenLoaiPhong, @GiaPhong, @MoTa)";
            SqlParameter[] parameters = {
                new SqlParameter("@MaLoaiPhong", txtMaLoai.Text),
                new SqlParameter("@TenLoaiPhong", txtTenLoai.Text),
                new SqlParameter("@GiaPhong", int.Parse(txtGia.Text)),
                new SqlParameter("@MoTa", txtMoTa.Text)
            };

            try
            {
                kn.ThucThi(query, parameters);
                MessageBox.Show("Thêm thành công!");
                LoadLoaiPhong();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string query = "UPDATE LOAIPHONG SET TenLoaiPhong=@TenLoaiPhong, GiaPhong=@GiaPhong, MoTa=@MoTa WHERE MaLoaiPhong=@MaLoaiPhong";
            SqlParameter[] parameters = {
                new SqlParameter("@MaLoaiPhong", txtMaLoai.Text),
                new SqlParameter("@TenLoaiPhong", txtTenLoai.Text),
                new SqlParameter("@GiaPhong", int.Parse(txtGia.Text)),
                new SqlParameter("@MoTa", txtMoTa.Text)
            };

            try
            {
                kn.ThucThi(query, parameters);
                MessageBox.Show("Sửa thành công!");
                LoadLoaiPhong();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM LOAIPHONG WHERE MaLoaiPhong = @MaLoaiPhong";
            SqlParameter[] parameters = {
                new SqlParameter("@MaLoaiPhong", txtMaLoai.Text)
            };

            try
            {
                kn.ThucThi(query, parameters);
                MessageBox.Show("Xóa thành công!");
                LoadLoaiPhong();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtMaLoai.Text = "";
            txtTenLoai.Text = "";
            txtGia.Text = "";
            txtMoTa.Text = "";
        }

        private void dgvLoaiPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLoaiPhong.Rows[e.RowIndex];
                txtMaLoai.Text = row.Cells[0].Value.ToString();
                txtTenLoai.Text = row.Cells[1].Value.ToString();
                txtGia.Text = row.Cells[2].Value.ToString();
                txtMoTa.Text = row.Cells[3].Value.ToString();
            }
        }
    }
}
