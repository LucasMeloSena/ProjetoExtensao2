using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eduflow.models;
using MySql.Data.MySqlClient;

namespace Eduflow.utils.database
{
    public class LogbookTypeBd
    {
        private database.Conn db;
        public List<LogbookType> getLogbookTypes()
        {
            db = new database.Conn();
            using (var conn = new MySqlConnection(db.getConnectionString()))
            {
                conn.Open();
                string query = "SELECT * FROM TipoObservacao";
                List<LogbookType> logbookTypes = new List<LogbookType>();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            LogbookType logbookType = new LogbookType(dataTable.Rows[i][0].ToString(), dataTable.Rows[i][1].ToString());
                            logbookTypes.Add(logbookType);
                        }
                        return logbookTypes;
                    }
                    throw new Exception("Logbook types not found");

                }
            }
        }

        public LogbookType getLogbookType(string id)
        {
            db = new database.Conn();
            using (var conn = new MySqlConnection(db.getConnectionString()))
            {
                conn.Open();
                string query = "SELECT * FROM TipoObservacao where id = ?id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var name = reader["nome"].ToString();
                            return new LogbookType(id, name);
                        }
                        throw new Exception("Logbook type not found");
                    }
                }
            }
        }

        public void insertLogbookType(LogbookType logbookType)
        {
            db = new database.Conn();
            using (var conn = new MySqlConnection(db.getConnectionString()))
            {
                conn.Open();
                string query = "INSERT INTO TipoObservacao (id, nome) VALUES (@id, @nome)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", logbookType.id);
                    cmd.Parameters.AddWithValue("@nome", logbookType.name);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void updateLogbookType(LogbookType logbookType)
        {
            db = new database.Conn();
            using (var conn = new MySqlConnection(db.getConnectionString()))
            {
                conn.Open();
                string query = "UPDATE TipoObservacao SET nome = @nome WHERE id = @id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", logbookType.id);
                    cmd.Parameters.AddWithValue("@nome", logbookType.name);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
