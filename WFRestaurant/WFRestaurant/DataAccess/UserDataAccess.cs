using System;
using System.Data;
using Dapper;
using System.Data.SQLite;

namespace WFRestaurant
{
    public class UserDataAccess
    {
        //private static string ConnString => SqliteDataAccess.LoadConnectionString();

        //public static User GetUserByEmailAndPassword(string email, string password)
        //{
        //    using (IDbConnection cnn = new SQLiteConnection(ConnString))
        //    {
        //        string query = "SELECT * FROM User WHERE Email=@Email AND Password=@Password";
        //        return cnn.QueryFirstOrDefault<User>(query, new { Email = email, Password = password });
        //    }
        //}

        //public static void AddUser(User user)
        //{
        //    using (IDbConnection cnn = new SQLiteConnection(ConnString))
        //    {
        //        string insert = "INSERT INTO User (Email, Password) VALUES (@Email, @Password)";
        //        cnn.Execute(insert, new { user.Email, user.Password });
        //    }
        //}
    }
}
