using ConStrServer.Business.ObjUtils;
using ConStrServer.Data.Repositories;
using ConStrServer.Models.Dbo;
using ConStrServer.Models.Dto;
using System.Collections.Generic;

namespace ConStrServer.Business.Managers
{
    public class ConnectionStringManger : IConnectionStringManger
    {
        private readonly IConnectionStringRepository _ConnectionStringRepository;

        public ConnectionStringManger(IConnectionStringRepository ConnectionStringRepository)
        {
            _ConnectionStringRepository = ConnectionStringRepository;
        }

        public ConnectionString CreateConnectionString(ConnectionStringModel newConnectionString)
        {
            var ConnectionString = ConnectionStringUtil.CastToDbo(newConnectionString);
            return _ConnectionStringRepository.Create(ConnectionString);
        }

        public ConnectionString EditConnectionString(ConnectionStringModel editConnectionString)
        {
            var ConnectionString = ConnectionStringUtil.CastToDbo(editConnectionString);
            return _ConnectionStringRepository.Edit(ConnectionString);
        }

        public ConnectionString DeleteConnectionString(int ConnectionStringId)
        {
            return _ConnectionStringRepository.Delete(ConnectionStringId);
        }

        public ConnectionString GetConnectionStringById(int ConnectionStringId)
        {
            return _ConnectionStringRepository.GetByConnectionStringId(ConnectionStringId);
        }

        public List<ConnectionString> GetAllConnectionStrings()
        {
            return _ConnectionStringRepository.GetAll();
        }
    }
}