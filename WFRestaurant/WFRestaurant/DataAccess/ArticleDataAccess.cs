using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using Dapper;
using WFRestaurant; // EKLE: Article, Food, Drink, Dessert sınıflarına erişim için

namespace WFRestaurant.models
{
    class ArticleDataAccess
    {
        /// <summary>
        /// Charge tous les articles disponibles depuis la base de données.
        /// </summary>
        public static List<Article> LoadArticles()
        {
            using (IDbConnection cnn = new SQLiteConnection(SqliteDataAccess.LoadConnectionString()))
            {
                cnn.Open();
                var rows = cnn.Query<dynamic>("SELECT * FROM Article");
                List<Article> articles = new List<Article>();

                foreach (var row in rows)
                {
                    int id = (int)(long)row.id;
                    string name = row.Name;
                    int price = Convert.ToInt32(row.Price); // Conversion sécurisée 
                    string image = row.Image;
                    string type = row.Category;


                    Article article = null;

                    switch (type)
                    {
                        case "Food":
                            article = new Food(id, name, price, image);
                            break;
                        case "Drink":
                            article = new Drink(id, name, price, image);
                            break;
                        case "Dessert":
                            article = new Dessert(id, name, price, image);
                            break;
                        default:
                            // Ignorer ou logguer les articles avec une catégorie inconnue
                            break;
                    }

                    if (article != null)
                        articles.Add(article);
                }

                return articles;
            }
        }
    }
}