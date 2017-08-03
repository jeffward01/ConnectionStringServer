using System.Collections.Generic;
using ConStrServer.Models.Dbo;
using ConStrServer.Models.Dto;

namespace ConStrServer.Business.Managers
{
    public interface IConnectionStringManger
    {
        ConnectionString CreateConnectionString(ConnectionStringModel newConnectionString);
        ConnectionString EditConnectionString(ConnectionStringModel editConnectionString);
        ConnectionString DeleteConnectionString(int ConnectionStringId);
        ConnectionString GetConnectionStringById(int ConnectionStringId);
        List<ConnectionString> GetAllConnectionStrings();
    }
}