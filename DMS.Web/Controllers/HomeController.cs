using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using DMS.Web.Models.HomeViewModels;

namespace DMS.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Dashboard()
        {
            return View(new DashboardViewModel());
        }
        
        public IActionResult Login(){
            return View(new LoginViewModel());
        }
        
        [HttpPost]
        public IActionResult Login(LoginViewModel lvm){
            return View(lvm);
        }
    }
}
