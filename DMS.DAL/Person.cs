using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.DAL
{
    public enum Gender { male, female, none }
    [Serializable]
    public abstract class Person
    {
        public Person() : this(0, "", Gender.none)
        {

        }
        public Person(int ID, string Name, Gender gender)
        {
            this.ID = ID;
            this.Name = Name;
            this.gender = gender;
        }
        public int ID { set; get; }
        public string Name { get; set; }
        public Gender gender { set; get; }
        public DateTime BirthDay { get; set; }
        public int Age { get { return (DateTime.Now.Year - BirthDay.Year); } }
    }
}
