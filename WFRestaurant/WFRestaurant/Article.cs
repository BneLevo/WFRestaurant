using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFRestaurant
{
    abstract class Article
    {
        private int price;

        public string Name { get; set; }
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

        public Article(string name, int price, string image)
        {
            Name = name;
            Price = price;
            Image = image;
        }
    }
}
