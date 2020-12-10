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
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            Admin fadmin = new Admin();
            fadmin.ShowDialog();
        }

        private void btnThongTinTK_Click(object sender, EventArgs e)
        {
            ThongTinTaiKhoan fthongtintaikhoan = new ThongTinTaiKhoan();
            fthongtintaikhoan.ShowDialog();
        }

        private void btnDanhSach_Click(object sender, EventArgs e)
        {
            DatLich fdatlich = new DatLich();
            fdatlich.ShowDialog();
        }
    }
}
