using System;
using System.Collections.Generic;

namespace Suftnet.Co.Bima.DataAccess.Actions
{
    public partial class AspNetUsers
    {
        public AspNetUsers()
        {        
            Driver = new HashSet<Driver>();
            Seller = new HashSet<Seller>();
        }

        public string Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool? LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
        public string ImageUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Otp { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsEnabled { get; set; }
        public string UserType { get; set; }
        public string NormalizedEmail { get; set; }
        public string NormalizedUserName { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public string ConcurrencyStamp { get; set; }
   
        public virtual ICollection<Driver> Driver { get; set; }
        public virtual ICollection<Seller> Seller { get; set; }
    }
}
