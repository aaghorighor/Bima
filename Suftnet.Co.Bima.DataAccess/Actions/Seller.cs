using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Suftnet.Co.Bima.DataAccess.Actions
{
    public partial class Seller
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
        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public string Size { get; set; }
        public string HarvestSize { get; set; }
        public string HarvestTime { get; set; }
    }
}
