using System;
using System.Collections.Generic;

namespace Suftnet.Co.Bima.DataAccess.Models
{
    public partial class PaymentMethod
    {
        public PaymentMethod()
        {
            Payment = new HashSet<Payment>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDt { get; set; }
        public string CreatedBy { get; set; }
        public int IndexNo { get; set; }
        public byte[] TimeStamp { get; set; }
        public Guid Id { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Payment> Payment { get; set; }
    }
}
