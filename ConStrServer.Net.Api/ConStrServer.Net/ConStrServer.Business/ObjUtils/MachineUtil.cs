using ConStrServer.Models.Dbo;
using ConStrServer.Models.Dto;
using System.Collections.Generic;

namespace ConStrServer.Business.ObjUtils
{
    public static class MachineUtil
    {
        public static Machine CastToDbo(MachineModel machineModel)
        {
            var connectionStrings = new List<ConnectionString>();
            if (machineModel.ConnectionStrings != null)
            {
                foreach (var conStr in machineModel.ConnectionStrings)
                {
                    connectionStrings.Add(ConnectionStringUtil.CastToDbo(conStr));
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
                ConnectionStrings = connectionStrings
            };
        }
    }
}