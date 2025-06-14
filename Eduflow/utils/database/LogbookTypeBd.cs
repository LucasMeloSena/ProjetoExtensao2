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
    }
}
