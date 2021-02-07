namespace Suftnet.Co.Bima.Api.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class OrderDto
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string City { get; set; }
        [Required]
        [StringLength(50)]
        public string State { get; set; }
        [Required]
        [StringLength(50)]
        public string Country { get; set; }
        [Required]
        [StringLength(150)]
        public string Address { get; set; }
        [Required]      
        public Guid BuyerId { get; set; }
        [Required]    
        public Guid ProduceId { get; set; }
        [Required]        
        public double AmountPaid { get; set; }       
        public decimal Total { get; set; }
        public decimal Balance { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }

    }

    public class CreateOrder : OrderDto
    {

    }

    public class BuyerOrder : OrderDto
    {
        public string ItemName { get; set; }
        public string AvailableDate { get; set; }
        public string Status { get; set; }
        public string StatusId { get; set; }
        public string CollectionAddress { get; set; }
        public string DeliveryAddress { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
        public string PhoneNumber { get; set; }
        public string Contact { get; set; }
    }

    public class SellerOrder : OrderDto
    {
        public string ItemName { get; set; }
        public string AvailableDate { get; set; }
        public string Status { get; set; }
        public string StatusId { get; set; }
        public string CollectionAddress { get; set; }
        public string DeliveryAddress { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
        public string PhoneNumber { get; set; }
        public string Contact { get; set; }
    }
}
