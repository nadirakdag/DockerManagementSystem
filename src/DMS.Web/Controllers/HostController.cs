using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DMS.Web.Controllers
{
    public class HostController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AddNewHost(string host){
            return Content(host);
        }
        
        public IActionResult RevomeHost(string hostId){
            return RedirectToAction("Index");
        }
    }
}
