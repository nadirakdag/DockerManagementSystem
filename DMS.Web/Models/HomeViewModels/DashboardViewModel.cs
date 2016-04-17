namespace DMS.Web.Models.HomeViewModels
{
    using System.Collections.Generic;
    
    public class DashboardViewModel
    {
        public List<string> Containers { get; set; }
        public List<string> Activities { get; set; }
        public List<string> Hosts { get; set; }
        public object User{ get; set; }
        public int ContainerCount { get; set; }
        public int HostCount { get;set; }
        public int DockerImageCount { get; set; }
    }
}