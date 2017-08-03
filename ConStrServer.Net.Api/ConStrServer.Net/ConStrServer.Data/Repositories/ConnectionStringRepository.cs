using ConStrServer.Data.Infrastructure;
using ConStrServer.Models.Dbo;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ConStrServer.Data.Repositories
{
    public class ConnectionStringRepository : IConnectionStringRepository
    {
        public ConnectionString Create(ConnectionString connectionString)
        {
            using (var context = new ConStrContext())
            {
                context.Entry(connectionString).State = EntityState.Added;
                context.SaveChanges();
                return connectionString;
            }
        }

        public ConnectionString Edit(ConnectionString connectionString)
        {
            using (var context = new ConStrContext())
            {
                context.Entry(connectionString).State = EntityState.Modified;
                context.SaveChanges();
                return connectionString;
            }
        }

        public ConnectionString Delete(int connectionStringId)
        {
            using (var context = new ConStrContext())
            {
                var connectionString = context.ConnectionStrings.Find(connectionStringId);
                context.Entry(connectionString).State = EntityState.Deleted;
                context.SaveChanges();
                return connectionString;
            }
        }

        public List<ConnectionString> GetAllConnectionStringsForMachineId(int machineId)
        {
            using (var context = new ConStrContext())
            {
                return context.ConnectionStrings.Where(_ => _.MachineId == machineId).ToList();
            }
        }

        public List<ConnectionString> GetAll()
        {
            using (var context = new ConStrContext())
            {
                return context.ConnectionStrings

                    .ToList();
            }
        }

        public ConnectionString GetByConnectionStringId(int connectionStringId)
        {
            using (var context = new ConStrContext())
            {
                return context.ConnectionStrings

                    .FirstOrDefault(_ => _.ConnectionStringId == connectionStringId);
            }
        }
    }
}