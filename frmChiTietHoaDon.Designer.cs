using System.Windows.Forms;
using System;

namespace QL_KHACH_SAN
{
    partial class frmChiTietHoaDon
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvChiTietHoaDon;
        private Button btnThoat;

        // Code generated for UI
        private void InitializeComponent()
        {
            this.dgvChiTietHoaDon = new DataGridView();
            this.btnThoat = new Button();

            // DataGridView
            this.dgvChiTietHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietHoaDon.Location = new System.Drawing.Point(20, 20);
            this.dgvChiTietHoaDon.Name = "dgvChiTietHoaDon";
            this.dgvChiTietHoaDon.Size = new System.Drawing.Size(600, 200);
            this.dgvChiTietHoaDon.TabIndex = 0;

            // Button Thoát
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Location = new System.Drawing.Point(650, 20);
            this.btnThoat.Click += new EventHandler(this.btnThoat_Click);

            // Form Settings
            this.ClientSize = new System.Drawing.Size(800, 300);
            this.Controls.Add(this.dgvChiTietHoaDon);
            this.Controls.Add(this.btnThoat);
            this.Name = "frmChiTietHoaDon";
            this.Text = "Chi Tiết Hóa Đơn";
            this.Load += new EventHandler(this.frmChiTietHoaDon_Load);
        }
    }
}
