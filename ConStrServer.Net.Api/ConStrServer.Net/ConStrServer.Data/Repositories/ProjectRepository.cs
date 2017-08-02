using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConStrServer.Data.Infrastructure;
using ConStrServer.Models.Dbo;

namespace ConStrServer.Data.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        public Project Create(Project project)
        {
            using (var context = new ConStrContext())
            {
                context.Entry(project).State = EntityState.Added;
                context.SaveChanges();
                return project;
            }
        }
        public Project Edit(Project project)
        {
            using (var context = new ConStrContext())
            {
                context.Entry(project).State = EntityState.Modified;
                context.SaveChanges();
                return project;
            }
        }
        public Project Delete(int projectId)
        {
            using (var context = new ConStrContext())
            {
                var project = context.Projects.Find(projectId);
                context.Entry(project).State = EntityState.Deleted;
                context.SaveChanges();
                return project;
            }
        }

        public List<Project> GetAll()
        {
            using (var context = new ConStrContext())
            {
                return context.Projects.Include("ConnectionStrings").ToList();
            }
        }

        public Project GetByProjectId(int projectId)
        {
            using (var context = new ConStrContext())
            {
                return context.Projects.Include("ConnectionStrings").FirstOrDefault(_ => _.ProjectId == projectId);
            }
        }

        public List<Project> GetAllProjectsByMachineId(int machineid)
        {
            using (var context = new ConStrContext())
            {
                return context.Projects.Include("ConnectionStrings").Where(_ => _.MachineId == machineid).ToList(); 
            }
        }
    }
}
