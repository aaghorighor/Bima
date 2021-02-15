using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Suftnet.Co.Bima.DataAccess.Actions
{
    public partial class Logger
    {
        public Guid Id { get; set; }
        public string Description { get; set; }      
        public DateTime CreatedAt { get; set; }     
        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }      
      
    }
}
