using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eduflow.models
{
    public class Group
    {
        public string id { get; }
        public string name { get; }

        public Group(string id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
