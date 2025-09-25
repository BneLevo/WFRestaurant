using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Nom : Ozgun
// Nom : Fischer
// Prénom : Levent
// Prénom : Adrian
// Date : 04.09.2025
// Nom du projet : WFRestaurant

namespace WFRestaurant
{
    // Classe Article qui va recevoir tout les articles
    public abstract class Article
    {
        private int price;
        public string Name { get; set; }

        // On vérifie que le prix est plus grand que 0
        public int Price
        {
            get => price;
            set
            {
                if (value <= 0)
                    throw new Exception("negative price please enter positive price");
                else
                    price = value;
            }
        }

        public string Image { get; set; }

        public string Category { get; set; }

        // Constructeur pour créer un article
        public Article(string name, int price, string image)
        {
            Name = name;
            Price = price;
            Image = image;
        }
    }
}