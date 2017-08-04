using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConStrServer.Models.Dbo
{
    public class MainRequestObject
    {
        public string EnvironmentName { get; set; }

        public string MachineName { get; set; }

        public string ConnectionStringName { get; set; }

        public string ProjectName { get; set; }

    }

}
