namespace DMS.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNet.Mvc;
    using Models.ViewModels.HomeViewModels;
    using Core.ServiceInterfaces;
    using Core.Models;
    using Microsoft.AspNet.Authorization;

    [Authorize]
    public class HomeController : Controller
    {
        private IHostService _hostService;
        private IActionService _actionService;

        public HomeController(IHostService hostService, IActionService action)
        {
            _hostService = hostService;
            _actionService = action;
        }

        // GET: /<controller>/
        public IActionResult Dashboard()
        {
            DashboardViewModel dvm = new DashboardViewModel();
            dvm.Actions = _actionService.GetActions();
            dvm.Containers = new List<ContainerModel>();

            dvm.Hosts = _hostService.GetHostList().Select(x => new HostModel()
            {
                HostName = x.HostName,
                IP = x.IP,
                OsType = x.OsType,
                ServerVersion = x.ServerVersion
            }).ToList();

            return View(dvm);
        }
    }
}
