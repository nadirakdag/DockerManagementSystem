namespace DMS.Docker
{
    using System;
    using DMS.Core.ContainerInterfaces;

    public class Container : IContainer
    {
        public object CreateContainer(object container)
        {
            throw new NotImplementedException();
        }

        public object GetContainers()
        {
            throw new NotImplementedException();
        }

        public object KillContainer(string containerId)
        {
            throw new NotImplementedException();
        }

        public object LogsOfContainer(string containerId)
        {
            throw new NotImplementedException();
        }

        public object PauseContainer(string containerId)
        {
            throw new NotImplementedException();
        }

        public object ProcessesOfContainer(string containerId)
        {
            throw new NotImplementedException();
        }

        public object RemoveContainer(string containerId)
        {
            throw new NotImplementedException();
        }

        public object RestartContainer(string containerId)
        {
            throw new NotImplementedException();
        }

        public object StartContainer(string containerId)
        {
            throw new NotImplementedException();
        }

        public object StopContainer(string containerId)
        {
            throw new NotImplementedException();
        }

        public object UnPauseContainer(string containerId)
        {
            throw new NotImplementedException();
        }
    }
}