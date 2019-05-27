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
    public partial class BC_SanPham : Form
    {
        KetNoi_Database dtBase = new KetNoi_Database();
        public BC_SanPham()
        {
            InitializeComponent();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            /*dgvSanPham.DataSource = dtBase.SelectData("select * from KhoDia " +
                "where MaDia = (SELECT MaDia FROM  KhoDia EXCEPT SELECT MaDia FROM  ChiTietHDB)");*/
            dgvSanPham.DataSource = dtBase.SelectData("SELECT TenDia,DonGiaBan,DonGiaNhap,SoLuong" +
                " FROM  KhoDia,"+cbThongKe.Text+"  where KhoDia.MaDia = "+cbThongKe.Text+".MaDia");
        }

        private void BC_SanPham_Load(object sender, EventArgs e)
        {

        }
    }
}
