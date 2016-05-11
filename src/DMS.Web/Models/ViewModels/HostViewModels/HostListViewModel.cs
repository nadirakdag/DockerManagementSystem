using DMS.Core.Entities;
using DMS.Web.Models.ViewModels.UserViewModels;
using System.Collections.Generic;

namespace DMS.Web.Models.ViewModels.HostViewModels
{
    public class HostListViewModel : BaseViewModel
    {
        public List<Host> Hosts { get; set; }
    }
}
