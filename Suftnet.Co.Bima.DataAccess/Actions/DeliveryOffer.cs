using System;
using System.Collections.Generic;

#nullable disable

namespace Suftnet.Co.Bima.DataAccess.Actions
{
    public partial class DeliveryOffer
    {
        public Guid Id { get; set; }
        public Guid LogisticId { get; set; }
        public Guid OfferId { get; set; }
        public Guid StatusId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        public virtual Company Logistic { get; set; }
        public virtual Offer Offer { get; set; }
        public virtual DeliveryStatus Status { get; set; }
    }
}
