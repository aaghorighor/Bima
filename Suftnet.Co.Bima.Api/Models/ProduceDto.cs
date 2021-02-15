namespace Suftnet.Co.Bima.Api.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ProduceDto
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [Required]
        public decimal Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        public bool Active { get; set; }         
        [Required]
        public string Unit { get; set; }
        [Required]
        public string AvailableDate { get; set; }
        public string CreatedBy { get; set; }    
        public DateTime CreatedAt { get; set; }
        public string UserId { get; set; }       
        public string FirstName { get; set; }     
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

    }

    public class CreateProduce : ProduceDto
    {        
       
    }

    public class UpdateProduce : ProduceDto
    {
        [Required]
        public new Guid Id { get; set; }
    }

    public class DeleteProduce 
    {
        [Required]
        public Guid Id { get; set; }
    }
   
}
