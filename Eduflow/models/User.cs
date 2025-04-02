using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eduflow.models
{
    public class User
    {
        public string id { get; }
        public string email { get; }
        public string password { get; }

        public User(string id, string email, string password)
        {
            this.id = id;
            this.email = email;
            this.password = password;
        }
    }
}
