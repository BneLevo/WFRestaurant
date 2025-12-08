using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using Dapper;

namespace WFRestaurant.models
{
    class ArticleDataAccess
    {

        /// <summary>
        /// Charge et retourne la liste de tous les articles présents dans la base de données.
        /// </summary>
        /// <returns>Liste d'objets Article (Food, Drink, Dessert).</returns>
        public static List<Article> LoadArticles()
        {
            // Utilisation d'un bloc using pour garantir la fermeture automatique de la connexion
            using (IDbConnection cnn = new SQLiteConnection(SqliteDataAccess.LoadConnectionString()))
            {
                cnn.Open();
                // Exécution d'une requête pour récupérer tous les articles
                var rows = cnn.Query<dynamic>("SELECT * FROM Article");
                List<Article> articles = new List<Article>();

                foreach (var row in rows)
                {
                    // Récupération des propriétés de chaque article
                    string name = row.Name;
                    int price = (int)row.Price;
                    string image = row.Image;
                    string type = row.Category;

                    Article article = null;

                    // Instanciation de l'objet Article selon son type
                    switch (type)
                    {
                        case "Food":
                            article = new Food(name, price, image);
                            break;
                        case "Drink":
                            article = new Drink(name, price, image);
                            break;
                        case "Dessert":
                            article = new Dessert(name, price, image);
                            break;
                    }

                    // Ajout de l'article à la liste si l'instanciation a réussi
                    if (article != null)
                        articles.Add(article);
                }

                return articles;
            }
        }
    }
}
