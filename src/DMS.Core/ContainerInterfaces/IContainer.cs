namespace DMS.Core.ContainerInterfaces
{
    public interface IContainer{
        object GetContainers();
        object CreateContainer(object container);
        object StartContainer(string containerId);
        object StopContainer(string containerId);
        object RestartContainer(string containerId);
        object KillContainer(string containerId);
        object PauseContainer(string containerId);
        object UnPauseContainer(string containerId);
        object RemoveContainer(string containerId);
        object LogsOfContainer(string containerId);
        object ProcessesOfContainer(string containerId);
    }
}