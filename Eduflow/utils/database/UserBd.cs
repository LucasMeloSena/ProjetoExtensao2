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

        public User getUser(String email)
        {
            db = new database.Conn();
            using (var conn = new MySqlConnection(db.getConnectionString()))
            {
                conn.Open();
                string query = "SELECT * FROM Usuario where email = ?email";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?email", email);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string userId = reader["id"].ToString();
                            string type = reader["tipo"].ToString();
                            string password = reader["senha"].ToString();
                            UserType userType = (UserType)Enum.Parse(typeof(UserType), type.ToUpper());

                            return new User(userId, email, password, userType);
                        }
                        return null;
                    }
                }
            }
        }

        public void insertUser(User user)
        {
            db = new database.Conn();
            using (var conn = new MySqlConnection(db.getConnectionString()))
            {
                conn.Open();
                string query = "INSERT INTO Usuario (id, email, senha , tipo) VALUES (?id, ?email, ?senha, ?tipo)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?id", user.id);
                    cmd.Parameters.AddWithValue("?email", user.email);
                    cmd.Parameters.AddWithValue("?senha", user.password);
                    cmd.Parameters.AddWithValue("?tipo", user.type.ToString());
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void insertIntoLogs(LoginLog loginLog)
        {
            db = new database.Conn();
            using (var conn = new MySqlConnection(db.getConnectionString()))
            {
                conn.Open();
                string query = "INSERT INTO LoginLogs (id, data_login, idUsuario) VALUES  " +
                    "(?id, ?data_login, ?idUsuario);";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?id", loginLog.id);
                    cmd.Parameters.AddWithValue("?data_login", loginLog.loginDate);
                    cmd.Parameters.AddWithValue("?idUsuario", loginLog.idUser);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
