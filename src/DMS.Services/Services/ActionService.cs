using DMS.Core.Models;
using DMS.Core.ServiceInterfaces;
using DMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Services.Services
{
    public class ActionService : IActionService
    {
        private DataContext _context;
        public ActionService(DataContext context)
        {
            _context = context;
        }

        public List<ActionModel> GetActions(int take = 5)
        {
            return _context.Activities.Take(take).OrderByDescending(x=>x.HappendDate).Select(x => new ActionModel() { Message = x.Description, ActionDate = x.HappendDate }).ToList();
        }
    }
}
