using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConStrServer.Models.Dbo
{
    public class Machine 
    {
        public int MachineId { get; set; }
        public int EnvironmentId { get; set; }
        public string MachineNickName { get; set; }
        public string MachineName { get; set; }
        public string MachineIpAddress { get; set; }
        public int MachinePort { get; set; }

        public virtual List<Project> Projects { get; set; }

    }
}
