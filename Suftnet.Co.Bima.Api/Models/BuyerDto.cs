namespace Suftnet.Co.Bima.Api.Models
{
    using System;
    public class BuyerDto
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
        public string Description { get; set; }
        public string ShelfLife { get; set; }
        public string Rejection { get; set; }
    }
}
