﻿using System;
using System.Collections.Generic;

namespace Suftnet.Co.Bima.DataAccess.Models
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerAccount = new HashSet<CustomerAccount>();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDt { get; set; }
        public bool Active { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public byte[] TimeStamp { get; set; }
        public string Description { get; set; }

        public virtual ICollection<CustomerAccount> CustomerAccount { get; set; }
    }
}
