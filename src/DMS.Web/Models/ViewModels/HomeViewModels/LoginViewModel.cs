using DMS.Web.Models.ViewModels.UserViewModels;

namespace DMS.Web.Models.ViewModels.HomeViewModels
{
    public class LoginViewModel:BaseViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
