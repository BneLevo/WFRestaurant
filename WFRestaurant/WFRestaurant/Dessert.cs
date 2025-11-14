/**************************************************************************
 * Nom du fichier : Dessert.cs
 * Auteur : Ozgun Levent
 * Date de création : 13.11.2025
 * Description : Classe représentant un article de type dessert.
 **************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFRestaurant
{
    /// <summary>
    /// Classe représentant un article de type dessert.
    /// Hérite de la classe Article et définit la catégorie par défaut à "Dessert".
    /// </summary>
    class Dessert : Article
    {
        /// <summary>
        /// Constructeur par défaut de la classe Dessert.
        /// </summary>
        public Dessert()
        {

        }

        /// <summary>
        /// Constructeur permettant d'initialiser un nouvel article de type dessert.
        /// </summary>
        /// <param name="name">Nom du dessert.</param>
        /// <param name="price">Prix du dessert.</param>
        /// <param name="image">Chemin ou nom de l'image associée au dessert.</param>
        public Dessert(string name, int price, string image) : base(name, price, image)
        {
            Category = "Dessert";
        }
    }
}
