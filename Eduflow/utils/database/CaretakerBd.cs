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
                string query = "INSERT INTO Cuidador (id, nome, matricula, idUsuario) VALUES  " + "(?id, ?nome, ?matricula, ?idUsuario)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?id", caretaker.id);
                    cmd.Parameters.AddWithValue("?nome", caretaker.name);
                    cmd.Parameters.AddWithValue("?matricula", caretaker.registration);
                    cmd.Parameters.AddWithValue("?idUsuario", caretaker.userId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
