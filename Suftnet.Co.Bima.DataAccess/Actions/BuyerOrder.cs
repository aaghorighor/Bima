using System;
using System.Collections.Generic;

#nullable disable

namespace Suftnet.Co.Bima.DataAccess.Actions
{
    public partial class BuyerOrder
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid SellerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        public virtual Order Order { get; set; }
        public virtual Seller Seller { get; set; }
    }
}
