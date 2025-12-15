/**************************************************************************
 * Nom du fichier : Header.cs
 * Auteur : Ozgun Levent
 * Date de création : 13.11.2025
 * Description : Contrôle utilisateur représentant l'en-tête de l'application.
 **************************************************************************/

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
    /// <summary>
    /// Contrôle utilisateur représentant l'en-tête de l'application.
    /// Contient les boutons de navigation vers la page d'accueil et le panier.
    /// </summary>
    public partial class Header : UserControl
    {
        public User CurrentUser { get; set; }

        public Header()
        {
            InitializeComponent();
        }

        private void picLogo_Click(object sender, EventArgs e)
        {
            Homepage homepage = new Homepage(CurrentUser);
            homepage.Show();
            this.FindForm()?.Hide();
        }

        private void picPanier_Click(object sender, EventArgs e)
        {
            if (CurrentUser == null)
            {
                MessageBox.Show(
                    "Veuillez vous connecter pour accéder au panier.",
                    "Connexion requise",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            Panier panier = new Panier(CurrentUser);
            panier.Show();
            this.FindForm()?.Hide();
        }
    }
}
