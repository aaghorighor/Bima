using System;
using System.Collections.Generic;

#nullable disable

namespace Suftnet.Co.Bima.DataAccess.Actions
{
    public partial class AspNetUserClaim
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
}
