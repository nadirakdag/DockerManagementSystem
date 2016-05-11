namespace DMS.Services.Services
{
    using Core.ServiceInterfaces;
    using Core.Models;
    using System.Collections.Generic;
    using Data;
    using Docker.Interfaces;
    using System;
    using System.Linq;

    public class ContainerService : IContainerService
    {
        private DataContext _context;
        private IContainer _container;

        public ContainerService(DataContext context, IContainer container)
        {
            this._container = container;
            this._context = context;
        }

        public List<ContainerModel> GetContainers(int take = 5)
        {
            List<ContainerModel> containers = new List<ContainerModel>();
            foreach (var item in _context.Hosts)
            {
                var list = _container.GetContainers(item.IP, item.HostName, item.HostId, take);
                containers.AddRange(list);
            }

            return containers;
        }

        private string GetHost(int hostId)
        {
            var host = _context.Hosts.FirstOrDefault(x => x.HostId == hostId);
            if (host == null)
                throw new Exception(string.Format("Host doesn't exist. Host Id: {0}", hostId));
            else
                return host.IP;
        }
        private string GetUserName(int userId)
        {
            var host = _context.Users.FirstOrDefault(x => x.UserId == userId);
            if (host == null)
                throw new Exception(string.Format("User doesn't exist. User Id: {0}", userId));
            else
                return host.Name;
        }

        public void StartContainer(string containerId, int host,int userId)
        {
            _container.StartContainer(host: GetHost(host), containerId: containerId);
            _context.Activities.Add(new Core.Entities.Activity()
            {
                HappendDate = DateTime.Now,
                Description = string.Format("{0} container initialized by {1}", containerId, GetUserName(userId)),
                HostId = host,
                UserId = userId
            });
            _context.SaveChanges();
        }

        public void RestartContainer(string containerId, int host, int userId)
        {
            _container.RestartContainer(host: GetHost(host), containerId: containerId);
            _context.Activities.Add(new Core.Entities.Activity()
            {
                HappendDate = DateTime.Now,
                Description = string.Format("{0} container restarted by {1}", containerId, GetUserName(userId)),
                HostId = host,
                UserId = userId
            });
            _context.SaveChanges();
        }

        public void RemoveContainer(string containerId, int host, int userId)
        {
            _container.RemoveContainer(host: GetHost(host), containerId: containerId);
            _context.Activities.Add(new Core.Entities.Activity()
            {
                HappendDate = DateTime.Now,
                Description = string.Format("{0} container removed by {1}", containerId, GetUserName(userId)),
                HostId = host,
                UserId = userId
            });
            _context.SaveChanges();
        }

        public void StopContainer(string containerId, int host, int userId)
        {
            _container.StopContainer(host: GetHost(host), containerId: containerId);

            _context.Activities.Add(new Core.Entities.Activity()
            {
                HappendDate = DateTime.Now,
                Description = string.Format("{0} container stopped by {1}", containerId, GetUserName(userId)),
                HostId = host,
                UserId = userId
            });
            _context.SaveChanges();
        }
    }
}
