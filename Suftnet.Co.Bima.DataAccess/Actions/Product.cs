using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Suftnet.Co.Bima.DataAccess.Actions
{
    public partial class Product
    {
        public Product()
        {
            Bargain = new HashSet<Bargain>();
            Offers = new HashSet<Offers>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double? Quantity { get; set; }
        public decimal? Price { get; set; }
        public Guid? StatusId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] TimeStamp { get; set; }

        public virtual ProductStatus Status { get; set; }
        public virtual ICollection<Bargain> Bargain { get; set; }
        public virtual ICollection<Offers> Offers { get; set; }
    }
}
