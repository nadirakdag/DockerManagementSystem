namespace DMS.Core.Models
{
    using System;
    using Entities;
    
    public class ContainerModel
    {
        public string Image { get; set; }
        public string  Id { get; set; }
        public string[] Names { get; set; }
        public string State { get; set; }
        public string Status { get; set; }
        public int Created { get; set; }
        public string HostName { get; set; }
        public int HostId { get; set; }
    }
}