namespace DMS.Web.Models.ViewModels.HomeViewModels
{
    using DMS.Core.Models;
    using System.Collections.Generic;
    
    public class DashboardViewModel //: BaseViewModel
    {
        public List<ContainerModel> Containers { get; set; }
        public List<HostModel> Hosts { get; set; }
        public List<ActionModel> Actions { get; set; }
    }
}