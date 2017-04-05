using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConStrServer.Data.Infrastructure;
using ConStrServer.Models;
using Environment = ConStrServer.Models.Environment;

namespace ConStrServer.Data.Repositories
{
   public class EnvironmetRepository
    {

        public Environment AddEnvironment(Environment environment)
        {
            using (var db = new DataContext())
            {
                db.Environments.Add(environment);
                db.SaveChanges();
                return environment;
            }
        }

        public Environment EditEnvironment(Environment environment)
        {
            using (var db = new DataContext())
            {
                db.Entry(environment).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return environment;
            }
        }

        public List<Environment> GetAllEnvironmentsForProjectId(int projectId)

        {
            using (var db = new DataContext())
            {
                return db.Environments.Where(_ => _.ProjectId == projectId && _.DeleteDateTime == null).ToList();
            }
        }



        public Environment GetEnvironmentById(int EnvironmentId)
        {
            using (var db = new DataContext())
            {
                return db.Environments.FirstOrDefault(_ => _.EnvironmentId == EnvironmentId && _.DeleteDateTime == null);
            }
        }
    }
}
