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
    public partial class HoaDonNhap : Form
    {
        KetNoi_Database dtBase = new KetNoi_Database();
        public static double donGiaBan;
        public HoaDonNhap()
        {
            InitializeComponent();
        }
        
        private void HoaDonNhap_Load(object sender, EventArgs e)
        {
            DataTable dtHoaDon = dtBase.SelectData("Select * from HoaDonNhap");
            dgvhdnhap.DataSource = dtHoaDon;
            dgvhdnhap.Columns[0].HeaderText = "Mã hóa đơn nhập";
            dgvhdnhap.Columns[2].HeaderText = "Ngày nhập";
            dgvhdnhap.Columns[1].HeaderText = "Mã nhân viên";
            dgvhdnhap.Columns[3].HeaderText = "Mã nhà cung cấp";
            dgvhdnhap.Columns[4].HeaderText = "Thành tiền";
            dtHoaDon.Dispose();

            DataTable dtChiTietHD = dtBase.SelectData("Select * from ChiTietHDN");
            dgvcthdnhap.DataSource = dtChiTietHD;
            dgvcthdnhap.Columns[0].HeaderText = "Mã hóa đơn";
            dgvcthdnhap.Columns[1].HeaderText = "Mã hàng";
            dgvcthdnhap.Columns[4].HeaderText = "Giảm giá";
            dgvcthdnhap.Columns[2].HeaderText = "Số lượng";
            dgvcthdnhap.Columns[3].HeaderText = "Đơn giá nhập";
            dgvcthdnhap.Columns[5].HeaderText = "Thành tiền";
            dtHoaDon.Dispose();

            DataTable dtMaNhanVien = dtBase.SelectData("Select MaNhanVien from NhanVien");
            cbManhanvien.DataSource = dtMaNhanVien;
            cbManhanvien.DisplayMember = "MaNhanVien";

            DataTable dtMaNCC = dtBase.SelectData("Select MaNCC from NhaCungCap");
            cbManhacungcap.DataSource = dtMaNCC;
            cbManhacungcap.DisplayMember = "MaNCC";

            DataTable dtMaDia = dtBase.SelectData("Select MaDia from KhoDia");
            cbMahang.DataSource = dtMaDia;
            cbMahang.DisplayMember = "MaDia";

        }

        private void dgvhdnhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMHDnhap.Text = dgvhdnhap.CurrentRow.Cells[0].Value.ToString();
            cbManhanvien.Text = dgvhdnhap.CurrentRow.Cells[1].Value.ToString();
            dtpNgayNhap.Text = dgvhdnhap.CurrentRow.Cells[2].Value.ToString();           
            cbManhacungcap.Text = dgvhdnhap.CurrentRow.Cells[3].Value.ToString();
            txtThanhtienhd.Text = dgvhdnhap.CurrentRow.Cells[4].Value.ToString();
            DataTable dtChiTietHD = dtBase.SelectData("Select * from ChiTietHDN where SoHDN='" + txtMHDnhap.Text + "'");
            dgvcthdnhap.DataSource = dtChiTietHD;
            txtMHDnhap.Enabled = false;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            btnThoat.Enabled = true;
            btnThem.Enabled = true;
        }



        private void dgvcthdnhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMahoadon.Text = dgvcthdnhap.CurrentRow.Cells[0].Value.ToString();
            cbMahang.Text = dgvcthdnhap.CurrentRow.Cells[1].Value.ToString();
            txtSoluong.Text = dgvcthdnhap.CurrentRow.Cells[2].Value.ToString();
            txtDongianhap.Text = dgvcthdnhap.CurrentRow.Cells[3].Value.ToString();
            txtGiamgia.Text = dgvcthdnhap.CurrentRow.Cells[4].Value.ToString();
            txtThanhtien.Text = dgvcthdnhap.CurrentRow.Cells[5].Value.ToString();
            txtMahoadon.Enabled = false;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            btnThoat.Enabled = true;
            btnThem.Enabled = true;
        }

        private void btnThemchitiet_Click(object sender, EventArgs e)
        {
            txtMahoadon.Text = txtMHDnhap.Text;
            cbMahang.Text = "";
            txtGiamgia.Text = "";
            txtSoluong.Text = "";
            txtDongianhap.Text = "";
            txtThanhtien.Text = "";
            txtThanhtien.Enabled=false;
        }

        private void btnLuuchitiet_Click(object sender, EventArgs e)
        {
            DataTable dtbKiemTra = new DataTable("Select * from ChiTietHDN where SoHDN='" + txtMahoadon.Text + "'");
            if (dtbKiemTra.Rows.Count > 0)
            {
                MessageBox.Show("Bạn phải nhập lại mã, mã này đã có");
                txtMahoadon.Focus();
            }
            else
            {
                double dongia, giamgia,soluong;
                dongia = Convert.ToDouble(txtDongianhap.Text);
                giamgia = Convert.ToDouble(txtGiamgia.Text);
                soluong = Convert.ToDouble(txtSoluong.Text);
                txtThanhtien.Text = (dongia*soluong - giamgia).ToString();
                dtBase.UpdateData("insert into ChiTietHDN values('" + txtMahoadon.Text + "',N'" 
                    + cbMahang.Text + "','" + txtSoluong.Text + "',N'" + txtDongianhap.Text +
                    "',N'" + txtGiamgia.Text + "','" + txtThanhtien.Text + "')");
                MessageBox.Show("Bạn đã thêm mới thành công");
                dgvcthdnhap.DataSource = dtBase.SelectData("Select * from ChiTietHDN");

                double donGiaBan;
                donGiaBan = 1.1 * Convert.ToDouble(txtDongianhap.Text);
                dtBase.UpdateData("update KhoDia set SoLuong=SoLuong +" + txtSoluong.Text + " where MaDia='" + cbMahang.Text + "'");
                dtBase.UpdateData("update KhoDia set DonGiaNhap='" + txtDongianhap.Text + "',DonGiaBan="+donGiaBan+" where MaDia='" + cbMahang.Text + "'");
                dtBase.UpdateData("update HoaDonNhap set TongTien = (select Sum(ThanhTien) from ChiTietHDN ) where SoHDN = '"+txtMHDnhap.Text+"'");
            }
        }

        private void btnSuachitiet_Click(object sender, EventArgs e)
        {
            dtBase.UpdateData("update ChiTietHDN set SoLuong='" + txtSoluong.Text +
                    "',DonGia='" + txtDongianhap.Text + "',GiamGia=N'" + txtGiamgia.Text + "',ThanhTien='" +
                    txtThanhtien.Text + "' where SoHDN='" + txtMahoadon.Text + "' and MaDia=N'" + cbMahang.Text + "'");
            dgvcthdnhap.DataSource = dtBase.SelectData("select * from ChiTietHDN");

            
            donGiaBan = 1.1 * Convert.ToDouble(txtDongianhap.Text);
            dtBase.UpdateData("update KhoDia set SoLuong=SoLuong +" + txtSoluong.Text + " where MaDia='" + cbMahang.Text + "'");
            //dtBase.UpdateData("update ChiTietHDB set DonGia='" + donGiaBan + " where MaDia='" + cbMahang.Text + "'");
            dtBase.UpdateData("update KhoDia set DonGiaNhap='" + txtDongianhap.Text + "',DonGiaBan=" + donGiaBan + " where MaDia='" + cbMahang.Text + "'");
            dtBase.UpdateData("update HoaDonNhap set TongTien = (select Sum(ThanhTien) from ChiTietHDN ) where SoHDN = '" + txtMHDnhap.Text + "'");
        }

        private void btnXoachitiet_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa chất liệu có mã là:" + txtMahoadon.Text + " không?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                dtBase.UpdateData("delete ChiTietHDN where SoHDN='" + txtMahoadon.Text + "' AND MaDia ='"+cbMahang.Text+"'");
                dgvcthdnhap.DataSource = dtBase.SelectData("Select * from ChiTietHDN");

                
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMHDnhap.Text = "";
            dtpNgayNhap.Text = "";
            cbManhanvien.Text = "";
            cbManhacungcap.Text = "";
            txtThanhtienhd.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DataTable dtbKiemTra = new DataTable("Select * from HoaDonNhap where SoHDN='" + txtMHDnhap.Text + "'");
            if (dtbKiemTra.Rows.Count > 0)
            {
                MessageBox.Show("Bạn phải nhập lại mã, mã này đã có");
                txtMHDnhap.Focus();


            }
            else
            {
                dtBase.UpdateData("insert into HoaDonNhap values('" + txtMHDnhap.Text + "','" + cbManhanvien.Text + "','" + dtpNgayNhap.Text+
                         "','" + cbManhacungcap.Text + "','" + txtThanhtienhd.Text + "')");
                MessageBox.Show("Bạn đã thêm mới thành công");
                dgvhdnhap.DataSource = dtBase.SelectData("Select * from HoaDonNhap");

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa chất liệu có mã là:" + txtMHDnhap.Text + " không?", "Thông báo",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                dtBase.UpdateData("delete HoaDonNhap where MaHDN='" + txtMHDnhap.Text + "'");
                dgvhdnhap.DataSource = dtBase.SelectData("Select * from HoaDonNhap");

                dtBase.UpdateData("delete ChiTietHDN where SoHDN='" + txtMHDnhap.Text + "'");

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMHDnhap.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên chất liệu", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMHDnhap.Focus();
            }
            else
            {
                dtBase.UpdateData("update HoaDonNhap set NgayNhap='" + dtpNgayNhap.Text + "',MaNV='" + cbManhanvien.Text +
                    "',MaNhaCC='" + cbManhacungcap.Text + "',TongTien=N'" + txtThanhtienhd.Text + "' where SoHDN='" + txtMHDnhap.Text + "'");
                
                dgvhdnhap.DataSource = dtBase.SelectData("select * from HoaDonNhap");
                
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc thoát không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
