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
    public partial class KhachHang : Form
    {
        public KhachHang()
        {
            InitializeComponent();
        }

        private void btnNhapKhachHang_Click(object sender, EventArgs e)
        {
            string name = txtTenKhachHang.Text;
            DateTime birth = Convert.ToDateTime(txtNgaysinh.Text);
            string sex = txtGioitinh.Text;
            string phoneNumber = txtSodienthoai.Text;
            string email = txtEmail.Text;
            string address = txtDiaChi.Text;
            int chucVu = 1;
            

            if (KhachHangDA.Instance.insertKhachHang(name, birth, sex, phoneNumber, email, address, chucVu))
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
