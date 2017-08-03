using System.Collections.Generic;
using ConStrServer.Models.Dbo;

namespace ConStrServer.Data.Repositories
{
    public interface IEnvironmentInfoRepository
    {
        List<int> GetAllEnvIds(int projectId);
        EnvironmentInfo Create(EnvironmentInfo environmentInfo);
        EnvironmentInfo Edit(EnvironmentInfo environmentInfo);
        EnvironmentInfo Delete(int environmentInfoId);
        List<EnvironmentInfo> GetAll();
        EnvironmentInfo GetByEnvironmentInfoId(int EnvironmentInfoId);
    }
}