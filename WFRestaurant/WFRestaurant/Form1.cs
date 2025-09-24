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
    public partial class Form1 : Form
    {

        List<Article> articles = new List<Article>();

        public Form1()
        {
            InitializeComponent();
            Database();
        }

        // Créer chaque article avec les panels
        private void DisplayAnArticle(Article article)
        {
            Panel panel = new Panel
            {
                Size = new Size(220, 200),
                BackColor = Color.DarkOrange,
                Margin = new Padding(10)
            };

            PictureBox pictureBox = new PictureBox
            {
                Size = new Size(140, 70),
                Location = new Point((panel.Width - 140) / 2, 10),
                SizeMode = PictureBoxSizeMode.Zoom
            };
            // Pour l'image
            string categoryFolder = "";
            if (article is Food) categoryFolder = "food";
            else if (article is Drink) categoryFolder = "drink";
            else if (article is Dessert) categoryFolder = "dessert";

            if (!string.IsNullOrEmpty(article.Image))
            {
                string fullImagePath = Path.Combine(Application.StartupPath, "img", categoryFolder, article.Image);
                pictureBox.Image = Image.FromFile(fullImagePath);
            }


            Label labelNomArticle = new Label
            {
                Text = article.Name,
                Location = new Point(10, pictureBox.Bottom + 10),
                Size = new Size(panel.Width - 20, 25),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White
            };

            Label labelPrixArticle = new Label
            {
                Text = article.Price + ".-",
                Location = new Point(10, labelNomArticle.Bottom + 5),
                Size = new Size(panel.Width - 20, 20),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 9, FontStyle.Regular),
                ForeColor = Color.White
            };

            Button buttonAddToBag = new Button
            {
                Text = "Add To Bag",
                Size = new Size(120, 35),
                Location = new Point((panel.Width - 120) / 2, labelPrixArticle.Bottom + 10),
                BackColor = Color.White,
                ForeColor = Color.Orange,
                FlatStyle = FlatStyle.Flat
            };

            panel.Controls.Add(pictureBox);
            panel.Controls.Add(labelNomArticle);
            panel.Controls.Add(labelPrixArticle);
            panel.Controls.Add(buttonAddToBag);

            DisplayArticles.Controls.Add(panel);
            DisplayArticles.FlowDirection = FlowDirection.LeftToRight;
            DisplayArticles.WrapContents = true;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            DisplayArticles.Controls.Clear();

            var foods = articles.Where(a => a.Category == "Food");
            foreach (var food in foods) DisplayAnArticle(food);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DisplayArticles.Controls.Clear();

            var drinks = articles.Where(a => a.Category == "Drink");
            foreach (var drink in drinks) DisplayAnArticle(drink);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DisplayArticles.Controls.Clear();

            var desserts = articles.Where(a => a.Category == "Dessert");
            foreach (var dessert in desserts) DisplayAnArticle(dessert);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DisplayArticles.Controls.Clear();

            Database();
        }

        private void Database()
        {
            articles.Clear();
            DisplayArticles.Controls.Clear();

            articles.Add(new Food("Pizza", 15, "pizza.png"));
            articles.Add(new Food("Burger", 10, ""));
            articles.Add(new Food("French Fries", 5, ""));
            articles.Add(new Food("Entrecote", 25, ""));
            articles.Add(new Food("Fondue", 15, ""));

            articles.Add(new Drink("Cola", 2, ""));


            foreach (var article in articles)
            {
                DisplayAnArticle(article);
            }
        }
    }
}
