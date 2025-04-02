using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eduflow.models
{
    public class Caretaker
    {
        public string id { get; }
        public string name { get; }
        public string registration { get; }
        public string userId { get; }

        public Caretaker(string id, string name, string registration, string userId)
        {
            this.id = id;
            this.name = name;
            this.registration = registration;
            this.userId = userId;
        }
    }
}
