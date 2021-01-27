using System;
using System.Collections.Generic;

#nullable disable

namespace Suftnet.Co.Bima.DataAccess.Actions
{
    public partial class Order
    {
        public Order()
        {
            BuyerOrders = new HashSet<BuyerOrder>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public byte[] TimeStamp { get; set; }
        public DateTime ClosingDate { get; set; }
        public Guid UnitId { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<BuyerOrder> BuyerOrders { get; set; }
    }
}
