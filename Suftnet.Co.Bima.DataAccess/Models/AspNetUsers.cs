using System;
using System.Collections.Generic;

namespace Suftnet.Co.Bima.DataAccess.Models
{
    public partial class AspNetUsers
    {
        public AspNetUsers()
        {
            CustomerAccount = new HashSet<CustomerAccount>();
            DriverAccount = new HashSet<DriverAccount>();
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
        public bool Active { get; set; }
        public string ImageUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Otp { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsEnabled { get; set; }
        public string UserType { get; set; }
        public string NormalizedEmail { get; set; }
        public string NormalizedUserName { get; set; }
        public bool? LockoutEnd { get; set; }
        public byte[] ConcurrencyStamp { get; set; }

        public virtual ICollection<CustomerAccount> CustomerAccount { get; set; }
        public virtual ICollection<DriverAccount> DriverAccount { get; set; }
    }
}
