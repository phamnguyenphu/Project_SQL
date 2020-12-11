using Project_SQL.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_SQL
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            Load_Hang();
            loadNhanVien();
            loadKhachHang();
        }

        void loadKhachHang()
        {
            dtgvKhachHang.DataSource = KhachHangDA.Instance.danhSachKhachHang();
        }
        void loadNhanVien()
        {
            dtgvNhanVien.DataSource = NhanVienDA.Instance.danhSachNhanVien();
        }
        void Load_Hang()
        {
            dtgvHang.DataSource = HangDA.Instance.LayDanhSachHang();
        }
        private void btnNhap_Hang_Click(object sender, EventArgs e)
        {
            string name = txtTenHang.Text;
           
            if (HangDA.Instance.Insert_Hang(name))
            {
                MessageBox.Show("Thực hiện thêm thông tin hãng thành công");
                Load_Hang();

            }
            else
            {
                MessageBox.Show("Thực hiện việc thêm thông tin hãng không đúng");
            }
        }

        private void btnSua_Hang_Click(object sender, EventArgs e)
        {
            string name = txtTenHang.Text;
            int id = Convert.ToInt32(txtMaHang.Text);
            if (HangDA.Instance.Update_Hang(name, id))
            {
                MessageBox.Show("Thực hiện chỉnh sửa thông tin hãng thành công");
                Load_Hang();

            }
            else
            {
                MessageBox.Show("Thực hiện việc thêm thông tin hãng không đúng");
            }
        }

        private void btnXoa_Hang_Click(object sender, EventArgs e)
        { 
            int id = Convert.ToInt32(txtMaHang.Text);
            if (HangDA.Instance.Delete_Hang(id))
            {
                MessageBox.Show("Thực hiện chỉnh sửa thông tin hãng thành công");
                Load_Hang();

            }
            else
            {
                MessageBox.Show("Thực hiện việc thêm thông tin hãng không đúng");
            }
        }

        private void btnNhapNhanVien_Click(object sender, EventArgs e)
        {
            Nhap_Nhan_Vien fnhapNhanVien = new Nhap_Nhan_Vien();
            fnhapNhanVien.ShowDialog();
        }

   
        private void button1_Click_1(object sender, EventArgs e)
        {
            loadNhanVien();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            KhachHang fnhapKhachHang = new KhachHang();
            fnhapKhachHang.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            loadKhachHang();
        }

        void loadKhachHangTheoId(int id)
        {
            
        }
    }
}
