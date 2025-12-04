/**************************************************************************
* Nom du fichier : Article.cs
* Auteur : Ozgun Levent
* Date de création : 13.11.2025
* Description : Classe abstraite de base pour tous les articles du restaurant.
**************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFRestaurant
{
    /// <summary>
    /// Classe abstraite représentant un article générique du restaurant.
    /// Contient les propriétés de base communes à tous les types d'articles (nourriture, boisson, dessert).
    /// </summary>
    public abstract class Article
    {
        private string _name;
        private int _price;
        private string _image;
        private string _category;

        /// /// <summary>
        /// Nom de l'article. Doit être strictement rempli.
        /// </summary>
        /// <exception cref="Exception">Lancée si le nom est null</exception>
        public string Name
        {
            get => _name;
            set
            {
                if (value == null)
                    throw new Exception("Le nom ne peut pas être nul");
                else
                    _name = value;
            }
        }

        /// <summary>
        /// Prix de l'article. Doit être strictement positif.
        /// </summary>
        /// <exception cref="Exception">Lancée si le prix est inférieur ou égal à zéro.</exception>
        public int Price
        {
            get => _price;
            set
            {
                // Vérifie que le prix est supérieur à zéro
                if (value <= 0)
                    throw new Exception("Le prix ne peut pas être négatif ou nul, veuillez entrer un prix positif.");
                else
                    _price = value;
            }
        }

        /// <summary>
        /// Chemin ou nom de l'image associée à l'article.
        /// </summary>
        /// /// <summary>
        /// Prix de l'article. Doit être strictement positif.
        /// </summary>
        /// <exception cref="Exception">Lancée si le prix est inférieur ou égal à zéro.</exception>
        public string Image
        {
            get => _image;
            set
            {
                // Vérifie que le prix est supérieur à zéro
                if (value == null)
                    throw new Exception("L'image ne peut pas être nul");
                else
                    _image = value;
            }
        }

        /// <summary>
        /// Catégorie de l'article (ex: Food, Drink, Dessert).
        /// </summary>
        public string Category { get => _category; set => _category = value; }

        /// <summary>
        /// Constructeur par défaut de la classe Article.
        /// </summary>
        public Article() : this("NULL", 1, "")
        {

        }

        /// <summary>
        /// Constructeur permettant d'initialiser un nouvel article.
        /// </summary>
        /// <param name="name">Nom de l'article.</param>
        /// <param name="price">Prix de l'article (doit être positif).</param>
        /// <param name="image">Chemin ou nom de l'image associée à l'article.</param>
        public Article(string name, int price, string image)
        {
            Name = name;
            Price = price;
            Image = image;
        }

        /// <summary>
        /// Retourne une représentation textuelle de l'article.
        /// </summary>
        /// <returns>Chaîne de caractères formatée : "Nom (Catégorie) - Prix.-".</returns>
        public override string ToString()
        {
            return $"{Name} ({Category}) - {Price}.-";
        }

        /// <summary>
        /// Compare l'article courant avec un autre objet pour déterminer s'ils sont égaux.
        /// Deux articles sont considérés égaux s'ils ont le même nom et le même prix.
        /// </summary>
        /// <param name="obj">Objet à comparer avec l'article courant.</param>
        /// <returns>
        /// <c>true</c> si l'objet passé en paramètre est un Article avec le même nom et le même prix ;
        /// sinon, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            // Vérifie si l'objet est null ou d'un type différent
            if (obj == null || GetType() != obj.GetType())
                return false;

            // Conversion de l'objet en Article
            Article other = (Article)obj;

            // Comparaison des propriétés Name et Price
            return this.Name == other.Name && this.Price == other.Price;
        }

        /// <summary>
        /// Retourne un code de hachage pour l'article courant.
        /// Le code de hachage est calculé à partir des propriétés Name et Price.
        /// </summary>
        /// <returns>Code de hachage basé sur le nom et le prix de l'article.</returns>
        public override int GetHashCode()
        {
            // Utilisation d'un tuple pour calculer le code de hachage
            return (Name, Price).GetHashCode();
        }
    }
}