using System;
using System.Collections.Generic;

namespace Suftnet.Co.Bima.DataAccess.Models
{
    public partial class OrderPayment
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid PaymentId { get; set; }
        public DateTime CreatedDt { get; set; }
        public string CreatedBy { get; set; }
        public byte[] TimeStamp { get; set; }
    }
}
