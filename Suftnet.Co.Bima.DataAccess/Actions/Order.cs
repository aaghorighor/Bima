using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Suftnet.Co.Bima.DataAccess.Actions
{
    public partial class Order
    {
        public Guid Id { get; set; }
        public Guid ProduceId { get; set; }
        public Guid BuyerId { get; set; }
        public Guid PaymentStatusId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal Total { get; set; }
        public decimal Balance { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public Guid OrderStatusId { get; set; }
        [ForeignKey("PaymentStatusId")]
        public virtual PaymentStatus PaymentStatus { get; set; }
        [ForeignKey("OrderStatusId")]
        public virtual OrderStatus OrderStatus { get; set; }
        [ForeignKey("ProduceId")]
        public virtual Produce Produce { get; set; }
        [ForeignKey("BuyerId")]
        public virtual Buyer Buyer { get; set; }
    }
}
