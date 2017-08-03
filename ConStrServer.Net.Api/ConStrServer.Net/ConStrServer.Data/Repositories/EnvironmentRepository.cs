using ConStrServer.Data.Infrastructure;
using ConStrServer.Models.Dbo;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ConStrServer.Data.Repositories
{
    public class EnvironmentInfoRepository : IEnvironmentInfoRepository
    {
        public EnvironmentInfo Create(EnvironmentInfo environmentInfo)
        {
            using (var context = new ConStrContext())
            {
                context.Entry(environmentInfo).State = EntityState.Added;
                context.SaveChanges();
                return environmentInfo;
            }
        }

        public EnvironmentInfo Edit(EnvironmentInfo environmentInfo)
        {
            using (var context = new ConStrContext())
            {
                context.Entry(environmentInfo).State = EntityState.Modified;
                context.SaveChanges();
                return environmentInfo;
            }
        }

        public EnvironmentInfo Delete(int environmentInfoId)
        {
            using (var context = new ConStrContext())
            {
                var environmentInfo = context.Environments.Find(environmentInfoId);
                context.Entry(environmentInfo).State = EntityState.Deleted;
                context.SaveChanges();
                return environmentInfo;
            }
        }

        public List<EnvironmentInfo> GetAll()
        {
            using (var context = new ConStrContext())
            {
                return context.Environments
                    .Include("Machines")
                    .Include("Machines.Projects")
                    .Include("Machines.Projects.ConnectionStrings")
                    .ToList();
            }
        }


        public List<int> GetAllEnvIds(int projectId)
        {
            using (var context = new ConStrContext())
            {
                return context.Environments.Where(_ => _.ProjectId == projectId).Select(_ => _.EnvironmentId)
                    .ToList();
            }
        }

        public EnvironmentInfo GetByEnvironmentInfoId(int EnvironmentInfoId)
        {
            using (var context = new ConStrContext())
            {
                return context.Environments
                            .Include("Machines")
                    .Include("Machines.Projects")
                    .Include("Machines.Projects.ConnectionStrings")
                    .FirstOrDefault(_ => _.EnvironmentId == EnvironmentInfoId);
            }
        }
    }
}