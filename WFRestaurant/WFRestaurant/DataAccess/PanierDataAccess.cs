/**************************************************************************
* Nom du fichier : PanierDataAccess.cs
* Auteur : Ozgun Levent
* Date de création : 15.12.2025
* Description : Gestionnaire des paniers pour chaque utilisateur.
**************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using Dapper;

namespace WFRestaurant
{
    public static class PanierDataAccess
    {
        /// <summary>
        /// Ajoute un article au panier d'un utilisateur.
        /// </summary>
        public static void AddArticleToUser(int userId, int articleId)
        {
            using (IDbConnection cnn = new SQLiteConnection(SqliteDataAccess.LoadConnectionString()))
            {
                string query = "INSERT INTO tbl_bag (user_id, id_article) VALUES (@UserId, @ArticleId)";
                cnn.Execute(query, new { UserId = userId, ArticleId = articleId });
            }
        }

        /// <summary>
        /// Supprime un article du panier d'un utilisateur. (Supprime une seule occurrence)
        /// </summary>
        public static void RemoveArticleFromUser(int userId, int articleId)
        {
            using (IDbConnection cnn = new SQLiteConnection(SqliteDataAccess.LoadConnectionString()))
            {
                string query = "DELETE FROM tbl_bag WHERE user_id = @UserId AND id_article = @ArticleId LIMIT 1";
                cnn.Execute(query, new { UserId = userId, ArticleId = articleId });
            }
        }

        /// <summary>
        /// Récupère tous les articles du panier d'un utilisateur.
        /// </summary>
        public static List<Article> GetUserPanier(int userId)
        {
            using (IDbConnection cnn = new SQLiteConnection(SqliteDataAccess.LoadConnectionString()))
            {
                string query = @"
                    SELECT a.Id, a.Name, a.Price, a.Image, a.Category
                    FROM tbl_bag p
                    INNER JOIN Article a ON p.id_article = a.Id
                    WHERE p.user_id = @UserId";

                var rows = cnn.Query<dynamic>(query, new { UserId = userId });
                List<Article> articles = new List<Article>();

                foreach (var row in rows)
                {
                    Article article = null;
                    // Assurer les conversions de type sécurisées
                    int id = (int)(long)row.id;
                    string name = row.Name;
                    int price = (int)row.Price;
                    string image = row.Image;
                    string category = (string)row.Category;

                    switch (category)
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
                    }
                    if (article != null)
                        articles.Add(article);
                }

                return articles;
            }
        }

        /// <summary>
        /// Vide entièrement le panier d'un utilisateur.
        /// </summary>
        public static void ClearUserPanier(int userId)
        {
            using (IDbConnection cnn = new SQLiteConnection(SqliteDataAccess.LoadConnectionString()))
            {
                string query = "DELETE FROM tbl_bag WHERE user_id = @UserId";
                cnn.Execute(query, new { UserId = userId });
            }
        }
    }
}