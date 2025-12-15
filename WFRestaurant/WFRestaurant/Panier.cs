/**************************************************************************
* Nom du fichier : Panier.cs
* Auteur : Ozgun Levent
* Date de création : 13.11.2025
* Description : Fenêtre affichant le panier et permettant de gérer les articles ajoutés.
**************************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WFRestaurant
{
    /// <summary>
    /// Fenêtre Panier permettant d'afficher les articles ajoutés au panier,
    /// de visualiser le total et de supprimer des articles.
    /// </summary>
    public partial class Panier : Form
    {
        private User currentUser;

        public Panier(User user)
        {
            InitializeComponent();
            currentUser = user;
            // Si l'utilisateur est null, le formulaire chargera vide (géré dans Panier_Load)
        }

        private void Panier_Load(object sender, EventArgs e)
        {
            DisplayArticles.Controls.Clear();
            if (currentUser != null)
            {
                DisplayBag(DisplayArticles);
            }
            else
            {
                MessageBox.Show("Veuillez vous connecter pour voir votre panier.", "Accès Restreint", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            UpdateBagTotal();
        }

        private void UpdateBagTotal()
        {
            if (currentUser != null)
            {
                int total = PanierDataAccess.GetUserPanier(currentUser.IdUser).Sum(a => a.Price);
                lblTotal.Text = $"Total : {total}.-";
            }
            else
            {
                lblTotal.Text = "Total : 0.-";
            }
        }

        private void DisplayBag(FlowLayoutPanel displayPanel)
        {
            displayPanel.Controls.Clear();

            if (currentUser == null) return;

            var bag = PanierDataAccess.GetUserPanier(currentUser.IdUser);

            foreach (var article in bag)
            {
                Panel pnlArticle = new Panel
                {
                    Size = new Size(220, 200),
                    BackColor = Color.DarkOrange,
                    Margin = new Padding(10)
                };

                PictureBox picArticleImage = new PictureBox
                {
                    Size = new Size(140, 70),
                    Location = new Point((pnlArticle.Width - 140) / 2, 10),
                    SizeMode = PictureBoxSizeMode.Zoom
                };

                // Chargement d'image sécurisé
                string categoryFolder = article.Category?.ToLower() ?? "default";
                if (!string.IsNullOrEmpty(article.Image))
                {
                    string fullImagePath = Path.Combine(Application.StartupPath, "img", categoryFolder, article.Image);
                    if (File.Exists(fullImagePath))
                    {
                        try
                        {
                            picArticleImage.Image = Image.FromFile(fullImagePath);
                        }
                        catch
                        {
                            // Gérer l'erreur de chargement d'image
                        }
                    }
                }

                Label lblArticleName = new Label
                {
                    Text = article.Name,
                    Location = new Point(10, picArticleImage.Bottom + 10),
                    Size = new Size(pnlArticle.Width - 20, 25),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    ForeColor = Color.White
                };

                Label lblArticlePrice = new Label
                {
                    Text = $"{article.Price}.-",
                    Location = new Point(10, lblArticleName.Bottom + 5),
                    Size = new Size(pnlArticle.Width - 20, 20),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Arial", 9, FontStyle.Regular),
                    ForeColor = Color.White
                };

                Button btnRemoveFromBag = new Button
                {
                    Text = "Retirer du panier",
                    Size = new Size(120, 35),
                    Location = new Point((pnlArticle.Width - 120) / 2, lblArticlePrice.Bottom + 10),
                    BackColor = Color.White,
                    ForeColor = Color.Orange,
                    FlatStyle = FlatStyle.Flat
                };

                // Événement de suppression
                btnRemoveFromBag.Click += (s, e) =>
                {
                    PanierDataAccess.RemoveArticleFromUser(currentUser.IdUser, article.Id);
                    MessageBox.Show($"{article.Name} a été retiré du panier.");

                    // Recharger et mettre à jour l'affichage
                    DisplayBag(DisplayArticles);
                    UpdateBagTotal();
                };

                pnlArticle.Controls.Add(picArticleImage);
                pnlArticle.Controls.Add(lblArticleName);
                pnlArticle.Controls.Add(lblArticlePrice);
                pnlArticle.Controls.Add(btnRemoveFromBag);

                displayPanel.Controls.Add(pnlArticle);
            }
        }
    }
}