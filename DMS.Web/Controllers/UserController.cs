using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace DMS.Web.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult NewUser(NewUserViewModel nuvm){
            return View();
        }
        
        public IActionResult Profile(string id){
            return View();
        }
    }
}
