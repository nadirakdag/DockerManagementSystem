namespace DMS.Core.Models
{
    using System;
    
    public class ContainerModel
    {
        public string ContainerId { get; set; }
        public DateTime AddedDate { get; set; }
        public bool Status { get; set; }
        public string ContainerName { get; set; }
        public User User{ get; set; }
        public Host Host { get; set; }
    }
}