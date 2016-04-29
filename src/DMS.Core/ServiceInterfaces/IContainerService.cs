namespace DMS.Core.ServiceInterfaces
{
    using DMS.Core.Models;
    using System.Collections.Generic;
    
    public interface IContainerService
    {
        List<ContainerModel> GetContainers(int take=0);
    }
}
