using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eduflow.utils.database
{
    class Conn
    {
        private String connectionString;

        public String getConnectionString()
        {
            var settings = ConfigurationManager.ConnectionStrings;
            foreach (ConnectionStringSettings s in settings)
            {
                if (s.Name == "DefaultConnection")
                {
                    connectionString = s.ConnectionString;
                }
            }

            if (connectionString == null)
            {
                throw new Exception("Connection String 'DefaultConnection' not found in App.config");
            }

            return connectionString;
        }
    }
}
