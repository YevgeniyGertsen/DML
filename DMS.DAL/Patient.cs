using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.DAL
{
    
    public class Patient : Person
    {
        public Patient() : this(0, "", Gender.none){}
        public Patient(int ID, string Name, Gender gender) : base (ID, Name, gender){}
        
        private string IIN_;
        public string IIN
        {
            get { return IIN_; }
            set
            {
                if (IIN.Length != 12)
                    Console.WriteLine("Wrong IIN. Try again.");
                else
                    IIN_ = value;
            }
        }
        
        public List<Analysis> Analizes { get; set; } = new List<Analysis>();
        public string PhoneNumber { set; get; }

    }
}
