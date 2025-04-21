using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QL_KHACH_SAN
{
    public partial class frmHoaDon : Form
    {
        KetNoi kn = new KetNoi();

        public frmHoaDon()
        {
            InitializeComponent();
        }

        private void FrmHoaDon_Load(object sender, EventArgs e)
        {
            // Tải hóa đơn khi form được load
            LoadHoaDon();
        }

        // Hàm tải danh sách hóa đơn vào DataGridView
        private void LoadHoaDon()
        {
            string sql = "SELECT * FROM HOADON";
            DataTable dt = kn.LayDuLieu(sql);
            dgvHoaDon.DataSource = dt;
        }

        // Xử lý sự kiện nhấn nút "Tải Hóa Đơn"
        private void btnLoadHoaDon_Click(object sender, EventArgs e)
        {
            LoadHoaDon();
        }

        // Xử lý sự kiện nhấn nút "Thanh Toán"
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count > 0)
            {
                string maHoaDon = dgvHoaDon.SelectedRows[0].Cells["MaHoaDon"].Value.ToString();
                string tinhTrangThanhToan = cbTinhTrangThanhToan.SelectedItem.ToString();

                // Cập nhật tình trạng thanh toán của hóa đơn
                string sql = "UPDATE HOADON SET TinhTrangThanhToan = @TinhTrangThanhToan WHERE MaHoaDon = @MaHoaDon";
                SqlParameter[] prms = new SqlParameter[]
                {
                    new SqlParameter("@TinhTrangThanhToan", tinhTrangThanhToan),
                    new SqlParameter("@MaHoaDon", maHoaDon)
                };
                kn.ThucThi(sql, prms);

                MessageBox.Show("Cập nhật tình trạng thanh toán thành công!");
                LoadHoaDon();  // Tải lại hóa đơn
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn!");
            }
        }
    }
}
