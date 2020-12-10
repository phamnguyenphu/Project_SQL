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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            //setting color ban đầu username, password
            txt_UserName.ForeColor = Color.DimGray;
            txt_Password.ForeColor = Color.DimGray;
        }

        private void txt_UserName_Enter(object sender, EventArgs e)
        {
            if (txt_UserName.Text == "User name")
            {
                txt_UserName.Text = "";
                txt_UserName.ForeColor = Color.Black;
            }
        }

        private void txt_UserName_Leave(object sender, EventArgs e)
        {
            if (txt_UserName.Text == "")
            {
                txt_UserName.Text = "User name";
            }
            txt_UserName.ForeColor = Color.DimGray;
        }

        private void txt_Password_Enter(object sender, EventArgs e)
        {
            if (txt_Password.Text == "Password")
            {
                txt_Password.Text = "";
                txt_Password.ForeColor = Color.Black;
                txt_Password.UseSystemPasswordChar = true;
            }
        }

        private void txt_Password_Leave(object sender, EventArgs e)
        {
            if (txt_Password.Text == "")
            {
                txt_Password.UseSystemPasswordChar = false;
                txt_Password.Text = "Password";
                txt_Password.ForeColor = Color.DimGray;
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        // ----------------------------------------------------------------------------------------------------------------------
        //                                          CHỨC NĂNG ĐĂNG NHẬP
        //Load form Main_manager khi click button Login và kiểm tra điều kiện đúng hay sai tài khoản mật khẩu ở database

        private void btn_Login_Click(object sender, EventArgs e)
        {
            
        }



        


    }
}
