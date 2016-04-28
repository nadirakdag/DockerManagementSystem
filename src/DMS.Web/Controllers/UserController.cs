using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using DMS.Core;
using DMS.Core.Entities;
using DMS.Web.Models.ViewModels.UserViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DMS.Web.Controllers
{
    using Core.ServiceInterfaces;
    public class UserController : Controller
    {
        private IUserService service;

        public UserController(IUserService service)
        {
            this.service = service;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            UserListViewModel ulvm = new UserListViewModel(); 
            ulvm.Users = service.GetAllUser();
            ulvm.Roles = service.GetRoles();
            return View(ulvm);
        }

        [HttpPost]
        public IActionResult AddNewUser(User user)
        {
            service.AddNewUser(user);   
            return RedirectToAction("Index");
        }
        
        public IActionResult Delete(int id){
            
            service.DeleteUserById(id);
            return RedirectToAction("Index");
        }

        public IActionResult Profile(int id)
        {
            var user = service.GetUserById(id);
            
            if (user==null)
            {
                throw new Exception("User did not found in the database");
            }
            
            UserViewModel svm = new UserViewModel();
            svm.User = user;   
            return View(svm);
        }
    }
}
