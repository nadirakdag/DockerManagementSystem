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
    using Models.ViewModels.HostViewModels;

    [Authorize]
    public class HostController : Controller
    {
        private IHostService service;

        private int UserID
        {
            get
            {
                return Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "UserID").Value);
            }
        }

        public HostController(IHostService service)
        {
            this.service = service;
        }
        // GET: /<controller>/
        public IActionResult Index(Models.ViewModels.UserViewModels.BaseViewModel r = null)
        {
            HostListViewModel hlvm = new HostListViewModel();
            hlvm.Hosts = service.GetHostList();

            hlvm.OperationMessage = r.OperationMessage;
            hlvm.OperationStatus = r.OperationStatus;

            return View(hlvm);
        }

        [HttpPost]
        public IActionResult AddNewHost(string host)
        {
            bool result = service.AddNewHost(host, UserID);

            var vmResult = new Models.ViewModels.UserViewModels.BaseViewModel();
            if (result)
            {
                vmResult.OperationStatus = true;
                vmResult.OperationMessage = "Host successfully added";
            }
            else
            {
                vmResult.OperationStatus = false;
                vmResult.OperationMessage = "Host cloudn't added!";
            }

            return RedirectToAction("Index", vmResult);
        }

        public IActionResult RevomeHost(string hostId)
        {

            int id = 0;

            var vmResult = new Models.ViewModels.UserViewModels.BaseViewModel();
            if (!int.TryParse(hostId, out id))
            {
                vmResult.OperationStatus = false;
                vmResult.OperationMessage = "Please select valid host";
            }

            service.RemoveHost(id, UserID);
            return RedirectToAction("Index", vmResult);
        }
    }
}
