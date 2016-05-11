using System;
namespace DMS.Web.Controllers
{
    using Microsoft.AspNet.Mvc;
    using Core.Entities;
    using Models.ViewModels.UserViewModels;
    using Core.ServiceInterfaces;
    using Microsoft.AspNet.Authorization;

    [Authorize]
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
