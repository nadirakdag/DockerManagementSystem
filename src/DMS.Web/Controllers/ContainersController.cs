using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DMS.Web.Controllers
{
    using Core.ServiceInterfaces;
    using Microsoft.AspNet.Authorization;

    [Authorize]
    public class ContainersController : Controller
    {
        private IContainerService service;

        private int UserID
        {
            get
            {
                return Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "UserID").Value);
            }
        }

        public ContainersController(IContainerService service)
        {
            this.service = service;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetContainers()
        {
            var data = service.GetContainers(10);
            return Json(data);
        }

        public IActionResult Operation(string op, string id, int host)
        {
            switch (op)
            {
                case "start":
                    service.StartContainer(containerId: id, host: host, userId: UserID);
                    break;
                case "restart":
                    service.RestartContainer(containerId: id, host: host, userId: UserID);
                    break;
                case "remove":
                    service.RemoveContainer(containerId: id, host: host, userId: UserID);
                    break;
                case "stop":
                    service.StopContainer(containerId: id, host: host, userId: UserID);
                    break;
                default:
                    break;
            }

            return RedirectToAction("Index");
        }
    }
}
