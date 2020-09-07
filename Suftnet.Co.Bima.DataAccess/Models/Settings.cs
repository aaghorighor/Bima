using System;
using System.Collections.Generic;

namespace Suftnet.Co.Bima.DataAccess.Models
{
    public partial class Settings
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool? Active { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDt { get; set; }
        public int? ClassId { get; set; }
        public string ImageUrl { get; set; }
        public byte[] TimeStamp { get; set; }

        public virtual Common Class { get; set; }
    }
}
