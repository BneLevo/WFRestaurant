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

        private void DisplayAnArticle(Article article)
        {

            Panel panel = new Panel
            {
                Size = new Size(200, 170),
                BackColor = Color.DarkOrange,
            };

            PictureBox pictureBox = new PictureBox
            {
                Size = new Size(120, 60),
                Location = new Point(40, 15),
                SizeMode = PictureBoxSizeMode.Zoom
            };

            Label labelNomArticle = new Label
            {
                Text = article.Name,
                Location = new Point(40, 100),
                Size = new Size(150, 20),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label labelPrixArticle = new Label
            {
                Text = article.Price + ".-",
                Location = new Point(50, 125),
                Size = new Size(120, 20),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Button buttonAddToBag = new Button
            {
                Text = "Add To Bag",
                Location = new Point(50, 130),
                Size = new Size(120, 30),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.White,
                ForeColor = Color.Orange
            };

            //buttonAddToBag.MouseClick += (s, e) =>
            //{
            //    BagManager.AddToBag(chaussure.Id);

            //    if (BagManager.Bag.Contains(chaussure.Id))
            //    {
            //        MessageBox.Show("Ajouté au panier");
            //    }
            //    else
            //    {
            //        MessageBox.Show("Error");
            //    }

            //};

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

            Food pizza = new Food("Pizza", 15, "");
            articles.Add(pizza);
            Food burger = new Food("Burger", 10, "");
            articles.Add(burger);
            Food frenchFries = new Food("French Fries", 5, "");
            articles.Add(frenchFries);
            Food entrecote = new Food("Entrecote", 25, "");
            articles.Add(entrecote);
            Food fondue = new Food("Fondue", 15, "");
            articles.Add(fondue);

            Drink cola = new Drink("Cola", 2, "");
            articles.Add(cola);


            foreach (var article in articles)
            {
                DisplayAnArticle(article);
            }
        }
    }
}
