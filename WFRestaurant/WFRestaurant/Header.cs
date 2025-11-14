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
        /// <summary>
        /// Constructeur par défaut du contrôle Header.
        /// Initialise les composants graphiques.
        /// </summary>
        public Header()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Événement déclenché lors du clic sur le logo.
        /// Affiche la page d'accueil et masque la fenêtre parente actuelle.
        /// </summary>
        private void picLogo_Click(object sender, EventArgs e)
        {
            Homepage homepage = new Homepage();
            homepage.Show();
            // Masque la fenêtre parente (la fenêtre actuelle)
            this.Parent.Hide();
        }

        /// <summary>
        /// Événement déclenché lors du clic sur l'icône du panier.
        /// Affiche la fenêtre du panier et masque la fenêtre parente actuelle.
        /// </summary>
        private void picPanier_Click(object sender, EventArgs e)
        {
            Panier panier = new Panier();
            panier.Show();
            // Masque la fenêtre parente (la fenêtre actuelle)
            this.Parent.Hide();
        }
    }
}
