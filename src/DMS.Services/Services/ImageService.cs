using DMS.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMS.Core.Models;
using DMS.Data;
using DMS.Docker.Interfaces;

namespace DMS.Services.Services
{
    public class ImageService : IImageService
    {

        private DataContext _context;
        private IImage _image;

        public ImageService(DataContext context, IImage Image)
        {
            this._context = context;
            this._image = Image;
        }

        public List<ImageModel> GetImages()
        {
            List<ImageModel> containers = new List<ImageModel>();
            foreach (var item in _context.Hosts)
            {
                var list = _image.GetImages(item.IP, item.HostName);
                containers.AddRange(list);
            }

            return containers;
        }

        public List<SelectListItemModel> Hosts()
        {
            return _context.Hosts.Select(x => new SelectListItemModel()
            {
                Text = x.HostName,
                Value = x.HostId.ToString(),
                Selected = false
            }).ToList();
        }

        public void Pull(string imageName, int hostId, int userId)
        {
            string hostIP = GetHostIP(hostId);
            _image.Pull(hostIP, imageName);

            _context.Activities.Add(new Core.Entities.Activity()
            {
                HappendDate = DateTime.Now,
                Description = string.Format("{0} image pulled by {1}", imageName, GetUserName(userId))
            });
            _context.ContainerImages.Add(new Core.Entities.ContainerImage()
            {
                HostId = hostId,
                UserId = userId,
                GetTime = DateTime.Now,
                ImageName = imageName
            });

            _context.SaveChanges();
        }

        public List<ImageSearchResult> Search(int hostId, string term)
        {
            return _image.Search(GetHostIP(hostId), term);
        }

        private string GetHostIP(int hostId)
        {
            var host = _context.Hosts.FirstOrDefault(x => x.HostId == hostId);
            if (host == null)
            {
                throw new Exception(string.Format("Host doesn't exist. Host ID: {0}", hostId));
            }
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
    }
}
