namespace DMS.Core.Entities
{
    using System;
    
    public class Host
    {
        public int HostId { get; set; }
        public string IP { get; set; }
        public string OsType { get; set; }
        public string ServerVersion { get; set; }
        public string HostName { get; set; }
        public DateTime AddedDate { get; set; }
        public bool IsActive { get; set; }
        
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}