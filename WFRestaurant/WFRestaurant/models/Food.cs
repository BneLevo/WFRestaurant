/**************************************************************************
 * Nom du fichier : Food.cs
 * Auteur : Ozgun Levent
 * Date de création : 13.11.2025
 * Description : Classe représentant un article de type nourriture.
 **************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFRestaurant
{
    /// <summary>
    /// Classe représentant un article de type nourriture.
    /// Hérite de la classe Article et définit la catégorie par défaut à "Food".
    /// </summary>
    class Food : Article
    {
        /// <summary>
        /// Constructeur par défaut de la classe Food.
        /// </summary>
        public Food()
        {

        }

        /// <summary>
        /// Constructeur permettant d'initialiser un nouvel article de type nourriture.
        /// </summary>
        /// <param name="name">Nom de l'article.</param>
        /// <param name="price">Prix de l'article.</param>
        /// <param name="image">Chemin ou nom de l'image associée à l'article.</param>
        public Food(string name, int price, string image) : base(name, price, image)
        {
            Category = "Food";
        }
    }
}
