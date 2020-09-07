using System;
using System.Collections.Generic;

namespace Suftnet.Co.Bima.DataAccess.Models
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
        public byte[] TimeStamp { get; set; }
    }
}
