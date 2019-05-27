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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void khoHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KhoDia khoDia = new KhoDia();
            khoDia.Show();
        }

        private void hóaĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HoaDonNhap hoaDonNhap = new HoaDonNhap();
            hoaDonNhap.Show();
        }

        private void hóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HoaDonBan hoaDonBan = new HoaDonBan();
            hoaDonBan.Show();
        }

        private void báoCáoSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BC_SanPham bC_SanPham = new BC_SanPham();
            bC_SanPham.Show();
        }

        private void báoCáoHóaĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BC_HoaDon bC_HoaDon = new BC_HoaDon();
            bC_HoaDon.Show();
        }

        private void báoCáoHóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BC_KhachHang bC_KhachHang = new BC_KhachHang();
            bC_KhachHang.Show();
        }

        private void báoCáoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BC_NhaCC bC_NhaCC = new BC_NhaCC();
            bC_NhaCC.Show();
        }
    }
}
