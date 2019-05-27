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
    public partial class HoaDonBan : Form
    {
        KetNoi_Database dtBase = new KetNoi_Database();
        public HoaDonBan()
        {
            InitializeComponent();
        }
 
        private void HoaDonBan_Load(object sender, EventArgs e)
        {
            DataTable dtHoaDon = dtBase.SelectData("Select * from HoaDonBan");
            dgvhdban.DataSource = dtHoaDon;
            dgvhdban.Columns[0].HeaderText = "Mã hóa đơn nhập";
            dgvhdban.Columns[2].HeaderText = "Ngày nhập";
            dgvhdban.Columns[1].HeaderText = "Mã nhân viên";
            dgvhdban.Columns[3].HeaderText = "Mã nhà cung cấp";
            dgvhdban.Columns[4].HeaderText = "Thành tiền";


            DataTable dtChiTietHD = dtBase.SelectData("Select * from ChiTietHDB");
            dgvcthdban.DataSource = dtChiTietHD;
            dgvcthdban.Columns[0].HeaderText = "Mã hóa đơn";
            dgvcthdban.Columns[1].HeaderText = "Mã hàng";
            dgvcthdban.Columns[4].HeaderText = "Giảm giá";
            dgvcthdban.Columns[2].HeaderText = "Số lượng";
            dgvcthdban.Columns[3].HeaderText = "Đơn giá";
            dgvcthdban.Columns[5].HeaderText = "Thành tiền";


            DataTable dtMaNhanVien = dtBase.SelectData("Select MaNhanVien from NhanVien");
            cbManhanvien.DataSource = dtMaNhanVien;
            cbManhanvien.DisplayMember = "MaNhanVien";

            DataTable dtKhachHang = dtBase.SelectData("Select MaKhach from KhachHang");
            cbMaKhach.DataSource = dtKhachHang;
            cbMaKhach.DisplayMember = "MaKhach";

            DataTable dtMaDia = dtBase.SelectData("Select MaDia from KhoDia");
            cbMahang.DataSource = dtMaDia;
            cbMahang.DisplayMember = "MaDia";
        }

        private void dgvhdban_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMHDban.Text = dgvhdban.CurrentRow.Cells[0].Value.ToString();
            cbManhanvien.Text = dgvhdban.CurrentRow.Cells[1].Value.ToString();
            dtpNgayBan.Text = dgvhdban.CurrentRow.Cells[2].Value.ToString();
            cbMaKhach.Text = dgvhdban.CurrentRow.Cells[3].Value.ToString();
            txtTongtien.Text = dgvhdban.CurrentRow.Cells[4].Value.ToString();
            DataTable dtChiTietHD = dtBase.SelectData("Select * from ChiTietHDB where SoHDB='" + txtMHDban.Text + "'");
            dgvcthdban.DataSource = dtChiTietHD;
        
        }

        private void dgvcthdban_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMahoadonban.Text = dgvcthdban.CurrentRow.Cells[0].Value.ToString();
            cbMahang.Text = dgvcthdban.CurrentRow.Cells[1].Value.ToString();
            txtSoluong.Text = dgvcthdban.CurrentRow.Cells[2].Value.ToString();
            txtDonGiaBan.Text = dgvcthdban.CurrentRow.Cells[3].Value.ToString();
            txtGiamgia.Text = dgvcthdban.CurrentRow.Cells[4].Value.ToString();
            txtThanhtien.Text = dgvcthdban.CurrentRow.Cells[5].Value.ToString();
        }

        private void btnThemchitiet_Click(object sender, EventArgs e)
        {
            txtMahoadonban.Text = txtMHDban.Text;
            cbMahang.Text = "";
            txtGiamgia.Text = "";
            txtSoluong.Text = "";
            txtThanhtien.Text = "";
            txtDonGiaBan.Text = "";
            txtThanhtien.Enabled = false;
        }

        private void btnLuuchitiet_Click(object sender, EventArgs e)
        {
            DataTable dtbKiemTra = new DataTable("Select * from ChiTietHDB where SoHDB='" + txtMahoadonban.Text + "'");
            if (dtbKiemTra.Rows.Count > 0)
            {
                MessageBox.Show("Bạn phải nhập lại mã, mã này đã có");
                txtMahoadonban.Focus();
            }
            else
            {
                
                double dongia, giamgia, soluong;
                //dongia= Convert.ToDouble(dtBase.SelectData("SELECT DonGiaBan FROM KhoHang WHERE Mahang = N'" + mahangxoa + "'"));
                dongia = Convert.ToDouble(txtDonGiaBan.Text);
                giamgia = Convert.ToDouble(txtGiamgia.Text);
                soluong = Convert.ToDouble(txtSoluong.Text);
                txtThanhtien.Text = (dongia * soluong - giamgia).ToString();
                dtBase.UpdateData("insert into ChiTietHDB values('" + txtMahoadonban.Text + "',N'"
                    + cbMahang.Text + "','" + txtSoluong.Text + "',N'" + txtDonGiaBan.Text +
                    "',N'" + txtGiamgia.Text + "','" + txtThanhtien.Text + "')");
                MessageBox.Show("Bạn đã thêm mới thành công");
                dgvcthdban.DataSource = dtBase.SelectData("Select * from ChiTietHDB");

                
                dtBase.UpdateData("update KhoDia set SoLuong=SoLuong -" + txtSoluong.Text + " where MaDia='" + cbMahang.Text + "'");
                //dtBase.UpdateData("update ChiTietHDB set DonGia='" + txtDonGiaBan.Text + "',DonGiaBan=" + donGiaBan + " where MaDia='" + cbMahang.Text + "'");
                dtBase.UpdateData("update HoaDonBan set TongTien = (select Sum(ThanhTien) from ChiTietHDB ) where SoHDB = '" + txtMahoadonban.Text + "'");
                dgvhdban.DataSource = dtBase.SelectData("Select * from HoaDonBan");
            }
        }

           private void btnSuachitiet_Click(object sender, EventArgs e)
        {
            dtBase.UpdateData("update ChiTietHDB set MaDia=N'" + cbMahang.Text + "',SoLuong='" + txtSoluong.Text +
                    "',DonGia='" + txtDonGiaBan.Text + "',GiamGia=N'" + txtGiamgia.Text + "',ThanhTien='" + txtThanhtien.Text + "' where SoHDN='" + txtMahoadonban.Text + "'");
            dgvcthdban.DataSource = dtBase.SelectData("select * from ChiTietHDB");

            double donGiaBan;
            donGiaBan = 1.1 * Convert.ToDouble(txtDonGiaBan.Text);
            dtBase.UpdateData("update KhoDia set SoLuong=SoLuong -" + txtSoluong.Text + " where MaDia='" + cbMahang.Text + "'");
            dtBase.UpdateData("update KhoDia set DonGiaBan='" + txtDonGiaBan.Text + "',DonGiaBan=" + donGiaBan + " where MaDia='" + cbMahang.Text + "'");
            dtBase.UpdateData("update HoaDonBan set TongTien = (select Sum(ThanhTien) from ChiTietHDB ) where SoHDB = '" + txtMahoadonban.Text + "'");
        }

        private void cbMahang_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDonGiaBan.Text = dtBase.LoadLable("select DonGiaBan from KhoDia where MaDia ='" + cbMahang.Text + "'");
        }

        private void btnXoachitiet_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa chất liệu có mã là:" + cbMahang.Text + " không?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                dtBase.UpdateData("delete ChiTietHDB where SoHDB='" + txtMahoadonban.Text + "' AND MaDia ='" + cbMahang.Text + "'");
                dgvcthdban.DataSource = dtBase.SelectData("Select * from ChiTietHDB");
                dtBase.UpdateData("update HoaDonBan set TongTien = (select Sum(ThanhTien) from ChiTietHDB ) where SoHDB = '" + txtMahoadonban.Text + "'");
                dgvhdban.DataSource = dtBase.SelectData("Select * from HoaDonBan");

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMHDban.Text = "";
            cbManhanvien.Text = "";
            cbManhanvien.Text = "";
            dtpNgayBan.Text = "";
            cbMaKhach.Text = "";
            txtTongtien.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DataTable dtbKiemTra = new DataTable("Select * from HoaDonBan where SoHDB='" + txtMHDban.Text + "'");
            if (dtbKiemTra.Rows.Count > 0)
            {
                MessageBox.Show("Bạn phải nhập lại mã, mã này đã có");
                txtMahoadonban.Focus();


            }
            else
            {
                dtBase.UpdateData("insert into HoaDonBan values('" + txtMHDban.Text + "',N'" + cbManhanvien.Text + "',N'" + dtpNgayBan.Text +
                        "',N'" + cbMaKhach.Text + "','" + txtTongtien.Text + "')");
                MessageBox.Show("Bạn đã thêm mới thành công");
                dgvhdban.DataSource = dtBase.SelectData("Select * from HoaDonBan");

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa chất liệu có mã là:" + txtMHDban.Text + " không?", "Thông báo",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                dtBase.UpdateData("delete HoaDonBan where MaHDB='" + txtMHDban.Text + "'");
                dgvhdban.DataSource = dtBase.SelectData("Select * from HoaDonBan");

                dtBase.UpdateData("delete ChiTietHDB where SoHDB='" +txtMHDban.Text + "'");

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMHDban.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên chất liệu", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMahoadonban.Focus();
            }
            else
            {
                dtBase.UpdateData("update HoaDonNhap set NgayNhap=N'" + dtpNgayBan.Text + "',MaNV='" + cbManhanvien.Text +
                    "',MaKhach='" + cbMaKhach.Text + "',TongTien=N'" + txtTongtien.Text + "' where SoHDB='" + txtMHDban.Text + "'");

                dgvhdban.DataSource = dtBase.SelectData("select * from HoaDonBan");

            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát ko?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dgvhdban.DataSource = dtBase.SelectData("select HoaDonBan.SoHDB, MaNhanVien,NgayBan,MaKhach,TongTien  " +
                "from HoaDonBan,ChiTietHDB where HoaDonBan.SoHDB=ChiTietHDB.SoHDB and ChiTietHDB.MaDia LIKE N'%"+cbMahang.Text+"%' " +
                "and HoaDonBan.MaKhach LIKE N'%"+cbMaKhach.Text+"%' and HoaDonBan.MaNhanVien LIKE '%"+cbManhanvien.Text+"%'");
        }
    }
}
