using System;
using System.Collections.Generic;

namespace Suftnet.Co.Bima.DataAccess.Models
{
    public partial class CustomerAccount
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}
