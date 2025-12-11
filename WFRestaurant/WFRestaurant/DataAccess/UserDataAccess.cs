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
                string query = "SELECT * FROM tbl_user WHERE email = @Email AND passwordHash = @Password";

                var result = cnn.QueryFirstOrDefault<User>(query, new { Email = email, Password = password });

                return result; // soit un User, soit nullv b 
            }
        }

        /// <summary>
        /// Insère un nouvel utilisateur dans la base.
        /// </summary>
        public static void InsertUser(User user)
        {
            using (IDbConnection cnn = new SQLiteConnection(SqliteDataAccess.LoadConnectionString()))
            {
                string query = "INSERT INTO tbl_user (email, passwordHash) VALUES (@Email, @Password)";
                cnn.Execute(query, user);
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
