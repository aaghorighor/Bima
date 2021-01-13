using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Suftnet.Co.Bima.DataAccess.Actions
{
    public partial class Settings
    {
        public int Id { get; set; }
        public string Server { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int? Port { get; set; }
        public string Company { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string Description { get; set; }
        public string ServerEmail { get; set; }
        public decimal? TaxRate { get; set; }
        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] TimeStamp { get; set; }
    }
}
