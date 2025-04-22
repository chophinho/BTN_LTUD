using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace QL_KHACH_SAN
{
    public partial class frmChiTietDichVu : Form
    {
        KetNoi2 kn = new KetNoi2();
        public frmChiTietDichVu()
        {
            InitializeComponent();
        }
        private void LoadCHITIET()
        {
            dataGridView1.DataSource = kn.LayDuLieu("SELECT * FROM CHITIETDICHVU");
            
        }
        public void MAHD()
        {
            DataTable dt = new DataTable();
            dt = kn.LayDuLieu("SELECT * From HOADON");
            cboHoaDON.DataSource = dt;
            cboHoaDON.DisplayMember = "MaHoaDon";
        }
        public void MADV()
        {
            DataTable dt = new DataTable();
            dt = kn.LayDuLieu("SELECT * From DICHVU");
            cboMaDV.DataSource = dt;
            cboMaDV.DisplayMember = "MaDichVu";
        }
        private void HienThi_DuLieu()
        {
            txtChiTiet.DataBindings.Clear();
            txtChiTiet.DataBindings.Add("Text", dataGridView1.DataSource, "MaChiTietDichVu");

            cboHoaDON.DataBindings.Clear();
            cboHoaDON.DataBindings.Add("Text", dataGridView1.DataSource, "MaHoaDon");

            cboMaDV.DataBindings.Clear();
            cboMaDV.DataBindings.Add("Text", dataGridView1.DataSource, "MaDichVu");

            txtSoLuong.DataBindings.Clear();
            txtSoLuong.DataBindings.Add("Text", dataGridView1.DataSource, "SoLuong");


        }

        private void frmChiTietDichVu_Load(object sender, EventArgs e)
        {
            LoadCHITIET();
            MADV();
            MAHD();
            HienThi_DuLieu();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtGiaDichVu_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMoTa_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtTenDichVu_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtSoLuong.Text = "";
            txtChiTiet.Text = "";
            cboHoaDON.Text = "";
            cboMaDV.Text = "";

            txtChiTiet.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string strKra = "select MaChiTietDichVu from ChiTietDichVu where MaChiTietDichVu= '" + txtChiTiet.Text + "' ";
            SqlCommand cmd = new SqlCommand(strKra, kn.cnn);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read() == true)
            {
                MessageBox.Show("MÃ này đã tồn tại, nhập mã khác");
                txtChiTiet.Focus();
                rdr.Close();
                rdr.Dispose();
            }
            else
            {




                string sql_luu = "INSERT INTO ChiTietDichVu (MaChiTietDichVu, MaHoaDon, MaDichVu, SoLuong) " +
                                 "VALUES ('" + txtChiTiet.Text + "', '" + cboHoaDON.Text + "', '" + cboMaDV.Text + "', '" + txtSoLuong.Text + "')";

                kn.ThucThi(sql_luu);

                LoadCHITIET();
                HienThi_DuLieu();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql_sua = "Update ChiTietDichVu Set MaChiTietDichVu ='" + txtChiTiet.Text + "',MaHoaDon ='" + cboHoaDON.Text + "',MaDichVu = '" + cboMaDV.Text + "',SoLuong ='" + txtSoLuong.Text + "' Where MaChiTietDichVu ='" + txtChiTiet.Text + "'";
            kn.ThucThi(sql_sua);
            LoadCHITIET();
            HienThi_DuLieu();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql_xoa = "Delete ChiTietDichVu where MaChiTietDichVu = '" + txtChiTiet.Text + "'";
            kn.ThucThi(sql_xoa);
            LoadCHITIET();
            HienThi_DuLieu();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
