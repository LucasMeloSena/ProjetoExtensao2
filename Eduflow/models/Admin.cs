using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eduflow.models
{
    public class Admin
    {
        public string id { get; }
        public string name { get; }
        public string schoolName { get; }
        public string userId { get; }

        public Admin(string id, string name, string schoolName, string userId) {
            this.id = id;
            this.name = name;
            this.schoolName = schoolName;
            this.userId = userId;
        }
    }
}
