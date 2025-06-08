using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eduflow.models;
using Eduflow.utils.enums;
using MySql.Data.MySqlClient;

namespace Eduflow.utils.database
{
    class LogbookBd
    {
        private database.Conn db;

        public List<Logbook> getLogbooksByStudent(string studentId)
        {
            db = new database.Conn();
            using (var conn = new MySqlConnection(db.getConnectionString()))
            {
                conn.Open();
                string query = @"
                        SELECT
                            db.id,
                            db.data_cadastro,
                            db.observacao,
                            db.idCuidador,
                            c.nome AS nomeCuidador FROM DiarioDeBordo db INNER JOIN Cuidador c ON db.idCuidador = c.id WHERE db.idAluno = ?idAluno;";
                List<Logbook> logBooks = new List<Logbook>();

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?idAluno", studentId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var id = reader.GetString("id");
                            var registerDate = reader.GetDateTime("data_cadastro");
                            var observation = reader.GetString("observacao");
                            var caretakerId = reader.GetString("idCuidador");
                            var caretakerName = reader.GetString("nomeCuidador");

                            var logbook = new Logbook(id, registerDate, observation, caretakerId, caretakerName, studentId);
                            logBooks.Add(logbook);
                        }
                    }
                }

                return logBooks;
            }
        }

    }
}
