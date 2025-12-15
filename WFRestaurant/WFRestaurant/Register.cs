using System;
using System.Windows.Forms;

namespace WFRestaurant
{
    public partial class Register : Form
    {
        public Register() => InitializeComponent();

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string passwordCheck = txtConfirmPassword.Text.Trim();

            try
            {
                if (UserDataAccess.EmailExists(email))
                {
                    MessageBox.Show("Cet email existe déjà !");
                    return;
                }
                else if (password != passwordCheck)
                {
                    MessageBox.Show("Les mots de passes ne correspondent pas");
                    return;
                }

                UserDataAccess.InsertUser(email, password);

                MessageBox.Show("Le compte a été créé avec succès !");

                var user = UserDataAccess.GetUser(email, password);

                Homepage homepage = new Homepage(user);
                homepage.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void linkLabelAlreadyAcc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
