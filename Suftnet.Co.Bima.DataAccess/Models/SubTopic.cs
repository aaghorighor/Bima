using System;
using System.Collections.Generic;

namespace Suftnet.Co.Bima.DataAccess.Models
{
    public partial class SubTopic
    {
        public string Description { get; set; }
        public DateTime CreatedDt { get; set; }
        public string CreatedBy { get; set; }
        public int TopicId { get; set; }
        public byte[] TimeStamp { get; set; }
        public string ImageUrl { get; set; }
        public int IndexNo { get; set; }
        public string Title { get; set; }
        public int Id { get; set; }
    }
}
