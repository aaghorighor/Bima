namespace Suftnet.Co.Bima.DataAccess.Identity
{
    using Microsoft.AspNetCore.Identity;
    using Suftnet.Co.Bima.DataAccess.Actions;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    //[Table("AspNetUser")]
    public class ApplicationUser : IdentityUser
    {       
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsEnabled { get; set; }
        public string UserType { get; set; }
        public string OTP { get; set; }
        public string ImageUrl { get; set; }
        [NotMapped]
        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }
    
        ///public virtual AspNetUser AspNetUser { get; set; }
    }
}
