namespace DMS.Web.Models.ViewModels.UserViewModels
{
    using DMS.Core.Entities;
    using System.Collections.Generic;
    
    public class UserListViewModel : BaseViewModel
    {
        public List<User> Users { get; set; }
        public List<Role> Roles { get; set;}
    }
}