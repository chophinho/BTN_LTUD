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
    public partial class frmChiTietHoaDon : Form
    {
        KetNoi2 KetNoi2 = new KetNoi2();
        public frmChiTietHoaDon()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadCHITIET()
        {
            dataGridView1.DataSource = KetNoi2.LayDuLieu("SELECT * FROM V_ChiTietHoaDon");

        }

        private void frmChiTietHoaDon_Load(object sender, EventArgs e)
        {
            LoadCHITIET();

        }
    }
}
