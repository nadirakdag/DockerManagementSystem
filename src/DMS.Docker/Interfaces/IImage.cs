using DMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Docker.Interfaces
{
    public interface IImage
    {
        List<ImageSearchResult> Search(string host, string term);
        void Pull(string host, string imageName);
        string Inspect(string host, string imageName);
        List<ImageModel> GetImages(string host, string hostName);
    }
}
