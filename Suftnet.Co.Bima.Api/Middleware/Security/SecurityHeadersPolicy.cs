namespace Suftnet.Co.Bima.Api.Models
{
    using System.Collections.Generic;

    public class SecurityHeadersPolicy
    {
        public IDictionary<string, string> SetHeaders { get; }
            = new Dictionary<string, string>();

        public ISet<string> RemoveHeaders { get; }
            = new HashSet<string>();
    }
}
