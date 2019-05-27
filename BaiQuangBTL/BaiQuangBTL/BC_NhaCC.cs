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
    public partial class BC_NhaCC : Form
    {
        KetNoi_Database dtBase = new KetNoi_Database();
        public BC_NhaCC()
        {
            InitializeComponent();
        }

        private void BC_NhaCC_Load(object sender, EventArgs e)
        {

        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {


            dgvNhaCungCap.DataSource = dtBase.SelectData("select top(5) HoaDonNhap.MaNCC as 'MaNCC'" +
                ",TenNCC,DiaChi,DienThoai,sum(SoLuong) as'so luong' from ChiTietHDN,HoaDonNhap,NhaCungCap " +
                "where ChiTietHDN.SoHDN = HoaDonNhap.SoHDN and NhaCungCap.MaNCC = HoaDonNhap.MaNCC " +
                "and YEAR(NgayNhap) = '"+cbNam.Text+"' group by HoaDonNhap.MaNCC, TenNCC, DiaChi, DienThoai");
        }
    }
}
