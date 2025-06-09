using System;
using System.Data.SqlClient;
using Eduflow.models;
using Eduflow.utils.enums;
using MySql.Data.MySqlClient;

namespace Eduflow.utils.database
{
    public class UserBd
    {
        private database.Conn db;

        public User getUser(String email, String password)
        {
            db = new database.Conn();
            using (var conn = new MySqlConnection(db.getConnectionString()))
            {
                conn.Open();
                string query = "SELECT * FROM Usuario where email = ?email and senha = ?password";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?email", email);
                    cmd.Parameters.AddWithValue("?password", password);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string userId = reader["id"].ToString();
                            string type = reader["tipo"].ToString();
                            UserType userType = (UserType)Enum.Parse(typeof(UserType), type.ToUpper());

                            return new User(userId, email, password, userType);
                        }
                        throw new Exception("Nenhum usuario encontrado!");
                    }
                }
            }
        }

        public string insertUser(User user)
        {
            db = new database.Conn();
            using (var conn = new MySqlConnection(db.getConnectionString()))
            {
                conn.Open();
                string id = Guid.NewGuid().ToString();
                string query = "INSERT INTO Usuario (id, email, senha , tipo) VALUES (?id, ?email, ?senha, ?tipo)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?id", id);
                    cmd.Parameters.AddWithValue("?email", user.email);
                    cmd.Parameters.AddWithValue("?senha", user.password);
                    cmd.Parameters.AddWithValue("?tipo", user.type.ToString());
                    cmd.ExecuteNonQuery();
                }
                return id;
            }
        }

    }
}
