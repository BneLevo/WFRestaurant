/**************************************************************************
 * Nom du fichier : Drink.cs
 * Auteur : Ozgun Levent
 * Date de création : 13.11.2025
 * Description : Classe représentant un article de type boisson.
 **************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFRestaurant
{
    /// <summary>
    /// Classe représentant un article de type boisson.
    /// Hérite de la classe Article et définit la catégorie par défaut à "Drink".
    /// </summary>
    class Drink : Article
    {
        /// <summary>
        /// Constructeur par défaut de la classe Drink.
        /// </summary>
        public Drink()
        {

        }

        /// <summary>
        /// Constructeur permettant d'initialiser un nouvel article de type boisson.
        /// </summary>
        /// <param name="name">Nom de la boisson.</param>
        /// <param name="price">Prix de la boisson.</param>
        /// <param name="image">Chemin ou nom de l'image associée à la boisson.</param>
        public Drink(int id, string name, int price, string image) : base(id, name, price, image)
        {
            Category = "Drink";
        }
    }
}
