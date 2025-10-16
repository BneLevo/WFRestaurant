using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* 
Nom : Ozgun
Prénom : Levent 
Nom du projet : WFRestaurant
*/

namespace WFRestaurant
{
    public class BagManager
    {
        // Liste des articles ajoutés au panier
        public static List<Article> Bag = new List<Article>();

        public static void AddToBag(Article article)
        {
            Bag.Add(article);
        }

        public static void RemoveFromBag(Article article)
        {
            Bag.Remove(article);
        }
    }
}