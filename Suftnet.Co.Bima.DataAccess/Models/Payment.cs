using System;
using System.Collections.Generic;

namespace Suftnet.Co.Bima.DataAccess.Models
{
    public partial class Payment
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedDt { get; set; }
        public string CreatedBy { get; set; }
        public string Reference { get; set; }
        public byte[] TimeStamp { get; set; }
        public Guid PaymentMethodId { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDt { get; set; }

        public virtual PaymentMethod PaymentMethod { get; set; }
    }
}
