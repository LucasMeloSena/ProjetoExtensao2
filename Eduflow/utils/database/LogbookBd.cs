using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eduflow.models;
using Eduflow.utils.enums;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;

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
                            db.tipo_observacao,
                            db.idCuidador,
                            db.idAluno,
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
                            var observationType = reader.GetString("tipo_observacao");
                            var caretakerId = reader.GetString("idCuidador");
                            var caretakerName = reader.GetString("nomeCuidador");

                            var logbook = new Logbook(id, registerDate, observation, observationType, caretakerId, caretakerName, studentId, null);
                            logBooks.Add(logbook);
                        }
                    }
                }

                return logBooks;
            }
        }

        public List<Logbook> getLastLogbooksRegistered()
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
                            db.tipo_observacao,
                            db.idCuidador,
                            db.idAluno,
                            c.nome AS nomeCuidador,
                            a.nome AS nomeAluno
                            FROM DiarioDeBordo db INNER JOIN Cuidador c ON db.idCuidador = c.id
                            INNER JOIN Aluno a ON db.idAluno = a.id
                            ORDER BY data_cadastro DESC
                            LIMIT 10;";
                List<Logbook> logBooks = new List<Logbook>();

                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var id = reader.GetString("id");
                            var registerDate = reader.GetDateTime("data_cadastro");
                            var observation = reader.GetString("observacao");
                            var observationType = reader.GetString("tipo_observacao");
                            var caretakerId = reader.GetString("idCuidador");
                            var caretakerName = reader.GetString("nomeCuidador");
                            var studentId = reader.GetString("idAluno");
                            var studentName = reader.GetString("nomeAluno");
                            var logbook = new Logbook(id, registerDate, observation, observationType, caretakerId, caretakerName, studentId, studentName);
                            logBooks.Add(logbook);
                        }
                    }
                }

                return logBooks;
            }
        }

        public Logbook getLogbookById(string id)
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
                            db.tipo_observacao,
                            db.idCuidador,
                            db.idAluno,
                            c.nome AS nomeCuidador,
                            a.nome AS nomeAluno
                            FROM DiarioDeBordo db 
                            INNER JOIN Aluno a ON db.idAluno = a.id
                            INNER JOIN Cuidador c ON db.idCuidador = c.id WHERE db.id = ?id;";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?id", id);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var registerDate = reader.GetDateTime("data_cadastro");
                            var observation = reader.GetString("observacao");
                            var observationType = reader.GetString("tipo_observacao");
                            var caretakerId = reader.GetString("idCuidador");
                            var caretakerName = reader.GetString("nomeCuidador");
                            var studentId = reader.GetString("idAluno");
                            var studentName = reader.GetString("nomeAluno");

                            var logbook = new Logbook(id, registerDate, observation, observationType, caretakerId, caretakerName, studentId, studentName);
                            return logbook;
                        }
                        throw new Exception("Logbook not found.");
                    }
                }
            }
        }

        public void insertLogbook(Logbook logbook)
        {
            db = new database.Conn();
            using (var conn = new MySqlConnection(db.getConnectionString()))
            {
                conn.Open();
                string query = "INSERT INTO DiarioDeBordo (id, data_cadastro, observacao, tipo_observacao, idCuidador, idAluno) VALUES  " + "(?id, ?data_cadastro, ?observacao, ?tipo_observacao, ?idCuidador, ?idAluno)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?id", logbook.id);
                    cmd.Parameters.AddWithValue("?data_cadastro", logbook.registerDate);
                    cmd.Parameters.AddWithValue("?observacao", logbook.observation);
                    cmd.Parameters.AddWithValue("?tipo_observacao", logbook.observationTypeId);
                    cmd.Parameters.AddWithValue("?idCuidador", logbook.caretakerId);
                    cmd.Parameters.AddWithValue("?idAluno", logbook.studentId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void deleteLogbook(string logbookId)
        {
            db = new database.Conn();
            using (var conn = new MySqlConnection(db.getConnectionString()))
            {
                conn.Open();
                string query = "DELETE FROM DiarioDeBordo WHERE id = ?id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?id", logbookId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void updateLogbook(Logbook logbook)
        {
            db = new database.Conn();
            using (var conn = new MySqlConnection(db.getConnectionString()))
            {
                conn.Open();
                string query = "UPDATE DiarioDeBordo SET data_cadastro = ?data_cadastro, observacao = ?observacao, tipo_observacao = ?tipo_observacao, idCuidador = ?idCuidador, idAluno = ?idAluno WHERE id = ?id;";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?id", logbook.id);
                    cmd.Parameters.AddWithValue("?data_cadastro", logbook.registerDate);
                    cmd.Parameters.AddWithValue("?observacao", logbook.observation);
                    cmd.Parameters.AddWithValue("?tipo_observacao", logbook.observationTypeId);
                    cmd.Parameters.AddWithValue("?idCuidador", logbook.caretakerId);
                    cmd.Parameters.AddWithValue("?idAluno", logbook.studentId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
