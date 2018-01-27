using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.DAL
{
    [Serializable]
    public class Laboratory
    {
        public int LabId { get; set; }
        public string LabNumber { get{ return string.Format("Lab#{0}", LabId); } }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public City city { set; get; }
        public List<Analysis> Analizes { get; set; } = new List<Analysis>();
    }
}
