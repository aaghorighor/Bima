using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Suftnet.Co.Bima.DataAccess.Actions
{
    public partial class MobileLogger
    {
        public int Id { get; set; }
        public string ReportId { get; set; }
        public string PackageName { get; set; }
        public string Build { get; set; }
        public string AndroidVersion { get; set; }
        public string AppVersionCode { get; set; }
        public string AvailableMemSize { get; set; }
        public string CrashConfiguration { get; set; }
        public DateTime CreatedDt { get; set; }
        public string CreatedBy { get; set; }
        public string StackTrace { get; set; }
        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] TimeStamp { get; set; }
    }
}
