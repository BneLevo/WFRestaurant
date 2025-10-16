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

// Nom : Ozgun
// Prénom : Levent
// Date : 16.10.2025
// Nom du projet : WFRestaurant

namespace WFRestaurant
{    public partial class Homepage : Form
    { 
        public Homepage()
        {
            InitializeComponent();

            // Affichage les articles quand le programe est lancé
            Database.DatabaseArticles();
            foreach (var article in Database.articles)
            {
                DisplayAnArticle(article);
            }

            DisplayArticles.Controls.Clear();
            UpdateBagTotal();
        }

        // Affiche un article avec un panel
        private void DisplayAnArticle(Article article)
        {
            // Création du panel contenant l'article
            Panel panel = new Panel
            {
                Size = new Size(220, 200),
                BackColor = Color.DarkOrange,
                Margin = new Padding(10)
            };

            // Image de l'article
            PictureBox pictureBox = new PictureBox
            {
                Size = new Size(140, 70),
                Location = new Point((panel.Width - 140) / 2, 10),
                SizeMode = PictureBoxSizeMode.Zoom
            };

            // Regarde dans quel dossier se trouve l'image
            string categoryFolder = "";
            if (article is Food) categoryFolder = "food";
            else if (article is Drink) categoryFolder = "drink";
            else if (article is Dessert) categoryFolder = "dessert";

            // Chargement de l'image si elle existe
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

            // Bouton pour ajouter l'article au panier
            Button buttonAddToBag = new Button
            {
                Text = "Add To Bag",
                Size = new Size(120, 35),
                Location = new Point((panel.Width - 120) / 2, labelPrixArticle.Bottom + 10),
                BackColor = Color.White,
                ForeColor = Color.Orange,
                FlatStyle = FlatStyle.Flat
            };

            buttonAddToBag.Click += (s, e) =>
            {
                BagManager.AddToBag(article);
                // Met à jour le total du panier
                UpdateBagTotal();
                MessageBox.Show($"{article.Name} a été ajouté à votre panier.");
            };

            // Ajout des contrôles au panel
            panel.Controls.Add(pictureBox);
            panel.Controls.Add(labelNomArticle);
            panel.Controls.Add(labelPrixArticle);
            panel.Controls.Add(buttonAddToBag);

            // Ajout du panel à la liste d'affichage
            DisplayArticles.Controls.Add(panel);
            DisplayArticles.FlowDirection = FlowDirection.LeftToRight;
            DisplayArticles.WrapContents = true;
        }

        // Le prix total
        private void UpdateBagTotal()
        {
            int total = BagManager.Bag.Sum(a => a.Price);
            lblTotal.Text = $"Total : {total}.-";
        }

        // Affiche tous les articles
        private void btnTout_Click(object sender, EventArgs e)
        {
            DisplayArticles.Controls.Clear();
            foreach (var article in Database.articles)
            {
                DisplayAnArticle(article);
            }
        }

        // Affiche uniquement la nourriture
        private void btnNourriture_Click(object sender, EventArgs e)
        {
            DisplayArticles.Controls.Clear();
            var foods = Database.articles.Where(a => a.Category == "Food");
            foreach (var food in foods) DisplayAnArticle(food);
        }

        // Affiche uniquement les boissons
        private void btnBoissons_Click(object sender, EventArgs e)
        {
            DisplayArticles.Controls.Clear();
            var drinks = Database.articles.Where(a => a.Category == "Drink");
            foreach (var drink in drinks) DisplayAnArticle(drink);
        }

        // Affiche uniquement les desserts
        private void btnDessert_Click(object sender, EventArgs e)
        {
            DisplayArticles.Controls.Clear();
            var desserts = Database.articles.Where(a => a.Category == "Dessert");
            foreach (var dessert in desserts) DisplayAnArticle(dessert);
        }
    }
}