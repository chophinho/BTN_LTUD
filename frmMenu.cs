﻿using QL_KHACH_SAN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_KHACH_SAN
{
    public partial class frmMenu : Form
    {

        public string TenDangNhap;
        public string Quyen;
        private int childFormNumber = 0;
        private System.Windows.Forms.ComboBox cboMaPhong;
        private System.Windows.Forms.Label lblMaPhong;

        public frmMenu()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }





        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            TaiKhoan.Text = TenDangNhap;
            frmHoaDon frmHoaDon = new frmHoaDon();
            frmHoaDon.MdiParent = this;
            frmHoaDon.Show();
        }



        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHoaDon frmHoaDon = new frmHoaDon();
            frmHoaDon.MdiParent = this;
            frmHoaDon.Show();

        }

        private void chiTiếtHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChiTietHoaDon frmChiTietHoaDon = new frmChiTietHoaDon();
            frmChiTietHoaDon.Show();

        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKhachHang frmKhachHang = new frmKhachHang();
            frmKhachHang.Show();

        }

        private void phòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Quyen == "admin")
            {
                frmPhong frmPhong = new frmPhong();
                frmPhong.Show();
            }
            else
            {
                MessageBox.Show("Bạn k có quyền truy cập này");

            }

        }

        private void loạiPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Quyen == "admin")
            {
                frmLoaiPhong frmLoai = new frmLoaiPhong();
                frmLoai.Show();

            }
            else
            {
                MessageBox.Show("Bạn k có quyền truy cập này");

            }

        }

        private void dịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Quyen == "admin")
            {
                frmDichVu frmDichVu = new frmDichVu();
                frmDichVu.Show();
            }
            else
            {
                MessageBox.Show("Bạn k có quyền truy cập này");

            }

        }


        private void chiTiếtDịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChiTietDichVu frmChiTietDichVu = new frmChiTietDichVu();
            frmChiTietDichVu.Show();

        }
        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmThongKeDoanhThu frm = new frmThongKeDoanhThu();
            //frm.Show();
        }
        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Quyen == "admin")
            {
                frmNhanVien frmNhanVien = new frmNhanVien();
                frmNhanVien.Show();
            }
            else
            {
                MessageBox.Show("Bạn k có quyền truy cập này");

            }

        }

        private void chứcVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Quyen == "admin")
            {
                frmChucVu frmChucVu = new frmChucVu();
                frmChucVu.Show();
            }
            else
            {
                MessageBox.Show("Bạn k có quyền truy cập này");

            }
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Quyen == "admin")
            {
                frmTaiKhoan frmTaiiKhoan = new frmTaiKhoan();
                frmTaiiKhoan.Show();
            }
            else
            {
                MessageBox.Show("Bạn k có quyền truy cập này");

            }

        }

        private void thôngTinPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDatPhong f = new frmDatPhong();
            f.Show();

        }

        private void báoCáoChứcVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChucVuReport f = new frmChucVuReport();
            f.Show();
        }

        private void báoCáoNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhanVienReport f = new frmNhanVienReport();
            f.Show();
        }

        private void báoCáoChiTiếtHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmChiTietHoaDonReport f= new FrmChiTietHoaDonReport();
            f.Show();
        }

        private void báoCáoHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHoaDonReport h = new frmHoaDonReport(); 
            h.Show();
        }
    }
}
