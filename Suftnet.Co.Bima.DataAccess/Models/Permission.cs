using System;
using System.Collections.Generic;

namespace Suftnet.Co.Bima.DataAccess.Models
{
    public partial class Permission
    {
        public int ViewId { get; set; }
        public int Create { get; set; }
        public int Edit { get; set; }
        public int Remove { get; set; }
        public int Get { get; set; }
        public int GetAll { get; set; }
        public int? Custom { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDt { get; set; }
        public byte[] TimeStamp { get; set; }
        public string UserId { get; set; }
        public Guid Id { get; set; }

        public virtual Common View { get; set; }
    }
}
