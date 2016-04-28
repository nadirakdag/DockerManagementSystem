namespace DMS.Services.Services
{
    using Core;
    using Core.Entities;
    using Core.ServiceInterfaces;
    using Data;
    using Microsoft.Data.Entity;
    using System.Linq;
    using System.Collections.Generic;

    public class HostService : IHostService
    {
        private DataContext context;

        public HostService(DataContext context)
        {
            this.context = context;
        }
        
        public bool AddNewHost(string host){
            return true;    
        }
        
        public void RemoveHost(string hostId){
            
        }

     }
}
