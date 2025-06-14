using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eduflow.models
{
    public class LogbookType
    {
        public string id { get; }
        public string name { get; }

        public LogbookType(string id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
