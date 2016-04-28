namespace DMS.Services.Services
{
    using Core;
    using Core.Entities;
    using Core.ServiceInterfaces;
    using Core.ContainerInterfaces;
    using Data;
    using Microsoft.Data.Entity;
    using System.Linq;
    using System.Collections.Generic;

    public class HostService : IHostService
    {
        private DataContext context;
        private IContainer container;

        public HostService(DataContext context,IContainer container)
        {
            this.context = context;
            this.container = container;
        }
        
        public bool AddNewHost(string host){
            return true;    
        }
        
        public void RemoveHost(string hostId){
            
        }

     }
}
