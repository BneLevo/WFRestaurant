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
        /// <summary>
        /// Initialise la base de données SQLite en créant les tables nécessaires et en insérant des données d'exemple si la table est vide.
        /// </summary>
        /// <param name="id">Identifiant de la chaîne de connexion (par défaut : "Default").</param>
        public static void InitializeDatabase(string id = "Default")
        {
            // Récupère la chaîne de connexion à la base de données
            string connectionString = LoadConnectionString(id);

            // Extrait le chemin de la base de données à partir de la chaîne de connexion
            string dbPath = GetDatabasePathFromConnectionString(connectionString);

            // Crée le fichier de la base de données s'il n'existe pas
            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
            }

            // Ouvre une connexion à la base de données
            using (var cnn = new SQLiteConnection(connectionString))
            {
                cnn.Open();

                // Crée la table "Article" si elle n'existe pas
                string createTable = @"
            CREATE TABLE IF NOT EXISTS Article (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL,
                Price INTEGER NOT NULL,
                Image TEXT,
                Category TEXT NOT NULL
            );";
                cnn.Execute(createTable);

                // Vérifie si la table est vide
                string countQuery = "SELECT COUNT(*) FROM Article";
                int count = cnn.ExecuteScalar<int>(countQuery);

                // Si la table est vide, insère des données d'exemple
                if (count == 0)
                {
                    string insert = @"
                INSERT INTO Article (Name, Price, Image, Category) VALUES
                ('Burger', 10, 'burger.png', 'Food'),
                ('Frites', 5, 'frites.png', 'Food'),
                ('Entrecôte', 25, 'entrecote.png', 'Food'),
                ('Pâte Bolognaise', 15, 'patesBolo.png', 'Food'),
                ('Eau', 1, 'eau.png', 'Drink'),
                ('Ice Tea', 2, 'iceTea.png', 'Drink'),
                ('Bierre', 3, 'beer.png', 'Drink'),
                ('Vin', 4, 'wine.png', 'Drink'),
                ('Gâteau au chocolat', 8, 'chocoCake.png', 'Dessert'),
                ('Cheese cake', 8, 'cheeseCake.png', 'Dessert'),
                ('Glaces', 5, 'iceCream.png', 'Dessert'),
                ('Salade de fruits', 5, 'fruits.png', 'Dessert'),
                ('Yogurt', 2, 'yogurt.png', 'Dessert')";

                    cnn.Execute(insert);
                    Console.WriteLine("Données d'exemple insérées avec succès.");
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

        /// <summary>
        /// Extrait le chemin de la base de données à partir de la chaîne de connexion.
        /// </summary>
        /// <param name="connectionString">Chaîne de connexion contenant le chemin de la base de données.</param>
        /// <returns>Chemin complet de la base de données.</returns>
        /// <exception cref="Exception">Lancée si le chemin de la base de données n'est pas trouvé dans la chaîne de connexion.</exception>
        private static string GetDatabasePathFromConnectionString(string connectionString)
        {
            // Divise la chaîne de connexion en parties distinctes
            var parts = connectionString.Split(';');

            // Parcourt chaque partie pour trouver celle qui contient "Data Source"
            foreach (var part in parts)
            {
                if (part.Trim().StartsWith("Data Source=", StringComparison.OrdinalIgnoreCase))
                {
                    // Extrait et retourne le chemin de la base de données
                    return part.Trim().Substring("Data Source=".Length).Trim();
                }
            }
            // Lance une exception si le chemin n'est pas trouvé
            throw new Exception("Impossible de trouver le chemin de la base de données dans la connection string !");
        }
    }
}
