using System;
using System.Collections.Generic;

#nullable disable

namespace Suftnet.Co.Bima.DataAccess.Actions
{
    public partial class AddressType
    {
        public AddressType()
        {
            BuyerAddresses = new HashSet<BuyerAddress>();
            SellerAddresses = new HashSet<SellerAddress>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDt { get; set; }
        public string CreatedBy { get; set; }
        public int IndexNo { get; set; }
        public byte[] TimeStamp { get; set; }
        public Guid Id { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<BuyerAddress> BuyerAddresses { get; set; }
        public virtual ICollection<SellerAddress> SellerAddresses { get; set; }
    }
}
