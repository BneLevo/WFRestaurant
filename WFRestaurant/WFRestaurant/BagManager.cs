using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Nom : Ozgun
// Nom : Fischer
// Prénom : Levent
// Prénom : Adrian
// Date : 04.09.2025
// Nom du projet : WFRestaurant

namespace WFRestaurant
{
    public static class BagManager
    {
        // Liste des articles ajoutés au panier
        public static List<Article> Bag = new List<Article>();

        public static void AddToBag(Article article)
        {
            Bag.Add(article);
        }

        // Affiche les articles du panier
        public static void DisplayBag(FlowLayoutPanel displayPanel)
        {
            displayPanel.Controls.Clear();
            foreach (var article in Bag)
            {
                // Création du panel pour chaque article
                Panel panel = new Panel
                {
                    Size = new Size(220, 200),
                    BackColor = Color.DarkOrange,
                    Margin = new Padding(10)
                };

                // Affichage de l'image de l'article
                PictureBox pictureBox = new PictureBox
                {
                    Size = new Size(140, 70),
                    Location = new Point((panel.Width - 140) / 2, 10),
                    SizeMode = PictureBoxSizeMode.Zoom
                };

                string categoryFolder = article.Category.ToLower();
                if (!string.IsNullOrEmpty(article.Image))
                {
                    string fullImagePath = Path.Combine(Application.StartupPath, "img", categoryFolder, article.Image);
                    pictureBox.Image = Image.FromFile(fullImagePath);
                }

                // Nom de l'article
                Label labelNomArticle = new Label
                {
                    Text = article.Name,
                    Location = new Point(10, pictureBox.Bottom + 10),
                    Size = new Size(panel.Width - 20, 25),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    ForeColor = Color.White
                };

                // Prix de l'article
                Label labelPrixArticle = new Label
                {
                    Text = article.Price + ".-",
                    Location = new Point(10, labelNomArticle.Bottom + 5),
                    Size = new Size(panel.Width - 20, 20),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Arial", 9, FontStyle.Regular),
                    ForeColor = Color.White
                };

                // Ajout des contrôles au panel
                panel.Controls.Add(pictureBox);
                panel.Controls.Add(labelNomArticle);
                panel.Controls.Add(labelPrixArticle);

                // Ajout du panel à l'affichage
                displayPanel.Controls.Add(panel);
            }
        }
    }
}