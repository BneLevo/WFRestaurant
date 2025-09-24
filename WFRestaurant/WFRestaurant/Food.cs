using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFRestaurant
{
    class Food : Article
    {
        public Food(string name, int price, string image) : base(name, price, image)
        {
            Category = "Food";
        }
    }
}
