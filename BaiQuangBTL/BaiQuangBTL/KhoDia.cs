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
    public partial class KhoDia : Form
    {
        KetNoi_Database dtBase = new KetNoi_Database();
        public KhoDia()
        {
            InitializeComponent();
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cbMaDia.Text = dgvKhoDia.CurrentRow.Cells[0].Value.ToString();
            txtTenDia.Text = dgvKhoDia.CurrentRow.Cells[1].Value.ToString();
            txtSoLuong.Text = dgvKhoDia.CurrentRow.Cells[2].Value.ToString();
            txtDonGiaNhap.Text = dgvKhoDia.CurrentRow.Cells[3].Value.ToString();
            txtDonGiaBan.Text = (1.1*Convert.ToInt32(txtDonGiaNhap.Text)).ToString();
            cbMaNSX.Text = dgvKhoDia.CurrentRow.Cells[5].Value.ToString();
            cbMaTL.Text = dgvKhoDia.CurrentRow.Cells[6].Value.ToString();
            txtAnh.Text = dgvKhoDia.CurrentRow.Cells[7].Value.ToString();
            if (txtAnh.Text == null)
            {
                picAnh.Image = null;
            }
            else {
                picAnh.Image = Image.FromFile(txtAnh.Text);
                picAnh.SizeMode = PictureBoxSizeMode.Zoom;
            }
            
            txtGhiChu.Text = dgvKhoDia.CurrentRow.Cells[8].Value.ToString();         
        }

        private void btnAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|Gif(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.InitialDirectory = "D:\\Resources\\";
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chon hinh anh de hien thi";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                picAnh.Image = Image.FromFile(dlgOpen.FileName);
                picAnh.SizeMode = PictureBoxSizeMode.Zoom;
                txtAnh.Text = dlgOpen.FileName;
            }
        }

        private void KhoDia_Load(object sender, EventArgs e)
        {
            DataTable dtkhoDia = dtBase.SelectData("select * from KhoDia");
            dgvKhoDia.DataSource = dtkhoDia;
            dgvKhoDia.Columns[0].HeaderText = "Mã Đĩa";
            dgvKhoDia.Columns[1].HeaderText = "Tên Đĩa";
            dgvKhoDia.Columns[2].HeaderText = "Số lượng";
            dgvKhoDia.Columns[3].HeaderText = "Đơn giá bán";
            dgvKhoDia.Columns[4].HeaderText = "Đơn giá nhập";
            dgvKhoDia.Columns[5].HeaderText = "Mã NSX";
            dgvKhoDia.Columns[6].HeaderText = "Mã thể loại";
            dgvKhoDia.Columns[7].HeaderText = "Ảnh";
            dgvKhoDia.Columns[8].HeaderText = "Ghi chú";

            DataTable dtMaDia = dtBase.SelectData("select MaDia from KhoDia");
            cbMaDia.DataSource = dtMaDia;
            cbMaDia.DisplayMember = "MaDia";

            DataTable dtMaNSX = dtBase.SelectData("select MaNSX,TenNSX from NhaSanXuat");
            cbMaNSX.DataSource = dtMaNSX;
            cbMaNSX.ValueMember = "MaNSX";
            //cbMaNSX.DisplayMember = "TenNSX";

            DataTable dtTheLoai = dtBase.SelectData("select MaTheLoai,TenTheLoai from TheLoai");
            cbMaTL.DataSource = dtTheLoai;
            cbMaTL.ValueMember = "MaTheLoai";
            //cbMaTL.DisplayMember = "TenTheLoai";

            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            cbMaDia.Text = null;
            cbMaNSX.Text = null;
            cbMaTL.Text = null;
            txtTenDia.Text = null;
            txtSoLuong.Text = null;
            txtDonGiaNhap.Text = null;
            txtDonGiaBan.Enabled =false;
            txtAnh.Text = null;
            txtGhiChu.Text = null;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DataTable dtbKiemTra = new DataTable("Select * from KhoDia where MaDia='" + cbMaDia.Text + "'");
            if (dtbKiemTra.Rows.Count > 0)
            {
                MessageBox.Show("Bạn phải nhập lại mã, mã này đã có");
                cbMaDia.Focus();


            }
            else
            {
                
                txtDonGiaBan.Text = (1.1 * Convert.ToInt32(txtDonGiaNhap.Text)).ToString();
                dtBase.UpdateData("insert into KhoDia values('" + cbMaDia.Text + "',N'" + txtTenDia.Text +
                    "','"+txtSoLuong.Text+"','"+txtDonGiaNhap.Text+"','"+txtDonGiaBan.Text+"','"+cbMaNSX.Text+
                    "','"+cbMaTL.Text+"','"+txtAnh.Text+"','"+txtGhiChu.Text+"')");
                MessageBox.Show("Bạn đã thêm mới thành công");
                dgvKhoDia.DataSource = dtBase.SelectData("Select * from KhoDia");

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            dtBase.UpdateData("update KhoDia set TenDia=N'" + txtTenDia.Text +
                  "',SoLuong=N'" + txtSoLuong.Text + "',DonGiaNhap='" + txtDonGiaNhap.Text
                  + "',DonGiaBan='" + txtDonGiaBan.Text + "',MaNSX='" + cbMaNSX.Text
                  + "',MaTheLoai='" + cbMaTL.Text + "',GhiChu='" + txtGhiChu.Text 
                  + "'where MaDia='" + cbMaDia.Text + "'");
            MessageBox.Show("Bạn đã sửa thành công");
            dgvKhoDia.DataSource = dtBase.SelectData("select * from KhoDia");

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                dtBase.UpdateData("delete KhoDia where MaDia='" + cbMaDia.Text + "'");
                MessageBox.Show("Bạn đã xóa thành công");
                dgvKhoDia.DataSource = dtBase.SelectData("select * from KhoDia");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc thoát không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
            }


        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dgvKhoDia.DataSource = dtBase.SelectData("select MaDia,TenDia,SoLuong,DonGiaNhap,DonGiaBan,KhoDia.MaNSX,KhoDia.MaTheLoai,Anh,GhiChu " +
                "from KhoDia  inner join TheLoai on KhoDia.MaTheLoai = TheLoai.MaTheLoai " +
                "inner join NhaSanXuat on KhoDia.MaNSX = NhaSanXuat.MaNSX " +
                "where TheLoai.TenTheLoai LIKE N'%"+txtTimKiem.Text+ "%' OR NhaSanXuat.TenNSX LIKE N'%"+txtTimKiem.Text+"%'");
            
            
        }
    }
}
