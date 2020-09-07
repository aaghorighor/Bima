using System;
using System.Collections.Generic;

namespace Suftnet.Co.Bima.DataAccess.Models
{
    public partial class Notification
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime CreatedDt { get; set; }
        public string CreatedBy { get; set; }
        public int TenantId { get; set; }
        public string Body { get; set; }
        public int MessageTypeId { get; set; }
        public int? RecipientGroupId { get; set; }
        public int StatusId { get; set; }
    }
}
