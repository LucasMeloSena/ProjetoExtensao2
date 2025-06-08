using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eduflow.models
{
    public class Logbook
    {
        public string id { get; }
        public DateTime registerDate { get; }
        public string observation {  get; }
        public string caretakerId { get; }
        public string caretakerName { get; }
        public string studentId { get; }

        public Logbook(string id, DateTime registerDate, string observation, string caretakerId, string carekaterName, string studentId)
        {
            this.id = id;
            this.registerDate = registerDate;
            this.observation = observation;
            this.caretakerId = caretakerId;
            this.caretakerName = carekaterName;
            this.studentId = studentId;
        }
    }
}
