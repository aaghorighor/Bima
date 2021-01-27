using System;
using System.Collections.Generic;

#nullable disable

namespace Suftnet.Co.Bima.DataAccess.Actions
{
    public partial class DeliveryStatus
    {
        public DeliveryStatus()
        {
            DeliveryOffers = new HashSet<DeliveryOffer>();
        }

        public Guid Id { get; set; }
        public Guid OfferId { get; set; }
        public Guid CompanyId { get; set; }
        public Guid? StatusId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string Note { get; set; }
        public byte[] TimeStamp { get; set; }

        public virtual Company Company { get; set; }
        public virtual Offer Offer { get; set; }
        public virtual ICollection<DeliveryOffer> DeliveryOffers { get; set; }
    }
}
