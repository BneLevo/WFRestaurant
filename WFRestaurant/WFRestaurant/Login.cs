using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFRestaurant
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        //private void btnLogin_Click(object sender, EventArgs e)
        //{
        //    string email = txtEmail.Text.Trim();
        //    string password = txtPassword.Text.Trim();

        //    if (email == "" || password == "")
        //    {
        //        MessageBox.Show("Please fill all fields.");
        //        return;
        //    }

        //    User user = UserDataAccess.GetUserByEmailAndPassword(email, password);

        //    if (user == null)
        //    {
        //        MessageBox.Show("Wrong email or password.");
        //        return;
        //    }

        //    Program.CurrentUser = user;
        //    MessageBox.Show("Login successful!");

        //    MainPage mp = new MainPage();
        //    mp.Show();
        //    this.Hide();
        //}

    }
}
