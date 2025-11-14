/**************************************************************************
 * Nom du fichier : BagManager.cs
 * Auteur : Ozgun Levent
 * Date de création : 13.11.2025
 * Description : Gestionnaire du panier d'achat pour l'application.
 **************************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WFRestaurant
{
    /// <summary>
    /// Gestionnaire du panier d'achat pour l'application WFRestaurant.
    /// Permet d'ajouter et de supprimer des articles du panier.
    /// </summary>
    public class BagManager
    {
        /// <summary>
        /// Liste statique des articles actuellement présents dans le panier.
        /// </summary>
        private static List<Article> _bag = new List<Article>();

        public static List<Article> Bag { get => _bag; set => _bag = value; }

        /// <summary>
        /// Ajoute un article au panier.
        /// </summary>
        /// <param name="article">Article à ajouter au panier.</param>
        public static void AddToBag(Article article) 
        {
            Bag.Add(article);
        }

        /// <summary>
        /// Supprime un article du panier.
        /// </summary>
        /// <param name="article">Article à supprimer du panier.</param>
        public static void RemoveFromBag(Article article)
        {
            Bag.Remove(article);
        }
    }
}