using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using Dapper;

namespace WFRestaurant
{
    public class SqliteDataAccess
    {
        
        // Méthode pour charger tous les articles depuis la base de données
        public static List<Article> LoadArticles()
        {
            // Utilisation d'un bloc using pour garantir la fermeture de la connexion
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Open();
                // Exécution d'une requête pour récupérer tous les articles
                var rows = cnn.Query("SELECT * FROM Article");

                List<Article> articles = new List<Article>();
                foreach (var row in rows)
                {
                    // Récupération des propriétés de chaque article
                    string name = row.Name;
                    int price = (int)row.Price;
                    string image = row.Image;
                    string type = row.Category;

                    Article article = null;
                    // Instanciation de l'objet selon le type de l'article
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

        // Méthode privée pour charger la chaîne de connexion depuis le fichier de configuration
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
