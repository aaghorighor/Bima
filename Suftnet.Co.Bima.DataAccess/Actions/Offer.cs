using System;
using System.Collections.Generic;

#nullable disable

namespace Suftnet.Co.Bima.DataAccess.Actions
{
    public partial class Offer
    {
        public Offer()
        {
            DeliveryOffers = new HashSet<DeliveryOffer>();
            DeliveryStatuses = new HashSet<DeliveryStatus>();
        }

        public Guid Id { get; set; }
        public Guid ProducetId { get; set; }
        public Guid BuyerId { get; set; }
        public string PickUpAddress { get; set; }
        public string DeliveryAddress { get; set; }
        public Guid StatusId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public byte[] TimeStamp { get; set; }
        public decimal? AmountPaid { get; set; }
        public decimal? Total { get; set; }
        public decimal? Balance { get; set; }

        public virtual Company Buyer { get; set; }
        public virtual Produce Producet { get; set; }
        public virtual OfferStatus Status { get; set; }
        public virtual ICollection<DeliveryOffer> DeliveryOffers { get; set; }
        public virtual ICollection<DeliveryStatus> DeliveryStatuses { get; set; }
    }
}
