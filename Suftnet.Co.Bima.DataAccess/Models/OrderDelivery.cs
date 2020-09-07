using System;
using System.Collections.Generic;

namespace Suftnet.Co.Bima.DataAccess.Models
{
    public partial class OrderDelivery
    {
        public Guid Id { get; set; }
        public Guid DriverId { get; set; }
        public Guid OrderId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        public virtual Driver Driver { get; set; }
        public virtual Order Order { get; set; }
    }
}
