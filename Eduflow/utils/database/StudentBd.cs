using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eduflow.models;
using Eduflow.utils.enums;
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
                            var name = reader["nome"].ToString();
                            var registration = reader["matricula"].ToString();
                            var age = int.Parse(reader["idade"].ToString());
                            var genreStr = reader["sexo"].ToString();
                            Genre genre = (Genre)Enum.Parse(typeof(Genre), genreStr, true);
                            var disabilities = reader["deficiencia"].ToString();
                            var restrictions = reader["restricoes"].ToString();
                            var bornDate = DateTime.Parse(reader["data_nascimento"].ToString());
                            var registrationDate = DateTime.Parse(reader["data_matricula"].ToString());
                            var classId = reader["idTurma"].ToString();

                            return new Student(id, name, age, genre, disabilities, restrictions, registration, bornDate, registrationDate, classId);
                        }
                        throw new Exception("Student not found");
                    }
                }
            }
        }

        public void insertStudent(Student student)
        {
            db = new database.Conn();
            using (var conn = new MySqlConnection(db.getConnectionString()))
            {
                conn.Open();
                string query = "INSERT INTO Aluno (id, nome, idade, sexo, deficiencia, restricoes, matricula, data_nascimento, data_matricula, idTurma) VALUES  " +
                    "(?id, ?nome, ?idade, ?sexo, ?deficiencia, ?restricoes, ?matricula, ?data_nascimento, ?data_matricula, ?idTurma);";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?id", student.id);
                    cmd.Parameters.AddWithValue("?nome", student.name);
                    cmd.Parameters.AddWithValue("?idade", student.age);
                    cmd.Parameters.AddWithValue("?sexo", student.genre);
                    cmd.Parameters.AddWithValue("?deficiencia", student.disabilities);
                    cmd.Parameters.AddWithValue("?restricoes", student.restrictions);
                    cmd.Parameters.AddWithValue("?matricula", student.registration);
                    cmd.Parameters.AddWithValue("?data_nascimento", student.bornDate);
                    cmd.Parameters.AddWithValue("?data_matricula", student.registrationDate);
                    cmd.Parameters.AddWithValue("?idTurma", student.classId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}   