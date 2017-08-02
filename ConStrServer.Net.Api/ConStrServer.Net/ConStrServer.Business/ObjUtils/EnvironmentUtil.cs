using ConStrServer.Models.Dbo;
using ConStrServer.Models.Dto;
using System.Collections.Generic;

namespace ConStrServer.Business.ObjUtils
{
    public static class EnvironmentUtil
    {
        public static EnvironmentInfo CastToDbo(EnvironmentInfoModel environmentInfoModel)
        {
            var machines = new List<Machine>();
            if (environmentInfoModel.Machines != null)
            {
                foreach (var machine in environmentInfoModel.Machines)
                {
                    machines.Add(MachineUtil.CastToDbo(machine));
                }
            }
            return new EnvironmentInfo
            {
                EnvironmentId = environmentInfoModel.EnvironmentId,
                EnvironmentName = environmentInfoModel.EnvironmentName,
                LoadBalenced = environmentInfoModel.LoadBalenced,
                Machines = machines
            };
        }
    }
}