using System;
using System.Collections.Generic;

namespace Suftnet.Co.Bima.DataAccess.Actions
{
    public partial class Company
    {
        public Company()
        {
            Bargain = new HashSet<Bargain>();
            Buyer = new HashSet<Buyer>();
            BuyerAddress = new HashSet<BuyerAddress>();
            Delivery = new HashSet<Delivery>();
            Driver = new HashSet<Driver>();
            Offers = new HashSet<Offers>();
            Seller = new HashSet<Seller>();
            SellerAddress = new HashSet<SellerAddress>();
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

        public virtual Area Area { get; set; }
        public virtual ICollection<Bargain> Bargain { get; set; }
        public virtual ICollection<Buyer> Buyer { get; set; }
        public virtual ICollection<BuyerAddress> BuyerAddress { get; set; }
        public virtual ICollection<Delivery> Delivery { get; set; }
        public virtual ICollection<Driver> Driver { get; set; }
        public virtual ICollection<Offers> Offers { get; set; }
        public virtual ICollection<Seller> Seller { get; set; }
        public virtual ICollection<SellerAddress> SellerAddress { get; set; }
    }
}
