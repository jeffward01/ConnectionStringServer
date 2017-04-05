using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using ConStrServer.Data.Infrastructure;
using ConStrServer.Models;

namespace ConStrServer.Data.Repositories
{
    public class ConnectionStringRepository : IConnectionStringRepository
    {
        public ConnectionStringRepository()
        {
            
        }

        public ConnectionString AddConnectionString(ConnectionString connectionString)
        {
            using (var db = new DataContext())
            {
                db.ConnectionStrings.Add(connectionString);
                db.SaveChanges();
                return connectionString;
            }
        }

        public ConnectionString EditConnectionString(ConnectionString connectionString)
        {
            using (var db = new DataContext())
            {
                db.Entry(connectionString).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return connectionString;
            }
        }


        public ConnectionString GetConnectionStringById(int connectionStringId)
        {
            using (var db = new DataContext())
            {
                return db.ConnectionStrings.FirstOrDefault(_ => _.ConnectionStringId == connectionStringId && _.DeleteDateTime == null);
            }
        }

        public List<ConnectionString> GetAllConnectionStringsForMachineId(int machineId)
        {
            using (var db = new DataContext())
            {
               return db.ConnectionStrings
                    .Where(b => b.MachineId == machineId && b.DeleteDateTime == null).ToList();
            }
        }
    }
}
