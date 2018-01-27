using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.DAL
{
    public enum PaymentType { cash, card, other}
    public class BillingInfo
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public PaymentType pt { set; get; }
        public string BillingDiscription { set; get; }
    }
}
