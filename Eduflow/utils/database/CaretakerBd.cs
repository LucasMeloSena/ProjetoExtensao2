using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eduflow.models;
using MySql.Data.MySqlClient;

namespace Eduflow.utils.database
{
    class CaretakerBd
    {
        private database.Conn db;

        public Caretaker getCaretaker(String userId)
        {
            db = new database.Conn();
            using (var conn = new MySqlConnection(db.getConnectionString()))
            {
                conn.Open();
                string query = "SELECT * FROM Cuidador where idUsuario = ?idUsuario";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?idUsuario", userId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var id = reader["id"].ToString();
                            var name = reader["nome"].ToString();
                            var registration = reader["matricula"].ToString();
                            return new Caretaker(id, name, registration, userId);
                        }
                        throw new Exception("Caretaker not found");
                    }
                }
            }
        }
    }
}
