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
// Nom : Fischer
// Prénom : Levent
// Prénom : Adrian
// Date : 04.09.2025
// Nom du projet : WFRestaurant

namespace WFRestaurant
{    public partial class Form1 : Form
    {
        // Liste de tous les articles disponibles (nourriture, boisson, dessert)
        List<Article> articles = new List<Article>();

        public Form1()
        {
            InitializeComponent();
            Database();
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
                MessageBox.Show($"{article.Name} has been added to your bag.");
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

        // Affiche uniquement la nourriture
        private void btnNourriture_Click(object sender, EventArgs e)
        {
            DisplayArticles.Controls.Clear();
            var foods = articles.Where(a => a.Category == "Food");
            foreach (var food in foods) DisplayAnArticle(food);
        }

        // Affiche uniquement les boissons
        private void btnBoissons_Click(object sender, EventArgs e)
        {
            DisplayArticles.Controls.Clear();
            var drinks = articles.Where(a => a.Category == "Drink");
            foreach (var drink in drinks) DisplayAnArticle(drink);
        }

        // Affiche uniquement les desserts
        private void btnDessert_Click(object sender, EventArgs e)
        {
            DisplayArticles.Controls.Clear();
            var desserts = articles.Where(a => a.Category == "Dessert");
            foreach (var dessert in desserts) DisplayAnArticle(dessert);
        }

        // Base de données avec les articles
        private void Database()
        {
            articles.Clear();
            DisplayArticles.Controls.Clear();

            // Nourriture
            articles.Add(new Food("Pizza", 15, "pizza.png"));
            articles.Add(new Food("Burger", 10, "burger.png"));
            articles.Add(new Food("Frites", 5, "frites.png"));
            articles.Add(new Food("Entrecôte", 25, "entrecote.png"));
            articles.Add(new Food("Pâte Bolognaise", 15, "patesBolo.png"));

            // Boisson
            articles.Add(new Drink("Eau", 1, "eau.png"));
            articles.Add(new Drink("Cola", 2, "cola.png"));
            articles.Add(new Drink("Ice Tea", 2, "iceTea.png"));
            articles.Add(new Drink("Bierre", 3, "beer.png"));
            articles.Add(new Drink("Vin", 4, "wine.png"));

            // Dessert
            articles.Add(new Dessert("Gâteau au chocolat", 8, "chocoCake.png"));
            articles.Add(new Dessert("Cheese cake", 8, "cheeseCake.png"));
            articles.Add(new Dessert("Glaces", 5, "iceCream.png"));
            articles.Add(new Dessert("Salade de fruits", 5, "fruits.png"));
            articles.Add(new Dessert("Yogurt", 2, "yogurt.png"));

            foreach (var article in articles)
            {
                DisplayAnArticle(article);
            }
        }

        // Affiche le contenu du panier
        private void btnPanier_Click(object sender, EventArgs e)
        {
            DisplayArticles.Controls.Clear();
            // Affiche les articles du panier
            BagManager.DisplayBag(DisplayArticles);
            UpdateBagTotal();
        }

        // Affiche tous les articles
        private void btnTout_Click(object sender, EventArgs e)
        {
            DisplayArticles.Controls.Clear();
            foreach (var article in articles)
            {
                DisplayAnArticle(article);
            }
        }

        // Met à jour le label du total du panier
        private void UpdateBagTotal()
        {
            int total = BagManager.Bag.Sum(a => a.Price);
            lblTotal.Text = $"Total : {total}.-";
        }
    }
}