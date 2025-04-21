namespace QL_KHACH_SAN
{
    partial class frmLoaiPhong
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMaLoai;
        private System.Windows.Forms.Label lblTenLoai;
        private System.Windows.Forms.Label lblGia;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.TextBox txtMaLoai;
        private System.Windows.Forms.TextBox txtTenLoai;
        private System.Windows.Forms.TextBox txtGia;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.DataGridView dgvLoaiPhong;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblMaLoai = new System.Windows.Forms.Label();
            this.lblTenLoai = new System.Windows.Forms.Label();
            this.lblGia = new System.Windows.Forms.Label();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.txtMaLoai = new System.Windows.Forms.TextBox();
            this.txtTenLoai = new System.Windows.Forms.TextBox();
            this.txtGia = new System.Windows.Forms.TextBox();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.dgvLoaiPhong = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiPhong)).BeginInit();
            this.SuspendLayout();

            // 
            // Labels & TextBoxes
            // 
            this.lblMaLoai.Text = "Mã loại phòng:";
            this.lblMaLoai.Location = new System.Drawing.Point(20, 20);
            this.txtMaLoai.Location = new System.Drawing.Point(120, 20);

            this.lblTenLoai.Text = "Tên loại:";
            this.lblTenLoai.Location = new System.Drawing.Point(20, 60);
            this.txtTenLoai.Location = new System.Drawing.Point(120, 60);

            this.lblGia.Text = "Giá phòng:";
            this.lblGia.Location = new System.Drawing.Point(20, 100);
            this.txtGia.Location = new System.Drawing.Point(120, 100);

            this.lblMoTa.Text = "Mô tả:";
            this.lblMoTa.Location = new System.Drawing.Point(20, 140);
            this.txtMoTa.Location = new System.Drawing.Point(120, 140);
            this.txtMoTa.Width = 200;

            // 
            // Buttons
            // 
            this.btnThem.Text = "Thêm";
            this.btnThem.Location = new System.Drawing.Point(350, 20);
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            this.btnSua.Text = "Sửa";
            this.btnSua.Location = new System.Drawing.Point(350, 60);
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            this.btnXoa.Text = "Xóa";
            this.btnXoa.Location = new System.Drawing.Point(350, 100);
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Location = new System.Drawing.Point(350, 140);
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            // 
            // DataGridView
            // 
            this.dgvLoaiPhong.Location = new System.Drawing.Point(20, 200);
            this.dgvLoaiPhong.Size = new System.Drawing.Size(500, 200);
            this.dgvLoaiPhong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLoaiPhong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLoaiPhong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLoaiPhong_CellClick);

            // 
            // frmLoaiPhong
            // 
            this.ClientSize = new System.Drawing.Size(550, 420);
            this.Controls.Add(this.lblMaLoai);
            this.Controls.Add(this.txtMaLoai);
            this.Controls.Add(this.lblTenLoai);
            this.Controls.Add(this.txtTenLoai);
            this.Controls.Add(this.lblGia);
            this.Controls.Add(this.txtGia);
            this.Controls.Add(this.lblMoTa);
            this.Controls.Add(this.txtMoTa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.dgvLoaiPhong);
            this.Text = "Quản lý loại phòng";
            this.Load += new System.EventHandler(this.frmLoaiPhong_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiPhong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
