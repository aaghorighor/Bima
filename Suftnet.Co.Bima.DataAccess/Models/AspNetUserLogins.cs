using System;
using System.Collections.Generic;

namespace Suftnet.Co.Bima.DataAccess.Models
{
    public partial class AspNetUserLogins
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string UserId { get; set; }
    }
}
