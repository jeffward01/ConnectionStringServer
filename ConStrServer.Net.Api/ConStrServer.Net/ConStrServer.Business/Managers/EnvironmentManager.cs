using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConStrServer.Business.ObjUtils;
using ConStrServer.Models.Dbo;
using ConStrServer.Models.Dto;

namespace ConStrServer.Business.Managers
{
    public class EnvironmentManager
    {
        public EnvironmentManager()
        {
            
        }

        public EnvironmentInfo CreateEnvironment(EnvironmentInfoModel environmentInfo)
        {
            var environment = EnvironmentUtil.CastToDbo(environmentInfo);
            var machines = new List<Machine>();
            if (environment.Machines != null)
            {
                machines = environment.Machines;
            }



            environment.Machines = null;

            



        }
    }
}
