using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.DAL
{
    [Serializable]
    public class LaboratoryWoker : Person
    {
        public LaboratoryWoker() : this(0, "", Gender.none){ }
        public LaboratoryWoker(int ID, string Name, Gender gender) : base (ID, Name, gender){ }
        public string LogIn { set; get; }
        public string Password { set; get; }
        public Laboratory Place { get; set; }
    }
}
