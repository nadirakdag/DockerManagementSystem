namespace DMS.Services.Services
{
    using Core.ServiceInterfaces;
    using Docker.Interfaces;
    using Data;
    using System;
    using Core.Entities;
    using System.Collections.Generic;
    using Microsoft.Data.Entity;
    using System.Linq;

    public class HostService : IHostService
    {
        private DataContext _context;
        private IHost host;

        public HostService(DataContext context, IHost host)
        {
            this._context = context;
            this.host = host;
        }

        public List<Host> GetHostList(int take = 5)
        {
            return _context.Hosts.Include(x => x.User).Take(take).ToList();
        }

        public bool AddNewHost(string host,int userId)
        {
            var result = this.host.Info(host);
            _context.Hosts.Add(new Core.Entities.Host()
            {
                AddedDate = DateTime.Now,
                HostName = result.Name,
                IP = host,
                OsType = result.OSType,
                ServerVersion = result.ServerVersion,
                IsActive = true,
                UserId = userId
            });
            _context.Activities.Add(new Core.Entities.Activity()
            {
                HappendDate = DateTime.Now,
                Description = string.Format("{0} host added by {1}", result.Name, GetUserName(userId))
                //TODO: kullanýcý adý gelmeli
            });
            _context.SaveChanges();
            return true;
        }

        public void RemoveHost(int hostId, int userId)
        {
            var host = _context.Hosts.FirstOrDefault(x => x.HostId == hostId);
            _context.Activities.Add(new Core.Entities.Activity()
            {
                HappendDate = DateTime.Now,
                Description = string.Format("{0} host removed by {1}", host.HostName, GetUserName(userId))
                //TODO: kullanýcý adý gelmeli
            });
            _context.Hosts.Attach(host).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        private string GetUserName(int userId)
        {
            var host = _context.Users.FirstOrDefault(x => x.UserId == userId);
            if (host == null)
                throw new Exception(string.Format("User doesn't exist. User Id: {0}", userId));
            else
                return host.Name;
        }
    }
}
