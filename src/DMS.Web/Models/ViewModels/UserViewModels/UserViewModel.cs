namespace DMS.Web.Models.ViewModels.UserViewModels
{
    using Core.Entities;
    using System.Collections.Generic;
    public class UserViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public int RoleId { get; set; }

        public List<Role> Roles { get; set; }
    }
}