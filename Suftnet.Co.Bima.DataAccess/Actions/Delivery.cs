using System;
using System.Collections.Generic;

#nullable disable

namespace Suftnet.Co.Bima.DataAccess.Actions
{
    public partial class Delivery
    {
        public Guid Id { get; set; }
        public Guid LogisticId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public Guid ProduceId { get; set; }

        public virtual Company Logistic { get; set; }
    }
}
