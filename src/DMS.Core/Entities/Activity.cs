namespace DMS.Core.Entities
{
    using System;

    public class Activity
    {
        public int ActivityId { get; set; }
        public string Description { get; set; }
        public DateTime HappendDate { get; set; }
        
        public int HostId { get; set; }
        public virtual Host Host { get; set; }
        
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}