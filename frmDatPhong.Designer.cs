namespace QL_KHACH_SAN
{
    partial class frmDatPhong
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.cboMaKhachHang = new System.Windows.Forms.ComboBox();
            this.cboMaPhong = new System.Windows.Forms.ComboBox();
            this.dtpNgayNhanPhong = new System.Windows.Forms.DateTimePicker();
            this.dtpNgayTraPhong = new System.Windows.Forms.DateTimePicker();
            this.btnDatPhong = new System.Windows.Forms.Button();
            this.lblMaKhachHang = new System.Windows.Forms.Label();
            this.lblMaPhong = new System.Windows.Forms.Label();
            this.lblNgayNhanPhong = new System.Windows.Forms.Label();
            this.lblNgayTraPhong = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cboMaKhachHang
            // 
            this.cboMaKhachHang.FormattingEnabled = true;
            this.cboMaKhachHang.Location = new System.Drawing.Point(140, 30);
            this.cboMaKhachHang.Name = "cboMaKhachHang";
            this.cboMaKhachHang.Size = new System.Drawing.Size(200, 21);
            this.cboMaKhachHang.TabIndex = 0;
            // 
            // cboMaPhong
            // 
            this.cboMaPhong.FormattingEnabled = true;
            this.cboMaPhong.Location = new System.Drawing.Point(140, 70);
            this.cboMaPhong.Name = "cboMaPhong";
            this.cboMaPhong.Size = new System.Drawing.Size(200, 21);
            this.cboMaPhong.TabIndex = 1;
            // 
            // dtpNgayNhanPhong
            // 
            this.dtpNgayNhanPhong.Location = new System.Drawing.Point(140, 110);
            this.dtpNgayNhanPhong.Name = "dtpNgayNhanPhong";
            this.dtpNgayNhanPhong.Size = new System.Drawing.Size(200, 20);
            this.dtpNgayNhanPhong.TabIndex = 2;
            // 
            // dtpNgayTraPhong
            // 
            this.dtpNgayTraPhong.Location = new System.Drawing.Point(140, 150);
            this.dtpNgayTraPhong.Name = "dtpNgayTraPhong";
            this.dtpNgayTraPhong.Size = new System.Drawing.Size(200, 20);
            this.dtpNgayTraPhong.TabIndex = 3;
            // 
            // btnDatPhong
            // 
            this.btnDatPhong.Location = new System.Drawing.Point(140, 190);
            this.btnDatPhong.Name = "btnDatPhong";
            this.btnDatPhong.Size = new System.Drawing.Size(100, 30);
            this.btnDatPhong.TabIndex = 4;
            this.btnDatPhong.Text = "Đặt Phòng";
            this.btnDatPhong.UseVisualStyleBackColor = true;
            this.btnDatPhong.Click += new System.EventHandler(this.btnDatPhong_Click);
            // 
            // lblMaKhachHang
            // 
            this.lblMaKhachHang.AutoSize = true;
            this.lblMaKhachHang.Location = new System.Drawing.Point(30, 33);
            this.lblMaKhachHang.Name = "lblMaKhachHang";
            this.lblMaKhachHang.Size = new System.Drawing.Size(87, 13);
            this.lblMaKhachHang.TabIndex = 5;
            this.lblMaKhachHang.Text = "Mã Khách Hàng:";
            // 
            // lblMaPhong
            // 
            this.lblMaPhong.AutoSize = true;
            this.lblMaPhong.Location = new System.Drawing.Point(30, 73);
            this.lblMaPhong.Name = "lblMaPhong";
            this.lblMaPhong.Size = new System.Drawing.Size(56, 13);
            this.lblMaPhong.TabIndex = 6;
            this.lblMaPhong.Text = "Mã Phòng:";
            // 
            // lblNgayNhanPhong
            // 
            this.lblNgayNhanPhong.AutoSize = true;
            this.lblNgayNhanPhong.Location = new System.Drawing.Point(30, 113);
            this.lblNgayNhanPhong.Name = "lblNgayNhanPhong";
            this.lblNgayNhanPhong.Size = new System.Drawing.Size(104, 13);
            this.lblNgayNhanPhong.TabIndex = 7;
            this.lblNgayNhanPhong.Text = "Ngày Nhận Phòng:";
            // 
            // lblNgayTraPhong
            // 
            this.lblNgayTraPhong.AutoSize = true;
            this.lblNgayTraPhong.Location = new System.Drawing.Point(30, 153);
            this.lblNgayTraPhong.Name = "lblNgayTraPhong";
            this.lblNgayTraPhong.Size = new System.Drawing.Size(97, 13);
            this.lblNgayTraPhong.TabIndex = 8;
            this.lblNgayTraPhong.Text = "Ngày Trả Phòng:";
            // 
            // frmDatPhong
            // 
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.lblNgayTraPhong);
            this.Controls.Add(this.lblNgayNhanPhong);
            this.Controls.Add(this.lblMaPhong);
            this.Controls.Add(this.lblMaKhachHang);
            this.Controls.Add(this.btnDatPhong);
            this.Controls.Add(this.dtpNgayTraPhong);
            this.Controls.Add(this.dtpNgayNhanPhong);
            this.Controls.Add(this.cboMaPhong);
            this.Controls.Add(this.cboMaKhachHang);
            this.Name = "frmDatPhong";
            this.Text = "Đặt Phòng";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox cboMaKhachHang;
        private System.Windows.Forms.ComboBox cboMaPhong;
        private System.Windows.Forms.DateTimePicker dtpNgayNhanPhong;
        private System.Windows.Forms.DateTimePicker dtpNgayTraPhong;
        private System.Windows.Forms.Button btnDatPhong;
        private System.Windows.Forms.Label lblMaKhachHang;
        private System.Windows.Forms.Label lblMaPhong;
        private System.Windows.Forms.Label lblNgayNhanPhong;
        private System.Windows.Forms.Label lblNgayTraPhong;
    }
}
