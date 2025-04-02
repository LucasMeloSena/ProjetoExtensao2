using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eduflow.utils.enums;

namespace Eduflow.models
{
    public class Student
    {
        public string id { get; }
        public string name { get; }
        public int age { get; }
        public Genre genre { get; }
        public string disabilities { get; }
        public string restrictions { get; }
        public string registration { get; }
        public DateTime bornDate { get; }
        public DateTime registrationDate { get; }
        public string groupId { get; }

        public Student(string id, string name, int age, Genre genre, string disabilities, string restrictions, string registration, DateTime bornDate, DateTime registrationDate, string groupId)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.genre = genre;
            this.disabilities = disabilities;
            this.restrictions = restrictions;
            this.registration = registration;
            this.bornDate = bornDate;
            this.registrationDate = registrationDate;
            this.groupId = groupId;
        }
    }
}
