using System;
using System.Collections.Generic;

namespace Suftnet.Co.Bima.DataAccess.Models
{
    public partial class LogViewer
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDt { get; set; }
        public string Description { get; set; }
        public byte[] TimeStamp { get; set; }
    }
}
