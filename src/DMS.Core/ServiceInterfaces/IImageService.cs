using DMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Core.ServiceInterfaces
{
    public interface IImageService
    {
        List<ImageSearchResult> Search(int hostId, string term);
        List<SelectListItemModel> Hosts();
        void Pull(string imageName, int hostId, int userId);
        List<ImageModel> GetImages();
    }
}
