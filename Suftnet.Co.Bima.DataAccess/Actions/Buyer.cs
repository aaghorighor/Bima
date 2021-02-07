using System;
using System.Collections.Generic;

#nullable disable

namespace Suftnet.Co.Bima.DataAccess.Actions
{
    public partial class Buyer
    {       
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
     
    }
}
