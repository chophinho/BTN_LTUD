using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QL_KHACH_SAN
{
    public partial class frmPhong : Form
    {
        private KetNoi ketNoi = new KetNoi();

        public frmPhong()
        {
            InitializeComponent();
        }

        private void frmPhong_Load(object sender, EventArgs e)
        {
            LoadLoaiPhong(); // Tải dữ liệu loại phòng vào ComboBox
            LoadPhong();     // Tải danh sách phòng khi form được tải

            // Cấu hình ComboBox trạng thái
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("Trống");
            cboTrangThai.Items.Add("Đang thuê");
            cboTrangThai.Items.Add("Đã đặt");
            cboTrangThai.SelectedIndex = 0;
        }

        private void LoadPhong()
        {
            try
            {
                string sql = "SELECT PHONG.MaPhong, SoPhong, LOAIPHONG.MaLoaiPhong, TenLoaiPhong, TrangThai " +
                             "FROM PHONG JOIN LOAIPHONG ON PHONG.MaLoaiPhong = LOAIPHONG.MaLoaiPhong";

                DataTable dt = ketNoi.LayDuLieu(sql);
                dgvPhong.DataSource = dt;

                // Đổi tiêu đề cột
                dgvPhong.Columns["MaPhong"].HeaderText = "Mã Phòng";
                dgvPhong.Columns["SoPhong"].HeaderText = "Số Phòng";
                dgvPhong.Columns["MaLoaiPhong"].HeaderText = "Mã Loại";
                dgvPhong.Columns["TenLoaiPhong"].HeaderText = "Tên Loại Phòng";
                dgvPhong.Columns["TrangThai"].HeaderText = "Trạng Thái";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load phòng: " + ex.Message);
            }
        }

        private void LoadLoaiPhong()
        {
            try
            {
                string sql = "SELECT MaLoaiPhong, TenLoaiPhong FROM LOAIPHONG";
                DataTable dtLoaiPhong = ketNoi.LayDuLieu(sql);

                cboLoaiPhong.DataSource = dtLoaiPhong;
                cboLoaiPhong.DisplayMember = "TenLoaiPhong";
                cboLoaiPhong.ValueMember = "MaLoaiPhong";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load loại phòng: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string maPhong = txtMaPhong.Text.Trim();
                string soPhong = txtSoPhong.Text.Trim();
                string maLoaiPhong = cboLoaiPhong.SelectedValue.ToString();
                string trangThai = cboTrangThai.SelectedItem.ToString();

                string sql = "INSERT INTO PHONG (MaPhong, SoPhong, MaLoaiPhong, TrangThai) " +
                             "VALUES (@MaPhong, @SoPhong, @MaLoaiPhong, @TrangThai)";

                SqlParameter[] parameters = {
                    new SqlParameter("@MaPhong", maPhong),
                    new SqlParameter("@SoPhong", soPhong),
                    new SqlParameter("@MaLoaiPhong", maLoaiPhong),
                    new SqlParameter("@TrangThai", trangThai)
                };

                ketNoi.ThucThi(sql, parameters);
                LoadPhong();
                MessageBox.Show("Thêm phòng thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm phòng: " + ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string maPhong = txtMaPhong.Text.Trim();
                string soPhong = txtSoPhong.Text.Trim();
                string maLoaiPhong = cboLoaiPhong.SelectedValue.ToString();
                string trangThai = cboTrangThai.SelectedItem.ToString();

                string sql = "UPDATE PHONG SET SoPhong = @SoPhong, MaLoaiPhong = @MaLoaiPhong, TrangThai = @TrangThai WHERE MaPhong = @MaPhong";

                SqlParameter[] parameters = {
                    new SqlParameter("@MaPhong", maPhong),
                    new SqlParameter("@SoPhong", soPhong),
                    new SqlParameter("@MaLoaiPhong", maLoaiPhong),
                    new SqlParameter("@TrangThai", trangThai)
                };

                ketNoi.ThucThi(sql, parameters);
                LoadPhong();
                MessageBox.Show("Cập nhật thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string maPhong = txtMaPhong.Text.Trim();

                string sql = "DELETE FROM PHONG WHERE MaPhong = @MaPhong";

                SqlParameter[] parameters = {
                    new SqlParameter("@MaPhong", maPhong)
                };

                ketNoi.ThucThi(sql, parameters);
                LoadPhong();
                MessageBox.Show("Xóa thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message);
            }
        }

        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            try
            {
                string maPhong = txtMaPhong.Text.Trim();
                string trangThai = cboTrangThai.SelectedItem.ToString();

                string sql = "UPDATE PHONG SET TrangThai = @TrangThai WHERE MaPhong = @MaPhong";

                SqlParameter[] parameters = {
                    new SqlParameter("@MaPhong", maPhong),
                    new SqlParameter("@TrangThai", trangThai)
                };

                ketNoi.ThucThi(sql, parameters);
                LoadPhong();
                MessageBox.Show("Cập nhật trạng thái thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật trạng thái: " + ex.Message);
            }
        }

        private void dgvPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPhong.Rows[e.RowIndex];
                txtMaPhong.Text = row.Cells["MaPhong"].Value.ToString();
                txtSoPhong.Text = row.Cells["SoPhong"].Value.ToString();
                cboLoaiPhong.SelectedValue = row.Cells["MaLoaiPhong"].Value.ToString();
                cboTrangThai.SelectedItem = row.Cells["TrangThai"].Value.ToString();
            }
        }
    }
}
