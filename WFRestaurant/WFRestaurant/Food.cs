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
    class Food : Article
    {
        public Food(string name, int price, string image) : base(name, price, image)
        {
            Category = "Food";
        }
    }
}
