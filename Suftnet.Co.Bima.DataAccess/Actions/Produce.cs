using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Suftnet.Co.Bima.DataAccess.Actions
{
    public partial class Produce
    {
        public Produce()
        {
            Offers = new HashSet<Offer>();
            ProduceBuyers = new HashSet<ProduceBuyer>();
        }

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
        [ForeignKey("UnitId")]
        public Unit Unit { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }
        public virtual ICollection<ProduceBuyer> ProduceBuyers { get; set; }
    }
}
