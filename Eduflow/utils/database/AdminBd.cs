using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eduflow.models;
using MySql.Data.MySqlClient;

namespace Eduflow.utils.database
{
    class AdminBd
    {
        private database.Conn db;

        public Admin getAdmin(String userId)
        {
            db = new database.Conn();
            using (var conn = new MySqlConnection(db.getConnectionString()))
            {
                conn.Open();
                string query = "SELECT * FROM Admin where idUsuario = ?idUsuario";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?idUsuario", userId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var id = reader["id"].ToString();
                            var name = reader["nome"].ToString();
                            var schoolName = reader["nome_escola"].ToString();
                            return new Admin(id, name, schoolName, userId);
                        }
                        throw new Exception("Admin not found");
                    }
                }
            }
        }

        public void insertAdmin(models.Admin admin)
        {
            db = new database.Conn();
            using (var conn = new MySqlConnection(db.getConnectionString()))
            {
                conn.Open();
                string query = "INSERT INTO Admin (id, nome, nome_escola, idUsuario) VALUES (@id, @nome, @nome_escola, @idUsuario)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", admin.id);
                    cmd.Parameters.AddWithValue("@nome", admin.name);
                    cmd.Parameters.AddWithValue("@nome_escola", admin.schoolName);
                    cmd.Parameters.AddWithValue("@idUsuario", admin.userId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
