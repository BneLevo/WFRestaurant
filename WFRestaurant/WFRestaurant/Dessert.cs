using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFRestaurant
{
    class Dessert : Food
    {
        public Dessert(string name, int price, string image) : base(name, price, image)
        {
            Category = "Dessert";
        }
    }
}
