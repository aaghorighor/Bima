namespace Suftnet.Co.Bima.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;


    public class Query
    {
        [Required]
        public string UserId { get; set; }
    }

    public class Param
    {
        [Required]
        public string Id { get; set; }
    }
}
