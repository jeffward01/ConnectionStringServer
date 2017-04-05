using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConStrServer.Models
{
    public class Environment : BaseEntity
    {
        public int EnvironmentId { get; set; }
        public int ProjectId { get; set; }
        public int EnvironmentName { get; set; }
        public bool LoadBalenced { get; set; }

        public virtual List<Machine> Machines { get; set; }
    }
}
