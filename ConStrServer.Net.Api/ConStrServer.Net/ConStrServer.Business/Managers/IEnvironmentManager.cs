using System.Collections.Generic;
using ConStrServer.Models.Dbo;
using ConStrServer.Models.Dto;

namespace ConStrServer.Business.Managers
{
    public interface IEnvironmentManager
    {
        EnvironmentInfo CreateEnvironment(EnvironmentInfoModel newEnvironment);
        EnvironmentInfo EditEnvironment(EnvironmentInfoModel editEnvironment);
        EnvironmentInfo DeleteEnvironment(int EnvironmentId);
        EnvironmentInfo GetEnvironmentById(int EnvironmentId);
        List<EnvironmentInfo> GetAllEnvironments();
    }
}