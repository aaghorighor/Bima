namespace Suftnet.Co.Bima.Api.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserDto
    {
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string PhoneNumber { get; set; }
        [StringLength(50)]
        public string Description { get; set; }        
        [StringLength(50)]
        public string ImageUrl { get; set; }
        public bool Active { get; set; }
    }

    public class CreateUser : UserDto
    {

    }

    public class CreateSeller : UserDto
    {
        public Guid CompanyId { get; set; }
    }

    public class CreateBuyer : UserDto
    {
        public Guid CompanyId { get; set; }
    }

    public class CreateDriver : UserDto
    {
        public Guid CompanyId { get; set; }
    }

    public class UpdateUser
    {
        [Required]
        public string Id { get; set; }
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string PhoneNumber { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        [StringLength(50)]
        public string ImageUrl { get; set; }
        public bool Active { get; set; }
    }
    public class RemoveUser
    {
        [Required]
        public string Id { get; set; }
    }
    public class ResetUserPassword
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
