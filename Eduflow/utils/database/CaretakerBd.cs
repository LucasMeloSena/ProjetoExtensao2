using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eduflow.models;
using Eduflow.utils.enums;
using MySql.Data.MySqlClient;
using ZstdSharp.Unsafe;

namespace Eduflow.utils.database
{
    class CaretakerBd
    {
        private database.Conn db;

        public Caretaker getCaretaker(string userId)
        {
            db = new database.Conn();
            using (var conn = new MySqlConnection(db.getConnectionString()))
            {
                conn.Open();
                string query = "SELECT * FROM Cuidador WHERE idUsuario = @idUsuario";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idUsuario", userId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var id = reader["id"].ToString();
                            var name = reader["nome"].ToString();
                            var registration = reader["matricula"].ToString();
                            return new Caretaker(id, name, registration, userId);
                        }
                        else
                        {
                            Console.WriteLine($"Caretaker não encontrado para userId: {userId}");
                            return null;
                        }
                    }
                }
            }
        }

        public List<Caretaker> getCaretakers()
        {
            db = new database.Conn();
            using (var conn = new MySqlConnection(db.getConnectionString()))
            {
                conn.Open();
                string query = "SELECT * FROM Cuidador";
                List<Caretaker> caretakers = new List<Caretaker>();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            var id = dataTable.Rows[i][0].ToString();
                            var name = dataTable.Rows[i][1].ToString();
                            var registration = dataTable.Rows[i][2].ToString();
                            var userId = dataTable.Rows[i][3].ToString();
                            Caretaker caretaker = new Caretaker(id, name, registration, userId);
                            caretakers.Add(caretaker);
                        }
                        return caretakers;
                    }
                    throw new Exception("Caretakers not found");
                }
            }
        }

        public void insertCaretaker(Caretaker caretaker)
        {
            db = new database.Conn();
            using (var conn = new MySqlConnection(db.getConnectionString()))
            {
                conn.Open();
                string query = "INSERT INTO Cuidador (id, nome, matricula, idUsuario) VALUES (@id, @nome, @matricula, @idUsuario)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", caretaker.id);
                    cmd.Parameters.AddWithValue("@nome", caretaker.name);
                    cmd.Parameters.AddWithValue("@matricula", caretaker.registration);
                    cmd.Parameters.AddWithValue("@idUsuario", caretaker.userId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Caretaker> getCaretakers ()
        {
            db = new database.Conn();
            using (var conn = new MySqlConnection(db.getConnectionString()))
            {
                conn.Open();
                string query = "SELECT * FROM Cuidador;";
                List<Caretaker> caretakers = new List<Caretaker>();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            var id = dataTable.Rows[i][0].ToString();
                            var name = dataTable.Rows[i][1].ToString();
                            var registration = dataTable.Rows[i][2].ToString();
                            var idUsuario = dataTable.Rows[i][3].ToString();
                            Caretaker caretaker = new Caretaker(id, name, registration, idUsuario);
                            caretakers.Add(caretaker);
                        }
                        return caretakers;
                    }
                    throw new Exception("Caretakers not found");
                }
            }
        }

        public Caretaker getCaretakerFlexible(string input)
        {
            db = new database.Conn();
            using (var conn = new MySqlConnection(db.getConnectionString()))
            {
                conn.Open();
                string query = @"
            SELECT * FROM Cuidador
            WHERE idUsuario = ?input
                OR matricula = ?input
                OR nome = ?input
                OR id = ?input
            LIMIT 1";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?input", input);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var id = reader["id"].ToString();
                            var name = reader["nome"].ToString();
                            var reg = reader["matricula"].ToString();
                            var userId = reader["idUsuario"].ToString();
                            return new Caretaker(id, name, reg, userId);
                        }
                        throw new Exception("Caretaker not found.");
                    }
                }
            }
        }

        public void updateCaretaker(Caretaker caretaker)
        {
            db = new database.Conn();
            using (var conn = new MySqlConnection(db.getConnectionString()))
            {
                conn.Open();
                string query = "UPDATE Cuidador SET nome = @nome, matricula = @matricula WHERE id = @id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", caretaker.id);
                    cmd.Parameters.AddWithValue("@nome", caretaker.name);
                    cmd.Parameters.AddWithValue("@matricula", caretaker.registration);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Caretaker getCaretakerById(string caretakerId)
        {
            db = new database.Conn();
            using (var conn = new MySqlConnection(db.getConnectionString()))
            {
                conn.Open();
                string query = "SELECT * FROM Cuidador WHERE id = @id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", caretakerId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var id = reader["id"].ToString();
                            var name = reader["nome"].ToString();
                            var registration = reader["matricula"].ToString();
                            var userId = reader["idUsuario"].ToString();
                            return new Caretaker(id, name, registration, userId);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

    }
}
