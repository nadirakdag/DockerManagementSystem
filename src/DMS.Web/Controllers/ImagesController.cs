using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using DMS.Web.Models.ViewModels.ImageViewModels;
using DMS.Core.ServiceInterfaces;
using Microsoft.AspNet.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DMS.Web.Controllers
{
    [Authorize]
    public class ImagesController : Controller
    {
        private IImageService service;

        private int UserID
        {
            get
            {
                return Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "UserID").Value);
            }
        }

        public ImagesController(IImageService service)
        {
            this.service = service;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SearchImages()
        {
            SearchImageViewModel sivm = new SearchImageViewModel();
            sivm.Hosts = service.Hosts();

            return View(sivm);
        }

        [HttpPost]
        public IActionResult SearchImages(string imageName, int hostId)
        {
            var imageResults = service.Search(hostId, imageName);
            SearchImageViewModel sivm = new SearchImageViewModel();

            sivm.HostId = hostId.ToString();
            sivm.SearchTerm = imageName;
            sivm.SearchResults = imageResults;
            sivm.Hosts = service.Hosts();

            return View(sivm);
        }

        public IActionResult Pull(string imageName, int hostId)
        {
            service.Pull(imageName, hostId, UserID);
            return RedirectToAction("Index");
        }

        public IActionResult GetImages()
        {
            return Json(service.GetImages());
        }
    }
}
