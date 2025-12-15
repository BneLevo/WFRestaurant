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
        private int _id;
        private string _name;
        private int _price;
        private string _image;
        private string _category;

        /// <summary>
        /// Identifiant unique de l'article.
        /// </summary>
        public int Id { get => _id; set => _id = value; }

        /// /// <summary>
        /// Nom de l'article. Doit être strictement rempli.
        /// </summary>
        /// <exception cref="Exception">Lancée si le nom est null</exception>
        public string Name
        {
            get => _name;
            set
            {
                if (value == null || string.IsNullOrWhiteSpace(value)) // Ajout de la vérification IsNullOrWhiteSpace
                    throw new Exception("Le nom ne peut pas être nul ou vide.");
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
        /// Chemin ou nom de l'image associée à l'article. Doit être non nul.
        /// </summary>
        /// <exception cref="Exception">Lancée si l'image est null.</exception>
        public string Image
        {
            get => _image;
            set
            {
                // Laisser l'image potentiellement nulle ou vide pour la flexibilité (si pas d'image)
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
        public Article() : this(0, "Article Inconnu", 1, "")
        {

        }

        /// <summary>
        /// Constructeur permettant d'initialiser un nouvel article.
        /// </summary>
        /// <param name="id">Identifiant de l'article.</param>
        /// <param name="name">Nom de l'article.</param>
        /// <param name="price">Prix de l'article (doit être positif).</param>
        /// <param name="image">Chemin ou nom de l'image associée à l'article.</param>
        public Article(int id, string name, int price, string image)
        {
            Id = id;
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
        /// Deux articles sont considérés égaux s'ils ont le même Id.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Article other = (Article)obj;

            // La comparaison par ID est souvent plus fiable pour l'unicité des Articles.
            return this.Id == other.Id; 
        }

        /// <summary>
        /// Retourne un code de hachage pour l'article courant basé sur l'Id.
        /// </summary>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}