using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFRestaurant
{
    public class Database
    {
        // Liste de tous les articles disponibles (nourriture, boisson, dessert)
        public static List<Article> articles = new List<Article>();

        // Base de données avec les articles
        public static void DatabaseArticles()
        {
            articles.Clear();

            // Nourriture
            articles.Add(new Food("Pizza", 15, "pizza.png"));
            articles.Add(new Food("Burger", 10, "burger.png"));
            articles.Add(new Food("Frites", 5, "frites.png"));
            articles.Add(new Food("Entrecôte", 25, "entrecote.png"));
            articles.Add(new Food("Pâte Bolognaise", 15, "patesBolo.png"));

            // Boisson
            articles.Add(new Drink("Eau", 1, "eau.png"));
            articles.Add(new Drink("Cola", 2, "cola.png"));
            articles.Add(new Drink("Ice Tea", 2, "iceTea.png"));
            articles.Add(new Drink("Bierre", 3, "beer.png"));
            articles.Add(new Drink("Vin", 4, "wine.png"));

            // Dessert
            articles.Add(new Dessert("Gâteau au chocolat", 8, "chocoCake.png"));
            articles.Add(new Dessert("Cheese cake", 8, "cheeseCake.png"));
            articles.Add(new Dessert("Glaces", 5, "iceCream.png"));
            articles.Add(new Dessert("Salade de fruits", 5, "fruits.png"));
            articles.Add(new Dessert("Yogurt", 2, "yogurt.png"));
        }
    }
}
