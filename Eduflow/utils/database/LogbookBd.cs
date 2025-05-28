using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eduflow.models;
using MySql.Data.MySqlClient;

namespace Eduflow.utils.database
{
    class LogbookBd
    {
        private database.Conn db;

        public Logbook getLogbook(string? caretakerId, string? studentId)
        {
            db = new database.Conn();
            using (var conn = new MySqlConnection(db.getConnectionString()))
            {
                conn.Open();
                string query = "SELECT * FROM DiarioDeBordo where idCuidador like '%?idCuidador%' or idAluno like '%idAluno%'";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?idCuidador", caretakerId);
                    cmd.Parameters.AddWithValue("?idAluno", studentId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var id = reader["id"].ToString();
                            var registerDate = reader["data_cadastro"].ToString();
                            var observation = reader["observacao"].ToString();
                            var caretakerId = reader["idCuidador"].ToString();
                            var studentId = reader["idAluno"].ToString();
                            return new Logbook(id, registerDate, observation, caretakerId, studentId)
                        }
                        throw new Exception("Logbook not found");
                    }
                }
            }
        }
    }
}
