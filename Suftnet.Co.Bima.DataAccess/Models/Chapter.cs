using System;
using System.Collections.Generic;

namespace Suftnet.Co.Bima.DataAccess.Models
{
    public partial class Chapter
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDt { get; set; }
        public string CreatedBy { get; set; }
        public int SectionId { get; set; }
        public int SubSectionId { get; set; }
        public bool Publish { get; set; }
        public byte[] TimeStamp { get; set; }
        public string ImageUrl { get; set; }
    }
}
