using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConStrServer.Models.Dbo
{
    public class Project 
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectOwner { get; set; }
        public virtual List<EnvironmentInfo> Environments { get; set; }

    }
}
