using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eduflow.models;
using Eduflow.utils.enums;
using MySql.Data.MySqlClient;

namespace Eduflow.utils.database
{
    class GroupBd
    {
        private database.Conn db;

        public List<Group> getGroups()
        {
            db = new database.Conn();
            using (var conn = new MySqlConnection(db.getConnectionString()))
            {
                conn.Open();
                string query = "SELECT * FROM Turma";
                List<Group> groups = new List<Group>();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            Group group = new Group(dataTable.Rows[i][0].ToString(), dataTable.Rows[i][1].ToString());
                            groups.Add(group);
                        }
                        return groups;
                    }
                    throw new Exception("Group not found");

                }
            }
        }

        public Group getGroup(string id)
        {
            db = new database.Conn();
            using (var conn = new MySqlConnection(db.getConnectionString()))
            {
                conn.Open();
                string query = "SELECT * FROM Turma where id = ?id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var name = reader["nome"].ToString();
                            return new Group(id, name);
                        }
                        throw new Exception("Group not found");
                    }
                }
            }
        }

        public void insertGroup(Group group)
        {
            db = new database.Conn();
            using (var conn = new MySqlConnection(db.getConnectionString()))
            {
                conn.Open();
                string query = "INSERT INTO Turma (id, nome) VALUES (@id, @nome)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", group.id);
                    cmd.Parameters.AddWithValue("@nome", group.name);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void updateGroup(Group group)
        {
            db = new database.Conn();
            using (var conn = new MySqlConnection(db.getConnectionString()))
            {
                conn.Open();
                string query = "UPDATE Turma SET nome = @nome WHERE id = @id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", group.id);
                    cmd.Parameters.AddWithValue("@nome", group.name);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
