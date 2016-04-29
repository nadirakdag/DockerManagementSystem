namespace DMS.Services.Services
{
    using Core.ContainerInterfaces;
    using Core.ServiceInterfaces;
    using Core.Models;
    using Core.Entities;

    public class ContainerService : IContainerService
    {
        private IContainer container;
        public ContainerService(IContainer container)
        {
            this.container = container;
        }
        
        public List<ContainerModel> GetContainers(int take=0){
            var containers = new List<ContainerModel>();
            
            for (int i = 0; i < 5; i++)
            {
                containers.Add(new ContainerModel(){
                    Status=true,
                    ContainerName="boring_feynman_"+i.ToString(),
                    AddedDate = DateTime.Now().AddDays(i),
                    ContainerId="ContainerID_"+i.ToString(),
                    
                    User = new User(){
                        Name="Nadir"
                    },
                    Host = new Host(){
                        HostName = "HostName_"+i.ToString()
                    }
                });
            }
            
            return containers;
        }
    }
}
