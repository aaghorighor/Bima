using System;
using System.Collections.Generic;

#nullable disable

namespace Suftnet.Co.Bima.DataAccess.Actions
{
    public partial class AspNetUserLogin
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string UserId { get; set; }
    }
}
