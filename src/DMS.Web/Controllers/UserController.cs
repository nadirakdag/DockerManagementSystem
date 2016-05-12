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
        public IActionResult Index(string message = null, bool? status = null)
        {
            UserListViewModel ulvm = new UserListViewModel();
            ulvm.Users = service.GetAllUser();
            ulvm.Roles = service.GetRoles();

            if (string.IsNullOrEmpty(message) == false && status.HasValue)
            {
                ulvm.OperationStatus = status.Value;
                ulvm.OperationMessage = message;
            }

            return View(ulvm);
        }

        [HttpPost]
        public IActionResult AddNewUser(UserViewModel user)
        {
            if (user.Password != user.RePassword)
            {
                return RedirectToAction("Index", new { message = "Passwords aren't same. Please check-it", status = false });
            }

            var _user = new User()
            {
                EMail = user.EMail,
                Name = user.Name,
                Password = user.Password,
                RoleId = user.RoleId
            };
            service.AddNewUser(_user);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            service.DeleteUserById(id);
            return RedirectToAction("Index", new { message = "User deleted", status = true });
        }

        public IActionResult Profile(int id)
        {
            var user = service.GetUserById(id);
            if (user == null)
            {
                throw new Exception("User did not found in the database");
            }

            UserViewModel uvm = new UserViewModel();
            uvm.Name = user.Name;
            uvm.EMail = user.EMail;
            uvm.RoleId = user.RoleId;
            uvm.Roles = service.GetRoles();

            return View(uvm);
        }

        [HttpPost]
        public IActionResult Profile(int id, UserViewModel user)
        {
            user.Roles = service.GetRoles();

            if (user.Password != user.RePassword)
            {
                user.OperationStatus = false;
                user.OperationMessage = "Passwords aren't same. Please check-it";
                return View(user);
            }

            service.EditUser(new Core.Entities.User()
            {
                EMail = user.EMail,
                Name = user.Name,
                Password = user.Password,
                RoleId = user.RoleId,
                UserId = id
            });
            return RedirectToAction("Profile", new { id });
        }
    }
}
