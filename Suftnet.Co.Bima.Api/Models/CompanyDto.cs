namespace Suftnet.Co.Bima.Api.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CompanyDto
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        [Required]
        public Guid AreaId { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string Area { get; set; }
    }
       

    public class CreateCompany : CompanyDto
    {
        [Required]
        public new Guid Id { get; set; }
    }

    public class UpdateCompany : CompanyDto
    {
        [Required]
        public new Guid Id { get; set; }
    }

    public class Delete 
    {
        [Required]
        public Guid Id { get; set; }
    }
}
