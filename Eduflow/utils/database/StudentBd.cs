using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eduflow.models;
using MySql.Data.MySqlClient;

namespace Eduflow.utils.database
{
    class StudentBd
    {
        private database.Conn db;

        public Student getStudent(String id)
        {
            db = new database.Conn();
            using (var conn = new MySqlConnection(db.getConnectionString()))
            {
                conn.Open();
                string query = "SELECT * FROM Aluno where id = ?id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var id = reader["id"].ToString();
                            var name = reader["nome"].ToString();
                            var registration = reader["matricula"].ToString();
                            var age = reader["idade"].ToString();
                            var genre = reader["sexo"].ToString();
                            var disabilities = reader["deficiencia"].ToString();
                            var restrictions = reader["restricoes"].ToString();
                            var bornDate = reader["data_nascimento"].ToString();
                            var registrationDate = reader["data_matricula"].ToString();
                            var classId = reader["idTurma"].ToString();

                            return new Student(id, name, age, genre, disabilities, restrictions, registration, bornDate, registrationDate, classId);
                        }
                        throw new Exception("Student not found");
                    }
                }
            }
        }
    }
}
