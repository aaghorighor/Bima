using System;
using System.Collections.Generic;

namespace Suftnet.Co.Bima.DataAccess.Models
{
    public partial class OrderDetail
    {
        public Guid Id { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Lenght { get; set; }
        public DateTime CreatedDt { get; set; }
        public string CreatedBy { get; set; }
        public Guid OrderId { get; set; }
        public double Weight { get; set; }
        public bool Frengible { get; set; }
        public DateTime? UpdateDt { get; set; }
        public string UpdateBy { get; set; }
        public string Note { get; set; }
        public string ItemName { get; set; }

        public virtual Order Order { get; set; }
    }
}
