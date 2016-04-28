using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DMS.Web.Controllers
{
    using Core.ServiceInterfaces;
    
    public class HostController : Controller
    {
        private IHostService service;
        
        public HostController(IHostService service){
            this.service=service;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AddNewHost(string host){
            
            bool result = service.AddNewHost(host);
            
            //Bu çalışmıyor bu kısım için bir şeyler yapmak lazım!!!!
            // if (result)
            // {
            //     ViewData["Result"]=true;
            //     ViewData["ResultMessage"]="Host successfully added";
            // }
            // else{
            //     ViewData["Result"]=false;
            //     ViewData["ResultMessage"]="Host cloudn't added!";
            // }
            
            return RedirectToAction("Index");
        }
        
        public IActionResult RevomeHost(string hostId){
            return RedirectToAction("Index");
        }
    }
}
