/**************************************************************************
 * Nom du fichier : Homepage.cs
 * Auteur : Ozgun Levent
 * Date de création : 13.11.2025
 * Description : Fenêtre principale affichant les articles disponibles.
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
    /// Fenêtre principale de l'application WFRestaurant.
    /// Affiche les articles disponibles et permet de les ajouter au panier.
    /// </summary>
    public partial class Homepage : Form
    {
        /// <summary>
        /// Liste des articles chargés depuis la base de données.
        /// </summary>
        private List<Article> articles = new List<Article>();

        /// <summary>
        /// Constructeur de la fenêtre Homepage.
        /// Initialise le formulaire et charge les articles depuis la base de données.
        /// </summary>
        public Homepage()
        {
            InitializeComponent();
            SqliteDataAccess.InitializeDatabase();
            // Chargement des articles depuis la base de données
            articles = SqliteDataAccess.LoadArticles();
            foreach (var article in articles)
            {
                DisplayAnArticle(article);
            }
            UpdateBagTotal();
        }

        /// <summary>
        /// Affiche un article dans un panel avec son image, son nom, son prix et un bouton "Ajouter au panier".
        /// </summary>
        /// <param name="article">L'article à afficher.</param>
        private void DisplayAnArticle(Article article)
        {
            // Création du panel pour l'article
            Panel panel = new Panel
            {
                Size = new Size(220, 200),
                BackColor = Color.DarkOrange,
                Margin = new Padding(10)
            };

            // Image de l'article
            PictureBox imgArticle = new PictureBox
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
                if (File.Exists(fullImagePath))
                    imgArticle.Image = Image.FromFile(fullImagePath);
            }

            // Nom de l'article
            Label lblNameArticle = new Label
            {
                Text = article.Name,
                Location = new Point(10, imgArticle.Bottom + 10),
                Size = new Size(panel.Width - 20, 25),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White
            };

            // Prix de l'article
            Label lblPriceArticle = new Label
            {
                Text = article.Price + ".-",
                Location = new Point(10, lblNameArticle.Bottom + 5),
                Size = new Size(panel.Width - 20, 20),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 9, FontStyle.Regular),
                ForeColor = Color.White
            };

            // Bouton pour ajouter l'article au panier
            Button btnAddToBag = new Button
            {
                Text = "Add To Bag",
                Size = new Size(120, 35),
                Location = new Point((panel.Width - 120) / 2, lblPriceArticle.Bottom + 10),
                BackColor = Color.White,
                ForeColor = Color.Orange,
                FlatStyle = FlatStyle.Flat
            };

            // Événement click du bouton pour ajouter l'article au panier
            btnAddToBag.Click += (s, e) =>
            {
                BagManager.AddToBag(article);
                UpdateBagTotal();
                MessageBox.Show($"{article.Name} a été ajouté à votre panier.");
            };

            // Ajoute des contrôles au panel
            panel.Controls.Add(imgArticle);
            panel.Controls.Add(lblNameArticle);
            panel.Controls.Add(lblPriceArticle);
            panel.Controls.Add(btnAddToBag);

            // Ajoute du panel à la liste d'affichage
            DisplayArticles.Controls.Add(panel);
            DisplayArticles.FlowDirection = FlowDirection.LeftToRight;
            DisplayArticles.WrapContents = true;
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
        /// Affiche tous les articles disponibles.
        /// </summary>
        private void btnTout_Click(object sender, EventArgs e)
        {
            DisplayArticles.Controls.Clear();
            foreach (var article in articles)
            {
                DisplayAnArticle(article);
            }
        }

        /// <summary>
        /// Affiche uniquement les articles de type nourriture.
        /// </summary>
        private void btnNourriture_Click(object sender, EventArgs e)
        {
            DisplayArticles.Controls.Clear();
            var foods = articles.Where(a => a.Category == "Food");
            foreach (var food in foods)
                DisplayAnArticle(food);
        }

        /// <summary>
        /// Affiche uniquement les articles de type boisson.
        /// </summary>
        private void btnBoissons_Click(object sender, EventArgs e)
        {
            DisplayArticles.Controls.Clear();
            var drinks = articles.Where(a => a.Category == "Drink");
            foreach (var drink in drinks)
                DisplayAnArticle(drink);
        }

        /// <summary>
        /// Affiche uniquement les articles de type dessert.
        /// </summary>
        private void btnDessert_Click(object sender, EventArgs e)
        {
            DisplayArticles.Controls.Clear();
            var desserts = articles.Where(a => a.Category == "Dessert");
            foreach (var dessert in desserts)
                DisplayAnArticle(dessert);
        }
    }
}
