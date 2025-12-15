using System;
using System.Data;
using Dapper;
using System.Data.SQLite;

namespace WFRestaurant
{
    public static class UserDataAccess
    {

        /// <summary>
        /// Vérifie un utilisateur via email + mot de passe.
        /// </summary>
        public static User GetUser(string email, string password)
        {
            using (IDbConnection cnn = new SQLiteConnection(SqliteDataAccess.LoadConnectionString()))
            {
                string query = "SELECT * FROM tbl_user WHERE email = @Email";

                var user = cnn.QueryFirstOrDefault<User>(query, new { Email = email });

                if (user == null)
                    return null;

                bool isValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);

                if (!isValid)
                    return null;

                return user;
            }
        }


        /// <summary>
        /// Insère un nouvel utilisateur dans la base.
        /// </summary>
        public static void InsertUser(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                throw new Exception("Email ou mot de passe vide !");

            if (password.Length < 6)
                throw new Exception("Le mot de passe doit contenir au moins 6 caractères.");

            string hash = BCrypt.Net.BCrypt.HashPassword(password);

            using (IDbConnection cnn = new SQLiteConnection(SqliteDataAccess.LoadConnectionString()))
            {
                string query = "INSERT INTO tbl_user (email, passwordHash) VALUES (@Email, @PasswordHash)";
                cnn.Execute(query, new { Email = email, PasswordHash = hash });
            }
        }


        /// <summary>
        /// Récupère un utilisateur via son ID.
        /// </summary>
        public static User GetUserById(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(SqliteDataAccess.LoadConnectionString()))
            {
                string query = "SELECT * FROM tbl_user WHERE IdUser = @Id";
                return cnn.QueryFirstOrDefault<User>(query, new { Id = id });
            }
        }

        /// <summary>
        /// Vérifie si un email existe déjà.
        /// </summary>
        public static bool EmailExists(string email)
        {
            using (IDbConnection cnn = new SQLiteConnection(SqliteDataAccess.LoadConnectionString()))
            {
                string query = "SELECT COUNT(1) FROM tbl_user WHERE email = @Email";
                int count = cnn.ExecuteScalar<int>(query, new { Email = email });

                return count > 0;
            }
        }
    }
}
