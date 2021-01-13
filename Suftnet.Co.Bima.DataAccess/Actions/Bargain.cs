using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Suftnet.Co.Bima.DataAccess.Actions
{
    public partial class Bargain
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid CompanyId { get; set; }
        public decimal AmountOffer { get; set; }
        public Guid StatusId { get; set; }
        public string Note { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] TimeStamp { get; set; }

        public virtual Company Company { get; set; }
        public virtual Product Product { get; set; }
    }
}
