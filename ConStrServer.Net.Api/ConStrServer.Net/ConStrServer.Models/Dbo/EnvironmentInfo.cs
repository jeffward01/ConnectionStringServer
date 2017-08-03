using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConStrServer.Models.Dbo
{
    public class EnvironmentInfo 
    {
        public int EnvironmentId { get; set; }
        public int ProjectId { get; set; }

        public string EnvironmentName { get; set; }
        public bool LoadBalenced { get; set; }

        public virtual List<Machine> Machines { get; set; }
    }
}
