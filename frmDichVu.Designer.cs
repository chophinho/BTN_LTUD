namespace QL_KHACH_SAN
{
    partial class frmDichVu
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTenDichVu = new System.Windows.Forms.TextBox();
            this.txtGiaDichVu = new System.Windows.Forms.TextBox();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.btnThemDichVu = new System.Windows.Forms.Button();
            this.dgvDichVu = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.cboPhong = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.btnThemVaoPhong = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            this.SuspendLayout();

            // label1
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "THÊM DỊCH VỤ MỚI";

            // label2
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên dịch vụ:";

            // label3
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Giá tiền:";

            // label4
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mô tả:";

            // label5
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "DANH SÁCH DỊCH VỤ";

            // txtTenDichVu
            this.txtTenDichVu.Location = new System.Drawing.Point(100, 57);
            this.txtTenDichVu.Name = "txtTenDichVu";
            this.txtTenDichVu.Size = new System.Drawing.Size(200, 20);
            this.txtTenDichVu.TabIndex = 5;

            // txtGiaDichVu
            this.txtGiaDichVu.Location = new System.Drawing.Point(100, 97);
            this.txtGiaDichVu.Name = "txtGiaDichVu";
            this.txtGiaDichVu.Size = new System.Drawing.Size(100, 20);
            this.txtGiaDichVu.TabIndex = 6;

            // txtMoTa
            this.txtMoTa.Location = new System.Drawing.Point(100, 137);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(300, 50);
            this.txtMoTa.TabIndex = 7;

            // btnThemDichVu
            this.btnThemDichVu.Location = new System.Drawing.Point(420, 137);
            this.btnThemDichVu.Name = "btnThemDichVu";
            this.btnThemDichVu.Size = new System.Drawing.Size(100, 50);
            this.btnThemDichVu.TabIndex = 8;
            this.btnThemDichVu.Text = "Thêm dịch vụ mới";
            this.btnThemDichVu.UseVisualStyleBackColor = true;
            this.btnThemDichVu.Click += new System.EventHandler(this.btnThemDichVu_Click);

            // dgvDichVu
            this.dgvDichVu.AllowUserToAddRows = false;
            this.dgvDichVu.AllowUserToDeleteRows = false;
            this.dgvDichVu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDichVu.Location = new System.Drawing.Point(20, 220);
            this.dgvDichVu.Name = "dgvDichVu";
            this.dgvDichVu.ReadOnly = true;
            this.dgvDichVu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDichVu.Size = new System.Drawing.Size(500, 150);
            this.dgvDichVu.TabIndex = 9;

            // label6
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 390);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(220, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "THÊM DỊCH VỤ VÀO PHÒNG";

            // cboPhong
            this.cboPhong.FormattingEnabled = true;
            this.cboPhong.Location = new System.Drawing.Point(100, 420);
            this.cboPhong.Name = "cboPhong";
            this.cboPhong.Size = new System.Drawing.Size(150, 21);
            this.cboPhong.TabIndex = 11;

            // label7
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 423);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Phòng:";

            // nudSoLuong
            this.nudSoLuong.Location = new System.Drawing.Point(300, 420);
            this.nudSoLuong.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(60, 20);
            this.nudSoLuong.TabIndex = 13;
            this.nudSoLuong.Value = new decimal(new int[] { 1, 0, 0, 0 });

            // btnThemVaoPhong
            this.btnThemVaoPhong.Location = new System.Drawing.Point(380, 420);
            this.btnThemVaoPhong.Name = "btnThemVaoPhong";
            this.btnThemVaoPhong.Size = new System.Drawing.Size(100, 23);
            this.btnThemVaoPhong.TabIndex = 14;
            this.btnThemVaoPhong.Text = "Thêm vào phòng";
            this.btnThemVaoPhong.UseVisualStyleBackColor = true;
            this.btnThemVaoPhong.Click += new System.EventHandler(this.btnThemVaoPhong_Click);

            // btnThoat
            this.btnThoat.Location = new System.Drawing.Point(420, 460);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(100, 30);
            this.btnThoat.TabIndex = 15;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            // frmDichVu
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 500);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnThemVaoPhong);
            this.Controls.Add(this.nudSoLuong);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboPhong);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvDichVu);
            this.Controls.Add(this.btnThemDichVu);
            this.Controls.Add(this.txtMoTa);
            this.Controls.Add(this.txtGiaDichVu);
            this.Controls.Add(this.txtTenDichVu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmDichVu";
            this.Text = "Quản Lý Dịch Vụ";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTenDichVu;
        private System.Windows.Forms.TextBox txtGiaDichVu;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Button btnThemDichVu;
        private System.Windows.Forms.DataGridView dgvDichVu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboPhong;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudSoLuong;
        private System.Windows.Forms.Button btnThemVaoPhong;
        private System.Windows.Forms.Button btnThoat;
    }
}