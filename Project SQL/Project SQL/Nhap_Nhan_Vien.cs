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
    public partial class Nhap_Nhan_Vien : Form
    {
        public Nhap_Nhan_Vien()
        {
            InitializeComponent();
         
        }

       
        private void btnNhapNhanVienEx_Click(object sender, EventArgs e)
        {
            string name = txtTenNhanVien.Text;
            DateTime birth = Convert.ToDateTime(txtNgaySinh.Text);
            string sex = txtGioiTinh.Text;
            string phoneNumber = txtSodienthoai.Text;
            string email = txtEmail.Text;
            string address = txtDiaChi.Text;
            int chucVu = Convert.ToInt32(txtChucVu.Text);

            if (NhanVienDA.Instance.insertNhanVien(name, birth, sex, phoneNumber, email, address, chucVu))
            {
                MessageBox.Show("Thực hiện thêm thông tin hãng thành công");
               

            }
            else
            {
                MessageBox.Show("Thực hiện việc thêm thông tin hãng không đúng");
            }
        }

      
    }
}
