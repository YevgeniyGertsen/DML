using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.DAL
{
    [Serializable]
    public class Analysis
    {
        public string Name { set; get; }
        public double Price { set; get; }
        public int Processing { set; get; }
        public int ExpDay { get; set; }

    }
}
