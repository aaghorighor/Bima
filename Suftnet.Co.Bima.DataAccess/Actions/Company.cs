using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Suftnet.Co.Bima.DataAccess.Actions
{
    public partial class Company
    {
        public Company()
        {
            BuyerAddresses = new HashSet<BuyerAddress>();
            Deliveries = new HashSet<Delivery>();
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
        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        public virtual Area Area { get; set; }
        public virtual ICollection<BuyerAddress> BuyerAddresses { get; set; }
        public virtual ICollection<Delivery> Deliveries { get; set; }
        public virtual ICollection<SellerAddress> SellerAddresses { get; set; }
    }
}
