namespace DMS.Core.Entities
{
    using System;
    
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }   
    }
}