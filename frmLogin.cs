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

namespace QL_KHACH_SAN
{
    public partial class frmLogin : Form
    {

        public string currentUserRole;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnDANGNHAP_Click(object sender, EventArgs e)
        {
            string username = txtTAIKHOAN.Text;
            string password = txtMATKHAU.Text;

            if (KiemTraDangNhap(username, password))
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();

               frmMenu menu = new frmMenu();
                menu.TenDangNhap = username;
                menu.Quyen = currentUserRole;
                menu.FormClosed += new FormClosedEventHandler(Menu_FormClosed);
                menu.Show();

            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            this.Close();  
        }
        KetNoi kn = new KetNoi();
        private bool KiemTraDangNhap(string username, string password)
        {
            kn.KetNoiDatabase();
            string query = "SELECT * FROM TAIKHOAN WHERE TenDangNhap = '" + username + "' AND MatKhau = '" + password + "'";

            SqlCommand cmd = new SqlCommand(query, kn.cnn);
            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                string quyen = rdr["VaiTro"].ToString();
                currentUserRole = quyen;
                rdr.Close();
                return true;
            }

            rdr.Close();
            return false;


        }

    }
}
