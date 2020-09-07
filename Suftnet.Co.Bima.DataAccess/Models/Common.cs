using System;
using System.Collections.Generic;

namespace Suftnet.Co.Bima.DataAccess.Models
{
    public partial class Common
    {
        public Common()
        {
            MobilePermission = new HashSet<MobilePermission>();
            Permission = new HashSet<Permission>();
            Settings = new HashSet<Settings>();
            Slider = new HashSet<Slider>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDt { get; set; }
        public bool Active { get; set; }
        public int? Indexno { get; set; }
        public string Code { get; set; }
        public int Settingid { get; set; }
        public string ImageUrl { get; set; }
        public byte[] TimeStamp { get; set; }

        public virtual ICollection<MobilePermission> MobilePermission { get; set; }
        public virtual ICollection<Permission> Permission { get; set; }
        public virtual ICollection<Settings> Settings { get; set; }
        public virtual ICollection<Slider> Slider { get; set; }
    }
}
