using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectXCore.Models
{
    public class ProjectWorkers
    {
        public int ProjectId { get; set; }
        public int WorkerId { get; set; }

        public Project Project { get; set; }
        public Workers Worker { get; set; }
    }
}
