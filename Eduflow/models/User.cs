using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eduflow.utils.enums;

namespace Eduflow.models
{
    public class User
    {
        public string id { get; }
        public string email { get; }
        public string password { get; }
        public UserType type { get; }

        public User(string id, string email, string password, UserType type)
        {
            this.id = id;
            this.email = email;
            this.password = password;
            this.type = type;
        }
    }
}
