namespace DMS.Core.ServiceInterfaces
{
    using DMS.Core.Entities;
    using System.Collections.Generic;

    public interface IHostService
    {
        List<Host> GetHostList(int take = 5);
        bool AddNewHost(string host, int userId);
        void RemoveHost(int hostId, int userId);
    }
}
