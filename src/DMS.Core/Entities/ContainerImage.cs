namespace DMS.Core.Entities
{
    using System;
    
    public class ContainerImage
    {
        public string ContainerImageId { get; set; }
        public DateTime GetTime { get; set; }
        public string JSONDetail { get; set; }
        
        public int HostId { get; set; }
        public virtual Host Host { get; set; }
        
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}