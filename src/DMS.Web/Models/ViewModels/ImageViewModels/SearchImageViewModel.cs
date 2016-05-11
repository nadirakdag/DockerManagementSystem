using DMS.Core.Models;
using DMS.Web.Models.ViewModels.UserViewModels;
using Microsoft.AspNet.Mvc.Rendering;
using System.Collections.Generic;

namespace DMS.Web.Models.ViewModels.ImageViewModels
{
    public class SearchImageViewModel : BaseViewModel
    {
        public string SearchTerm { get; set; }
        public string HostId { get; set; }

        public List<SelectListItemModel> Hosts { get; set; }
        public List<ImageSearchResult> SearchResults { get; set; }
    }
}
