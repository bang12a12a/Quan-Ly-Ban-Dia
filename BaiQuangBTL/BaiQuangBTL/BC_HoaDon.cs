using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiQuangBTL
{
    
    public partial class BC_HoaDon : Form
    {
        KetNoi_Database dtBase = new KetNoi_Database();
        public BC_HoaDon()
        {
            InitializeComponent();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {

            dgvTKHoaDonBan.DataSource = dtBase.SelectData("select * from HoaDonNhap  where" +
                " MONTH(NgayNhap) = '"+cbThongKe.Text+"' and YEAR(NgayNhap) = '"+cbNam.Text+"' ");

            txtTongTien.Text = dtBase.LoadLable("select Sum(TongTien) from HoaDonNhap  where" +
                " MONTH(NgayNhap) = '" + cbThongKe.Text + "' and YEAR(NgayNhap) = '" + cbNam.Text + "' ");

        }

    }
}
