using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Suftnet.Co.Bima.DataAccess.Actions
{
    public partial class AddressType
    {
        public AddressType()
        {
            BuyerAddress = new HashSet<BuyerAddress>();
            SellerAddress = new HashSet<SellerAddress>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDt { get; set; }
        public string CreatedBy { get; set; }
        public int IndexNo { get; set; }
        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] TimeStamp { get; set; }
        public Guid Id { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<BuyerAddress> BuyerAddress { get; set; }
        public virtual ICollection<SellerAddress> SellerAddress { get; set; }
    }
}
