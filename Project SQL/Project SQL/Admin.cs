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
    }
}
