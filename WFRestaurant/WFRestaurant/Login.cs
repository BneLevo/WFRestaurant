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

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            var user = UserDataAccess.GetUser(txtEmail.Text, txtPassword.Text);

            if (user == null)
            {
                MessageBox.Show("Email ou mot de passe incorrect !");
            }
            else
            {
                MessageBox.Show("Connexion réussie !");

                Homepage homepage = new Homepage();
                homepage.Show();
                this.Hide();
            }
        }

        private void linkLabelNoAcc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }
    }
}
