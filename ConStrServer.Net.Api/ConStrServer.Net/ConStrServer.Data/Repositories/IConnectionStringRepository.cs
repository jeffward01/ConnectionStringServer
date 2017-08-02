using System.Collections.Generic;
using ConStrServer.Models.Dbo;

namespace ConStrServer.Data.Repositories
{
    public interface IConnectionStringRepository
    {
        ConnectionString Create(ConnectionString connectionString);
        ConnectionString Edit(ConnectionString connectionString);
        ConnectionString Delete(int connectionStringId);
        List<ConnectionString> GetAllConnectionStringsForProjectId(int projectId);
        List<ConnectionString> GetAll();
        ConnectionString GetByConnectionStringId(int connectionStringId);
    }
}