using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Suftnet.Co.Bima.DataAccess.Actions
{
    public partial class Offers
    {
        public Offers()
        {
            Delivery = new HashSet<Delivery>();
        }

        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid CompanyId { get; set; }
        public string PickUpAddress { get; set; }
        public string DeliveryAddress { get; set; }
        public Guid StatusId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] TimeStamp { get; set; }

        public virtual Company Company { get; set; }
        public virtual Product Product { get; set; }
        public virtual OfferStatus Status { get; set; }
        public virtual ICollection<Delivery> Delivery { get; set; }
    }
}
