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
    public partial class Panier : Form
    {
        public Panier()
        {
            InitializeComponent();
        }

        private void Panier_Load(object sender, EventArgs e)
        {
            DisplayArticles.Controls.Clear();
            // Affiche les articles du panier
            DisplayBag(DisplayArticles);
            UpdateBagTotal();
        }

        // Mets à jour le label du total du panier
        private void UpdateBagTotal()
        {
            int total = BagManager.Bag.Sum(a => a.Price);
            lblTotal.Text = $"Total : {total}.-";
        }


        // Affiche les articles du panier
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
                    Text = "Remove from bag",
                    Size = new Size(120, 35),
                    Location = new Point((pnlArticle.Width - 120) / 2, lblArticlePrice.Bottom + 10),
                    BackColor = Color.White,
                    ForeColor = Color.Orange,
                    FlatStyle = FlatStyle.Flat
                };
                btnRemoveFromBag.Click += (s, e) =>
                {
                    BagManager.RemoveFromBag(article);
                    MessageBox.Show($"{article.Name} has been removed from your bag.");
                    // Rafraîchir l'affichage au lieu de recréer le formulaire
                    DisplayBag(DisplayArticles);
                    UpdateBagTotal();
                };

                // Ajouter des contrôles au panel
                pnlArticle.Controls.Add(picArticleImage);
                pnlArticle.Controls.Add(lblArticleName);
                pnlArticle.Controls.Add(lblArticlePrice);
                pnlArticle.Controls.Add(btnRemoveFromBag);

                // Ajouter du panel à l'affichage
                displayPanel.Controls.Add(pnlArticle);
            }
        }

    }
}
