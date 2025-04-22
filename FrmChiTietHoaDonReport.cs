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
    public partial class FrmChiTietHoaDonReport : Form
    {
        public FrmChiTietHoaDonReport()
        {
            InitializeComponent();
        }
        KetNoi kn=new KetNoi();
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            DataTable dta = new DataTable();
            dta = kn.LayDuLieu("SELECT * FROM CHITIETHOADON");
            ChiTietHoaDonReport report1 = new ChiTietHoaDonReport();
            report1.SetDataSource(dta);
            crystalReportViewer1.ReportSource = report1;
        }
    }
}
