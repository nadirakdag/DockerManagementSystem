namespace DMS.Core.ServiceInterfaces
{
    using DMS.Core.Entities;
    using System.Collections.Generic;
    
    public interface IHostService
    {
        bool AddNewHost(string host);
        void RemoveHost(string hostId);
    }
}
