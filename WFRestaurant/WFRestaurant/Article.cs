using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFRestaurant
{
    // Classe Article qui va recevoir tout les articles
    public abstract class Article
    {
        private string _name;
        private int _price;
        private string _image;
        private string _category;


        public string Name { get => _name; set => _name = value; }

        public int Price
        {
            get => _price;
            set
            {
                // On vérifie que le prix est plus grand que 0
                if (value <= 0)
                    throw new Exception("Negative price please enter positive price");
                else
                    _price = value;
            }
        }

        public string Image { get => _image; set => _image = value; }
        public string Category { get => _category; set => _category = value; }


        // Constructeur pour créer un article
        public Article(string name, int price, string image)
        {
            Name = name;
            Price = price;
            Image = image;
        }
    }
}