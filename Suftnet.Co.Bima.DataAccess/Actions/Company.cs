using System;
using System.Collections.Generic;

#nullable disable

namespace Suftnet.Co.Bima.DataAccess.Actions
{
    public partial class Company
    {
        public Company()
        {
            BuyerAddresses = new HashSet<BuyerAddress>();
            Buyers = new HashSet<Buyer>();
            DeliveryOffers = new HashSet<DeliveryOffer>();
            DeliveryStatuses = new HashSet<DeliveryStatus>();
            Drivers = new HashSet<Driver>();
            Offers = new HashSet<Offer>();
            SellerAddresses = new HashSet<SellerAddress>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public Guid AreaId { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public byte[] TimeStamp { get; set; }

        public virtual Area Area { get; set; }
        public virtual ICollection<BuyerAddress> BuyerAddresses { get; set; }
        public virtual ICollection<Buyer> Buyers { get; set; }
        public virtual ICollection<DeliveryOffer> DeliveryOffers { get; set; }
        public virtual ICollection<DeliveryStatus> DeliveryStatuses { get; set; }
        public virtual ICollection<Driver> Drivers { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }
        public virtual ICollection<SellerAddress> SellerAddresses { get; set; }
    }
}
