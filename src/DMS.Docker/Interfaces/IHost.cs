using DMS.Core.Models;

namespace DMS.Docker.Interfaces
{
    public interface IHost
    {
        Info Info(string hostAddress);
        bool Ping();
    }
}
