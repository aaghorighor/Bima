using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Suftnet.Co.Bima.DataAccess.Actions
{
    public partial class Delivery
    {
        public Guid Id { get; set; }
        public Guid OfferId { get; set; }
        public Guid CompanyId { get; set; }
        public Guid? StatusId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string Note { get; set; }
        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] TimeStamp { get; set; }

        public virtual Company Company { get; set; }
        public virtual Offers Offer { get; set; }
    }
}
