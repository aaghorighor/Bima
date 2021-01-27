using System;
using System.Collections.Generic;

#nullable disable

namespace Suftnet.Co.Bima.DataAccess.Actions
{
    public partial class ProduceBuyer
    {
        public Guid Id { get; set; }
        public Guid BuyerId { get; set; }
        public Guid ProduceId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        public virtual Buyer Buyer { get; set; }
        public virtual Produce Produce { get; set; }
    }
}
