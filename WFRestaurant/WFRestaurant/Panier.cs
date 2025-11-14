/**************************************************************************
 * Nom du fichier : Panier.cs
 * Auteur : Ozgun Levent
 * Date de création : 13.11.2025
 * Description : Fenêtre affichant le panier et permettant de gérer les articles ajoutés.
 **************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFRestaurant
{
    /// <summary>
    /// Fenêtre Panier permettant d'afficher les articles ajoutés au panier,
    /// de visualiser le total et de supprimer des articles.
    /// </summary>
    public partial class Panier : Form
    {
        public Panier()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Événement déclenché au chargement de la fenêtre.
        /// Affiche les articles du panier et met à jour le total.
        /// </summary>
        private void Panier_Load(object sender, EventArgs e)
        {
            DisplayArticles.Controls.Clear();
            // Affiche les articles du panier
            DisplayBag(DisplayArticles);
            // Met à jour le total du panier
            UpdateBagTotal();
        }

        /// <summary>
        /// Met à jour le label affichant le total du panier.
        /// </summary>
        private void UpdateBagTotal()
        {
            int total = BagManager.Bag.Sum(a => a.Price);
            lblTotal.Text = $"Total : {total}.-";
        }

        /// <summary>
        /// Affiche dynamiquement tous les articles présents dans le panier (BagManager.Bag)
        /// sous forme de panneaux contenant une image, un nom, un prix et un bouton de suppression.
        /// </summary>
        /// <param name="displayPanel">
        /// Le conteneur (FlowLayoutPanel) dans lequel les articles du panier seront affichés.
        /// </param>
        private void DisplayBag(FlowLayoutPanel displayPanel)
        {
            displayPanel.Controls.Clear();

            foreach (var article in BagManager.Bag)
            {
                // Création du panel pour chaque article
                Panel pnlArticle = new Panel
                {
                    Size = new Size(220, 200),
                    BackColor = Color.DarkOrange,
                    Margin = new Padding(10)
                };

                // Affichage de l'image de l'article
                PictureBox picArticleImage = new PictureBox
                {
                    Size = new Size(140, 70),
                    Location = new Point((pnlArticle.Width - 140) / 2, 10),
                    SizeMode = PictureBoxSizeMode.Zoom
                };

                string categoryFolder = article.Category.ToLower();
                if (!string.IsNullOrEmpty(article.Image))
                {
                    string fullImagePath = Path.Combine(Application.StartupPath, "img", categoryFolder, article.Image);
                    picArticleImage.Image = Image.FromFile(fullImagePath);
                }

                // Nom de l'article
                Label lblArticleName = new Label
                {
                    Text = article.Name,
                    Location = new Point(10, picArticleImage.Bottom + 10),
                    Size = new Size(pnlArticle.Width - 20, 25),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    ForeColor = Color.White
                };

                // Prix de l'article
                Label lblArticlePrice = new Label
                {
                    Text = $"{article.Price}.-",
                    Location = new Point(10, lblArticleName.Bottom + 5),
                    Size = new Size(pnlArticle.Width - 20, 20),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Arial", 9, FontStyle.Regular),
                    ForeColor = Color.White
                };

                // Bouton pour supprimer l'article du panier
                Button btnRemoveFromBag = new Button
                {
                    Text = "Retirer du panier",
                    Size = new Size(120, 35),
                    Location = new Point((pnlArticle.Width - 120) / 2, lblArticlePrice.Bottom + 10),
                    BackColor = Color.White,
                    ForeColor = Color.Orange,
                    FlatStyle = FlatStyle.Flat
                };

                btnRemoveFromBag.Click += (s, e) =>
                {
                    BagManager.RemoveFromBag(article);
                    MessageBox.Show($"{article.Name} a été retiré du panier.");
                    // Rafraîchir l'affichage
                    DisplayBag(DisplayArticles);
                    UpdateBagTotal();
                };

                // Ajouter des contrôles au panel
                pnlArticle.Controls.Add(picArticleImage);
                pnlArticle.Controls.Add(lblArticleName);
                pnlArticle.Controls.Add(lblArticlePrice);
                pnlArticle.Controls.Add(btnRemoveFromBag);

                // Ajouter le panel au conteneur principal
                displayPanel.Controls.Add(pnlArticle);
            }
        }
    }
}
