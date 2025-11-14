/**************************************************************************
 * Nom du fichier : SqliteDataAccess.cs
 * Auteur : Ozgun Levent
 * Date de création : 13.11.2025
 * Description : Classe gérant l'accès aux données SQLite pour le projet.
 **************************************************************************/

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.IO;
using Dapper;

namespace WFRestaurant
{
    /// <summary>
    /// Classe responsable de l'accès aux données stockées dans la base de données SQLite.
    /// Fournit des méthodes pour charger les articles depuis la base.
    /// </summary>
    public class SqliteDataAccess
    {
        public static void InitializeDatabase(string id = "Default")
        {
            string connectionString = LoadConnectionString(id);

            string dbPath = GetDatabasePathFromConnectionString(connectionString);

            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
                Console.WriteLine($"Database created at {dbPath}");
            }

            using (var cnn = new SQLiteConnection(connectionString))
            {
                cnn.Open();

                string createTable = @"
                    CREATE TABLE IF NOT EXISTS Article (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Price INTEGER NOT NULL,
                        Image TEXT,
                        Category TEXT NOT NULL
                    );";
                cnn.Execute(createTable);

                string countQuery = "SELECT COUNT(*) FROM Article";
                int count = cnn.ExecuteScalar<int>(countQuery);

                if (count == 0)
                {
                    string insert = @"
                        INSERT INTO Article (Name, Price, Image, Category) VALUES
                        ('Ice Cream', 5, 'iceCream.png', 'Dessert');";
                    cnn.Execute(insert);

                    Console.WriteLine("Sample data inserted.");
                }
            }
        }


        /// <summary>
        /// Charge et retourne la liste de tous les articles présents dans la base de données.
        /// </summary>
        /// <returns>Liste d'objets Article (Food, Drink, Dessert).</returns>
        public static List<Article> LoadArticles()
        {
            // Utilisation d'un bloc using pour garantir la fermeture automatique de la connexion
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
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

        /// <summary>
        /// Charge la chaîne de connexion à la base de données depuis le fichier de configuration.
        /// </summary>
        /// <param name="id">Identifiant de la chaîne de connexion (par défaut : "Default").</param>
        /// <returns>Chaîne de connexion à la base de données.</returns>
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        private static string GetDatabasePathFromConnectionString(string connectionString)
        {
            var parts = connectionString.Split(';');
            foreach (var part in parts)
            {
                if (part.Trim().StartsWith("Data Source=", StringComparison.OrdinalIgnoreCase))
                {
                    return part.Trim().Substring("Data Source=".Length).Trim();
                }
            }
            throw new Exception("Impossible de trouver le chemin de la base de données dans la connection string !");
        }
    }
} 
