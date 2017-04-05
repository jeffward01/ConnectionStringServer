using System.Collections.Generic;
using ConStrServer.Models;

namespace ConStrServer.Data.Repositories
{
    public interface IConnectionStringRepository
    {
        ConnectionString AddConnectionString(ConnectionString connectionString);
        ConnectionString EditConnectionString(ConnectionString connectionString);
        ConnectionString GetConnectionStringById(int connectionStringId);
        List<ConnectionString> GetAllConnectionStringsForMachineId(int machineId);
    }
}