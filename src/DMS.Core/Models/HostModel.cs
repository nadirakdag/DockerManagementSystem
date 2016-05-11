using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Core.Models
{
    public class HostModel
    {
        public string HostName { get; set; }
        public string OsType { get; set; }
        public string IP { get; set; }
        public string ServerVersion { get; set; }
    }
}
