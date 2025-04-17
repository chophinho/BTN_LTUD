using System.Windows.Forms;

namespace QL_KHACH_SAN
{
    partial class frmKhachHang
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.ComboBox cboGioiTinh;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtCCCD;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.DataGridView dgvKhachHang;
        private System.Windows.Forms.Label lblMaKH, lblHoTen, lblGioiTinh, lblNgaySinh, lblSDT, lblCCCD, lblEmail, lblDiaChi;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.cboGioiTinh = new System.Windows.Forms.ComboBox();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtCCCD = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.dgvKhachHang = new System.Windows.Forms.DataGridView();

            this.lblMaKH = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.lblSDT = new System.Windows.Forms.Label();
            this.lblCCCD = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblDiaChi = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).BeginInit();
            this.SuspendLayout();

            // Label setup
            this.lblMaKH.Text = "Mã KH:";
            this.lblHoTen.Text = "Họ tên:";
            this.lblGioiTinh.Text = "Giới tính:";
            this.lblNgaySinh.Text = "Ngày sinh:";
            this.lblSDT.Text = "SĐT:";
            this.lblCCCD.Text = "CCCD:";
            this.lblEmail.Text = "Email:";
            this.lblDiaChi.Text = "Địa chỉ:";

            // Label location
            this.lblMaKH.SetBounds(20, 20, 100, 25);
            this.lblHoTen.SetBounds(20, 60, 100, 25);
            this.lblGioiTinh.SetBounds(20, 100, 100, 25);
            this.lblNgaySinh.SetBounds(20, 140, 100, 25);
            this.lblSDT.SetBounds(400, 20, 100, 25);
            this.lblCCCD.SetBounds(400, 60, 100, 25);
            this.lblEmail.SetBounds(400, 100, 100, 25);
            this.lblDiaChi.SetBounds(400, 140, 100, 25);

            // TextBox and ComboBox
            this.txtMaKH.SetBounds(120, 20, 200, 25);
            this.txtHoTen.SetBounds(120, 60, 200, 25);
            this.cboGioiTinh.SetBounds(120, 100, 200, 25);
            this.dtpNgaySinh.SetBounds(120, 140, 200, 25);

            this.txtSDT.SetBounds(500, 20, 200, 25);
            this.txtCCCD.SetBounds(500, 60, 200, 25);
            this.txtEmail.SetBounds(500, 100, 200, 25);
            this.txtDiaChi.SetBounds(500, 140, 200, 25);

            this.cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ" });

            // Buttons
            this.btnThem.Text = "Thêm";
            this.btnThem.SetBounds(120, 190, 100, 30);
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.SetBounds(240, 190, 100, 30);
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            // DataGridView
            this.dgvKhachHang.SetBounds(20, 240, 740, 300);
            this.dgvKhachHang.ReadOnly = true;
            this.dgvKhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhachHang.CellClick += new DataGridViewCellEventHandler(this.dgvKhachHang_CellClick);

            // Form setup
            this.ClientSize = new System.Drawing.Size(800, 560);
            this.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblMaKH, txtMaKH,
                lblHoTen, txtHoTen,
                lblGioiTinh, cboGioiTinh,
                lblNgaySinh, dtpNgaySinh,
                lblSDT, txtSDT,
                lblCCCD, txtCCCD,
                lblEmail, txtEmail,
                lblDiaChi, txtDiaChi,
                btnThem, btnLamMoi,
                dgvKhachHang
            });

            this.Text = "Quản lý khách hàng";
            this.Load += new System.EventHandler(this.frmKhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
