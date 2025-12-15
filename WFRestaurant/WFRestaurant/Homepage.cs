/**************************************************************************
* Nom du fichier : Homepage.cs
* Auteur : Ozgun Levent
* Date de création : 13.11.2025
* Description : Fenêtre principale affichant les articles disponibles.
**************************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WFRestaurant.models;


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

        private User currentUser;

        /// <summary>
        /// Constructeur de la fenêtre Homepage.
        /// Initialise le formulaire, charge les articles et met à jour le total du panier.
        /// </summary>
        public Homepage(User user)
        {
            InitializeComponent();
            currentUser = user;
            header1.CurrentUser = currentUser;
            // Assurez-vous que SqliteDataAccess et la base de données existent
            // SqliteDataAccess.InitializeDatabase(); 

            try
            {
                articles = ArticleDataAccess.LoadArticles();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des articles : {ex.Message}", "Erreur BDD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                articles = new List<Article>(); // Initialiser à vide en cas d'erreur
            }

            DisplayArticles.Controls.Clear();
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
            // ... (Panel, PictureBox, Label créations sont ici)

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
            string categoryFolder = article.Category?.ToLower() ?? "default";

            // Chargement de l'image si elle existe
            if (!string.IsNullOrEmpty(article.Image))
            {
                string fullImagePath = Path.Combine(Application.StartupPath, "img", categoryFolder, article.Image);
                if (File.Exists(fullImagePath))
                {
                    try
                    {
                        imgArticle.Image = Image.FromFile(fullImagePath);
                    }
                    catch
                    {
                        // Gérer l'erreur de chargement d'image
                    }
                }
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
                Text = "Ajouter au panier", // FR: "Ajouter au panier"
                Size = new Size(120, 35),
                Location = new Point((panel.Width - 120) / 2, lblPriceArticle.Bottom + 10),
                BackColor = Color.White,
                ForeColor = Color.Orange,
                FlatStyle = FlatStyle.Flat
            };

            // Événement click du bouton pour ajouter l'article au panier
            btnAddToBag.Click += (s, e) =>
            {
                if (currentUser == null)
                {
                    MessageBox.Show("Veuillez vous connecter d'abord pour ajouter un article au panier.", "Connexion Requise", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                PanierDataAccess.AddArticleToUser(currentUser.IdUser, article.Id);
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
            if (currentUser != null)
            {
                // Utilise la méthode GetUserPanier pour calculer le total
                int total = PanierDataAccess.GetUserPanier(currentUser.IdUser).Sum(a => a.Price);
                lblTotal.Text = $"Total : {total}.-";
            }
            else
            {
                lblTotal.Text = "Total : 0.-";
            }
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
            var foods = articles.Where(a => a is Food); // Utilisation de l'opérateur 'is' pour plus de robustesse
            foreach (var food in foods)
                DisplayAnArticle(food);
        }

        /// <summary>
        /// Affiche uniquement les articles de type boisson.
        /// </summary>
        private void btnBoissons_Click(object sender, EventArgs e)
        {
            DisplayArticles.Controls.Clear();
            var drinks = articles.Where(a => a is Drink);
            foreach (var drink in drinks)
                DisplayAnArticle(drink);
        }

        /// <summary>
        /// Affiche uniquement les articles de type dessert.
        /// </summary>
        private void btnDessert_Click(object sender, EventArgs e)
        {
            DisplayArticles.Controls.Clear();
            var desserts = articles.Where(a => a is Dessert);
            foreach (var dessert in desserts)
                DisplayAnArticle(dessert);
        }
    }
}