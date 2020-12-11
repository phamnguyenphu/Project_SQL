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
using System.Data.SqlClient;
using Project_SQL.BS_Layer;
namespace Project_SQL
{


    public partial class Admin : Form
    {

        //San pham
        DataTable dtSanpham = null;
        string err;
        BLSanPham dbSP = new BLSanPham();
        bool Them;
        

        private void dtgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dtgvSanpham.CurrentCell.RowIndex;
            this.txtMaSP.Text = dtgvSanpham.Rows[r].Cells[0].Value.ToString();
            this.txtHang.Text = dtgvSanpham.Rows[r].Cells[1].Value.ToString();
            this.txtTenSP.Text = dtgvSanpham.Rows[r].Cells[2].Value.ToString();
            this.txtGiaSP.Text = dtgvSanpham.Rows[r].Cells[3].Value.ToString();
            this.txtDongSP.Text = dtgvSanpham.Rows[r].Cells[4].Value.ToString();
            this.txtTG.Text = dtgvSanpham.Rows[r].Cells[5].Value.ToString();
            this.txtNoiSX.Text = dtgvSanpham.Rows[r].Cells[6].Value.ToString();
            this.txtMota.Text = dtgvSanpham.Rows[r].Cells[7].Value.ToString();
            this.txtUrl.Text = dtgvSanpham.Rows[r].Cells[8].Value.ToString();
            this.txtMau.Text = dtgvSanpham.Rows[r].Cells[9].Value.ToString();
            this.txtSoghe.Text = dtgvSanpham.Rows[r].Cells[10].Value.ToString();
            this.txtNhienlieu.Text = dtgvSanpham.Rows[r].Cells[11].Value.ToString();


        }
        public void LoadSP()
        {
            try
            {
                dtSanpham = new DataTable();
                dtSanpham.Clear();
                DataSet ds = dbSP.LaySanPham();
                dtSanpham = ds.Tables[0];
                dtgvSanpham.DataSource = dtSanpham;
                dtgvSanpham.AutoResizeColumns();

                btnHuy.Enabled = false;
                btnLuu.Enabled = false;

                btnNhap.Enabled = true;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;

                dtgvSanPham_CellClick(null, null);
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được");
            }
        }
        private void btnNhap_Click(object sender, EventArgs e)
        {
            Them = true;
            this.txtMaSP.ResetText();
            this.txtHang.ResetText();
            this.txtTenSP.ResetText();
            this.txtGiaSP.ResetText();
            this.txtDongSP.ResetText();
            this.txtTG.ResetText();
            this.txtNoiSX.ResetText();
            this.txtMota.ResetText();
            this.txtUrl.ResetText();
            this.txtMau.ResetText();
            this.txtSoghe.ResetText();
            this.txtNhienlieu.ResetText();

            btnHuy.Enabled = true;
            btnLuu.Enabled = true;

            btnNhap.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;


            this.txtMaSP.Focus();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {

            this.txtMaSP.ResetText();
            this.txtHang.ResetText();
            this.txtTenSP.ResetText();
            this.txtGiaSP.ResetText();
            this.txtDongSP.ResetText();
            this.txtTG.ResetText();
            this.txtNoiSX.ResetText();
            this.txtMota.ResetText();
            this.txtUrl.ResetText();
            this.txtMau.ResetText();
            this.txtSoghe.ResetText();
            this.txtNhienlieu.ResetText();


            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            this.txtMaSP.Enabled = true;
            btnNhap.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            dtgvSanPham_CellClick(null, null);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
           
            if (Them)
            {
               
                try
                {
                    BLSanPham blsp = new BLSanPham();
                    blsp.ThemSanPham(int.Parse(txtHang.Text), txtTenSP.Text, decimal.Parse(txtGiaSP.Text), txtDongSP.Text, txtTG.Text, txtNoiSX.Text, txtMota.Text, txtUrl.Text, txtMau.Text, int.Parse(txtSoghe.Text),
                    txtNhienlieu.Text, ref err);
                    LoadSP();

                    MessageBox.Show("Đã Thêm!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thêm được!!");
                }
            }
            else
            {
                
                    BLSanPham blsp = new BLSanPham();
                    blsp.SuaSanPham(int.Parse(txtMaSP.Text),int.Parse(txtHang.Text), txtTenSP.Text, decimal.Parse(txtGiaSP.Text), txtDongSP.Text, txtTG.Text, txtNoiSX.Text, txtMota.Text, txtUrl.Text, txtMau.Text, int.Parse(txtSoghe.Text),
                    txtNhienlieu.Text, ref err);
                    LoadSP();
                    MessageBox.Show("Đã sửa xong!");
         
               
               
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Them = false;
            this.dtgvSanPham_CellClick(null, null);

            btnNhap.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            txtMaSP.Enabled = false;


            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            this.txtTenSP.Focus();
        }



        //Hãng
        public Admin()
        {
            InitializeComponent();
            Load_Hang();
            //LoadSP();
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

        private void Admin_Load(object sender, EventArgs e)
        {
            LoadSP();
           
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thứ tự dòng hiện hành
                int r = dtgvSanpham.CurrentCell.RowIndex;
                //Lấy Mã Laptop
                string strLaptop = dtgvSanpham.Rows[r].Cells[0].Value.ToString();
                DialogResult traloi;
                traloi = MessageBox.Show("Bạn muốn xóa?", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    dbSP.XoaSanPham(int.Parse(strLaptop),ref err);
                    LoadSP();
                    MessageBox.Show("Đã xóa xong !");
                    ;
                }
                else
                {
                    MessageBox.Show("Không xóa được!!");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không xóa được. Lỗi!");
            }
        }
    }
}
