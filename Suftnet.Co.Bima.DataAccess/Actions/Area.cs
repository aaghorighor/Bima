using System;
using System.Collections.Generic;

#nullable disable

namespace Suftnet.Co.Bima.DataAccess.Actions
{
    public partial class Area
    {
        public Area()
        {
            Companies = new HashSet<Company>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDt { get; set; }
        public string CreatedBy { get; set; }
        public int IndexNo { get; set; }
        public byte[] TimeStamp { get; set; }
        public Guid Id { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Company> Companies { get; set; }
    }
}
