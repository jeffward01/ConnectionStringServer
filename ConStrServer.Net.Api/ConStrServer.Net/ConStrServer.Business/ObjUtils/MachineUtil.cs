using ConStrServer.Models.Dbo;
using ConStrServer.Models.Dto;
using System.Collections.Generic;

namespace ConStrServer.Business.ObjUtils
{
    public static class MachineUtil
    {
        public static Machine CastToDbo(MachineModel machineModel)
        {
            var projects = new List<Project>();
            if (machineModel.Projects != null)
            {
                foreach (var pro in machineModel.Projects)
                {
                    projects.Add(ProjectUtil.CastToDbo(pro));
                }
            }
            return new Machine
            {
                MachineId = machineModel.MachineId,
                EnvironmentId = machineModel.EnvironmentId,
                MachineIpAddress = machineModel.MachineIpAddress,
                MachineName = machineModel.MachineName,
                MachineNickName = machineModel.MachineNickName,
                MachinePort = machineModel.MachinePort,
                Projects = projects
            };
        }
    }
}