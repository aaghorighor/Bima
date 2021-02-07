using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Suftnet.Co.Bima.DataAccess.Actions
{
    [Table("Produce")]
    public partial class Produce
    {      
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }
        public DateTime AvailableDate { get; set; }
        public Guid UnitId { get; set; }
        public bool Active { get; set; }      
        public virtual Unit Unit { get; set; }      
        public Guid SellerId { get; set; }
        [ForeignKey("SellerId")]
        public virtual Seller Seller { get; set; }     
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
