using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Suftnet.Co.Bima.DataAccess.Actions
{
    [Table("Delivery")]
    public partial class Delivery
    {
        public Guid Id { get; set; }
        public Guid DriverId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public Guid OrderId { get; set; }
        [ForeignKey("DriverId")]
        public virtual Driver Driver { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }

    }
}
