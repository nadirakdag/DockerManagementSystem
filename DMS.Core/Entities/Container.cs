namespace DMS.Core.Entities
{
    using System;
    
    public class Container
    {
        public string ContainerId { get; set; }
        public DateTime AddedDate { get; set; }
        public bool Status { get; set; }
        public string ContainerName { get; set; }
        public string JSONDetail { get; set; }
        
        public int UserId { get; set; }
        public virtual User User{ get; set; }
        
        public int HostId { get; set; }
        public virtual Host Host { get; set; }
    }
}