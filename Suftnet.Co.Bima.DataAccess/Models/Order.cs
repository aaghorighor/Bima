using System;
using System.Collections.Generic;

namespace Suftnet.Co.Bima.DataAccess.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDelivery = new HashSet<OrderDelivery>();
            OrderDetail = new HashSet<OrderDetail>();
        }

        public Guid Id { get; set; }
        public DateTime CreatedDt { get; set; }
        public string CreatedBy { get; set; }
        public decimal? Total { get; set; }
        public decimal? TotalTax { get; set; }
        public decimal? TotalDiscount { get; set; }
        public decimal? GrandTotal { get; set; }
        public decimal? Payment { get; set; }
        public string Time { get; set; }
        public decimal? Balance { get; set; }
        public Guid StatusId { get; set; }
        public Guid OrderTypeId { get; set; }
        public DateTime? UpdateDt { get; set; }
        public string UpdateBy { get; set; }
        public string Note { get; set; }
        public Guid PickUpAddresId { get; set; }
        public Guid DeliveryAddressId { get; set; }
        public Guid CustomerId { get; set; }

        public virtual ICollection<OrderDelivery> OrderDelivery { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
