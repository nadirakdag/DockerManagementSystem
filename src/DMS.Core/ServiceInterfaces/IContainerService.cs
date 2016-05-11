namespace DMS.Core.ServiceInterfaces
{
    using DMS.Core.Models;
    using System.Collections.Generic;
    
    public interface IContainerService
    {
        List<ContainerModel> GetContainers(int take=5);
        void StartContainer(string containerId, int host, int userId);
        void RestartContainer(string containerId, int host, int userId);
        void RemoveContainer(string containerId, int host, int userId);
        void StopContainer(string containerId, int host, int userId);
    }
}
