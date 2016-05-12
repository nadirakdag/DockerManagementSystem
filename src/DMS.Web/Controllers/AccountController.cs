using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using DMS.Web.Models.ViewModels.HomeViewModels;
using System.Security.Claims;
using Microsoft.AspNet.Authentication.Cookies;
using Microsoft.AspNet.Http.Authentication;
using DMS.Core.ServiceInterfaces;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DMS.Web.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _service;
        public AccountController(IUserService service)
        {
            _service = service;
        }

        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string ReturnUrl = null)
        {
            DMS.Core.Entities.User user;
            if (_service.UserExist(model.UserName, model.Password, out user))
            {
                const string Issuer = "https://dms";

                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, user.Name, ClaimValueTypes.String, Issuer));
                claims.Add(new Claim("UserID", user.UserId.ToString(), ClaimValueTypes.Integer, Issuer));

                var userIdentity = new ClaimsIdentity("SuperSecureLogin");
                userIdentity.AddClaims(claims);

                var userPrincipal = new ClaimsPrincipal(userIdentity);

                await HttpContext.Authentication.SignInAsync("Cookie", userPrincipal,
                    new AuthenticationProperties
                    {
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                        IsPersistent = false,
                        AllowRefresh = false
                    });

                if (!string.IsNullOrEmpty(ReturnUrl))
                {
                    return Redirect(ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Dashboard", "Home");
                }
            }
            else
            {
                model.OperationStatus = false;
                model.OperationMessage = "Username or Password is not correct. Please check";
                return View(model);
            }
        }


        public IActionResult Logout()
        {
            HttpContext.Authentication.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View("Login");
        }
    }
}
