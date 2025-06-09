using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eduflow.models
{
    public class LoginLog
    {
        public string id { get; }
        public DateTime loginDate { get; }
        public string idUser { get; }

        public LoginLog(string id, DateTime loginDate, string idUser)
        {
            this.id = id;
            this.loginDate = loginDate;
            this.idUser = idUser;
        }
    }
}
