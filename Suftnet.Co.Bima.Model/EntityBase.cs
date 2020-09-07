namespace Bgl.Event.Model
{
    using System;
    using System.Collections.Generic;
   
    using System.Text;

    public abstract class EntityBase
    {
       
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
