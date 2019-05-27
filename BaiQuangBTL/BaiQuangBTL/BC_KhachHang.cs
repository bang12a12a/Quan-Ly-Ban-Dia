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
    public partial class BC_KhachHang : Form
    {
        KetNoi_Database dtBase = new KetNoi_Database();
        public BC_KhachHang()
        {
            InitializeComponent();
        }

        private void BC_KhachHang_Load(object sender, EventArgs e)
        {
            DataTable dtMaKhach = dtBase.SelectData("select MaKhach from HoaDonBan");
            cbKhachHang.DataSource = dtMaKhach;
            cbKhachHang.DisplayMember = "MaKhach";
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            dgvTKHoaDonBan.DataSource = dtBase.SelectData("select * from HoaDonBan  where" +
                " MaKhach = '" + cbKhachHang.Text + "' ");

            txtTongTien.Text = dtBase.LoadLable("select Sum(TongTien) from HoaDonBan  where" +
                " MaKhach = '" + cbKhachHang.Text + "' ");
        }
    }
}
