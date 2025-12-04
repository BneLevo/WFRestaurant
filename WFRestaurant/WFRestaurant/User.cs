/**************************************************************************
* Nom du fichier : User.cs
* Auteur : Ozgun Levent
* Date de création : 04.12.2025
* Description : Classe représentant un utilisateur du système.
*               Contient les informations de connexion ainsi que l'identifiant.
**************************************************************************/

using System;

namespace WFRestaurant
{
    /// <summary>
    /// Classe représentant un utilisateur du restaurant.
    /// Chaque utilisateur possède un email, un mot de passe et un identifiant.
    /// </summary>
    public class User
    {
        private int _idUser;
        private string _email;
        private string _password;

        private const int MIN_PASSWORD_LENGHT = 6;

        /// <summary>
        /// Identifiant unique de l'utilisateur.
        /// </summary>
        public int IdUser
        {
            get => _idUser;
            set => _idUser = value;
        }

        /// <summary>
        /// Adresse email de l'utilisateur.
        /// Doit être non nulle.
        /// </summary>
        /// <exception cref="Exception">Lancée si l'email est null.</exception>
        public string Email
        {
            get => _email;
            set
            {
                if (value == null)
                    throw new Exception("L'email ne peut pas être nul.");
                else
                    _email = value;
            }
        }

        /// <summary>
        /// Mot de passe de l'utilisateur.
        /// Doit être non nul.
        /// </summary>
        /// <exception cref="Exception">Lancée si le mot de passe est null.</exception>
        public string Password
        {
            get => _password;
            set
            {
                if (value == null)
                    throw new Exception("Le mot de passe ne peut pas être nul.");
                else if (value.Length < MIN_PASSWORD_LENGHT)
                    throw new Exception($"Le mot de passe doit contenir au moins {MIN_PASSWORD_LENGHT} caractères");
                else
                    _password = value;
            }
        }

        /// <summary>
        /// Constructeur par défaut.
        /// Initialise l'utilisateur avec des valeurs neutres.
        /// </summary>
        public User() : this(0, "undefined@undefined.com", "password")
        {
        }

        /// <summary>
        /// Constructeur permettant de créer un utilisateur avec email et mot de passe.
        /// </summary>
        /// <param name="email">Adresse email de l'utilisateur.</param>
        /// <param name="password">Mot de passe de l'utilisateur.</param>
        public User(string email, string password) : this(0, email, password)
        {
        }

        /// <summary>
        /// Constructeur complet avec ID.
        /// </summary>
        /// <param name="idUser">Identifiant de l'utilisateur.</param>
        /// <param name="email">Adresse email.</param>
        /// <param name="password">Mot de passe.</param>
        public User(int idUser, string email, string password)
        {
            IdUser = idUser;
            Email = email;
            Password = password;
        }

        /// <summary>
        /// Représentation textuelle d'un utilisateur.
        /// Format : "email (ID : x)".
        /// </summary>
        public override string ToString()
        {
            return $"{Email} (ID : {IdUser})";
        }
    }
}
