using DMS.Core.Models;
using System.Collections.Generic;

namespace DMS.Core.ServiceInterfaces
{
    public interface IActionService
    {
        List<ActionModel> GetActions(int take = 5);
    }
}
