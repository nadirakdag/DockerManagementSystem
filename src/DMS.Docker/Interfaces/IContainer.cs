using DMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Docker.Interfaces
{
    public interface IContainer
    {
        List<ContainerModel> GetContainers(string host, string hostName, int hostId, int take = 5);
        void StopContainer(string host, string containerId);
        void RemoveContainer(string host, string containerId);
        void RestartContainer(string host, string containerId);
        void StartContainer(string host, string containerId);
    }
}
