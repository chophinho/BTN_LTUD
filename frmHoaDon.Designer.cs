namespace QL_KHACH_SAN
{
    partial class frmHoaDon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">True if managed resources should be disposed; otherwise, false.</param>
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
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.lblTinhTrangThanhToan = new System.Windows.Forms.Label();
            this.cbTinhTrangThanhToan = new System.Windows.Forms.ComboBox();
            this.btnLoadHoaDon = new System.Windows.Forms.Button();
            this.lblHoaDon = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Location = new System.Drawing.Point(12, 50);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.Size = new System.Drawing.Size(500, 150);
            this.dgvHoaDon.TabIndex = 0;
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Location = new System.Drawing.Point(12, 220);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(150, 30);
            this.btnThanhToan.TabIndex = 1;
            this.btnThanhToan.Text = "Thanh Toán";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // lblTinhTrangThanhToan
            // 
            this.lblTinhTrangThanhToan.AutoSize = true;
            this.lblTinhTrangThanhToan.Location = new System.Drawing.Point(190, 220);
            this.lblTinhTrangThanhToan.Name = "lblTinhTrangThanhToan";
            this.lblTinhTrangThanhToan.Size = new System.Drawing.Size(126, 13);
            this.lblTinhTrangThanhToan.TabIndex = 2;
            this.lblTinhTrangThanhToan.Text = "Chọn Tình Trạng Thanh Toán";
            // 
            // cbTinhTrangThanhToan
            // 
            this.cbTinhTrangThanhToan.FormattingEnabled = true;
            this.cbTinhTrangThanhToan.Items.AddRange(new object[] {
            "Đã thanh toán",
            "Chưa thanh toán"});
            this.cbTinhTrangThanhToan.Location = new System.Drawing.Point(190, 240);
            this.cbTinhTrangThanhToan.Name = "cbTinhTrangThanhToan";
            this.cbTinhTrangThanhToan.Size = new System.Drawing.Size(150, 21);
            this.cbTinhTrangThanhToan.TabIndex = 3;
            // 
            // btnLoadHoaDon
            // 
            this.btnLoadHoaDon.Location = new System.Drawing.Point(380, 220);
            this.btnLoadHoaDon.Name = "btnLoadHoaDon";
            this.btnLoadHoaDon.Size = new System.Drawing.Size(130, 30);
            this.btnLoadHoaDon.TabIndex = 4;
            this.btnLoadHoaDon.Text = "Tải Hóa Đơn";
            this.btnLoadHoaDon.UseVisualStyleBackColor = true;
            this.btnLoadHoaDon.Click += new System.EventHandler(this.btnLoadHoaDon_Click);
            // 
            // lblHoaDon
            // 
            this.lblHoaDon.AutoSize = true;
            this.lblHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoaDon.Location = new System.Drawing.Point(12, 20);
            this.lblHoaDon.Name = "lblHoaDon";
            this.lblHoaDon.Size = new System.Drawing.Size(83, 20);
            this.lblHoaDon.TabIndex = 5;
            this.lblHoaDon.Text = "Hóa Đơn";
            // 
            // FrmHoaDon
            // 
            this.ClientSize = new System.Drawing.Size(530, 280);
            this.Controls.Add(this.lblHoaDon);
            this.Controls.Add(this.btnLoadHoaDon);
            this.Controls.Add(this.cbTinhTrangThanhToan);
            this.Controls.Add(this.lblTinhTrangThanhToan);
            this.Controls.Add(this.btnThanhToan);
            this.Controls.Add(this.dgvHoaDon);
            this.Name = "FrmHoaDon";
            this.Text = "Quản Lý Hóa Đơn";
            this.Load += new System.EventHandler(this.FrmHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Label lblTinhTrangThanhToan;
        private System.Windows.Forms.ComboBox cbTinhTrangThanhToan;
        private System.Windows.Forms.Button btnLoadHoaDon;
        private System.Windows.Forms.Label lblHoaDon;
    }
}
