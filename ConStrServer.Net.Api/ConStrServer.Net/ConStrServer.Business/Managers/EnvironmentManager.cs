using ConStrServer.Business.ObjUtils;
using ConStrServer.Data.Repositories;
using ConStrServer.Models.Dbo;
using ConStrServer.Models.Dto;
using System.Collections.Generic;

namespace ConStrServer.Business.Managers
{
    public class EnvironmentManager : IEnvironmentManager
    {
        private readonly IEnvironmentInfoRepository _EnvironmentRepository;

        public EnvironmentManager(IEnvironmentInfoRepository EnvironmentRepository)
        {
            _EnvironmentRepository = EnvironmentRepository;
        }

        public EnvironmentInfo CreateEnvironment(EnvironmentInfoModel newEnvironment)
        {
            var Environment = EnvironmentUtil.CastToDbo(newEnvironment);
            return _EnvironmentRepository.Create(Environment);
        }

        public EnvironmentInfo EditEnvironment(EnvironmentInfoModel editEnvironment)
        {
            var Environment = EnvironmentUtil.CastToDbo(editEnvironment);
            return _EnvironmentRepository.Edit(Environment);
        }

        public EnvironmentInfo DeleteEnvironment(int EnvironmentId)
        {
            return _EnvironmentRepository.Delete(EnvironmentId);
        }

        public EnvironmentInfo GetEnvironmentById(int EnvironmentId)
        {
            return _EnvironmentRepository.GetByEnvironmentInfoId(EnvironmentId);
        }

        public List<EnvironmentInfo> GetAllEnvironments()
        {
            return _EnvironmentRepository.GetAll();
        }
    }
}