using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Common;
namespace NTier
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            
            User user = new User();
            UserBLL uBLL = new UserBLL();
            user.Username = txtUsername.Text;
            user.Password = txtPassword.Text;
            user.Name=txtName.Text; 
            user.Email=txtEmail.Text;
            bool res=uBLL.AddUser(user);
            if(res)
            {
                MessageBox.Show("User Registered Succesfully");
                this.Close();
            }
            else
            {
                MessageBox.Show("User Registeration Failed!!!","ERROR",MessageBoxButtons.AbortRetryIgnore);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtName.Text="";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtEmail.Text = "";
            //this.Close();
        }
    }
}
