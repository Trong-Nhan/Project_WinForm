using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_1
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        //Khai báo biến DataContext
        ProjectDataContext hrm = new ProjectDataContext();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (IsvalidUser(txtUser.Text, txtPassword.Text))
            {
                
                frmCustomer fc = new frmCustomer();
                fc.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //xóa trắng dữ liệu trên form
                txtUser.Text = txtPassword.Text = "";
                txtUser.Focus();
            }
        }
        private bool IsvalidUser(string userName, string password)
        {
            var q = from p in hrm.LoginUsers
                    where p.UserName == txtUser.Text
                    && p.Pass == txtPassword.Text
                    select p;
            if (q.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
