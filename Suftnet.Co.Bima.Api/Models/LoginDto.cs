namespace Suftnet.Co.Bima.Api.Models
{
    using System.ComponentModel.DataAnnotations;
    public class LoginDto
    {
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        public bool? RememberMe { get; set; }
    }
}
