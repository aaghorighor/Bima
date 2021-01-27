﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Suftnet.Co.Bima.DataAccess.Actions
{
    public partial class Buyer
    {
        public Buyer()
        {
            ProduceBuyers = new HashSet<ProduceBuyer>();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Active { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public byte[] TimeStamp { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public Guid CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual AspNetUser User { get; set; }
        public virtual ICollection<ProduceBuyer> ProduceBuyers { get; set; }
    }
}
