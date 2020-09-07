using System;
using System.Collections.Generic;

namespace Suftnet.Co.Bima.DataAccess.Models
{
    public partial class DeliveryAddress
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
        public bool? Active { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDt { get; set; }
        public string Latitude { get; set; }
        public string Logitude { get; set; }
        public string County { get; set; }
        public string CompleteAddress { get; set; }
        public string Town { get; set; }
        public byte[] TimeStamp { get; set; }
        public Guid Id { get; set; }
    }
}
