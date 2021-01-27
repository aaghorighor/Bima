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
        public string Description { get; set; }
        [Required]
        public decimal Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        public bool Active { get; set; }       
        [Required]
        public Guid UnitId { get; set; }
        public string Unit { get; set; }
        [Required]
        public DateTime AvailableDate { get; set; }
        public string CreatedBy { get; set; }    
        public DateTime CreatedAt { get; set; }     
    }

    public class CreateProduce : ProduceDto
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string Email { get; set; }
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
