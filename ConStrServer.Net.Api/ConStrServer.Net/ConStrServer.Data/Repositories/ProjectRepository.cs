using ConStrServer.Data.Infrastructure;
using ConStrServer.Models.Dbo;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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

        public Project GetProjectByName(MainRequestObject mainRequestObject)
        {
            using (var context = new ConStrContext())
            {
               return context.Projects
                    .Include("Environments")
                    .Include("Environments.Machines")
                    .Include("Environments.Machines.ConnectionStrings")
                    .FirstOrDefault(_ => _.ProjectName == mainRequestObject.ProjectName);
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
                return context.Projects.Include("Environments")
                    .Include("Environments.Machines")
                      .Include("Environments.Machines.ConnectionStrings").ToList();
            }
        }

        public Project GetByProjectId(int projectId)
        {
            using (var context = new ConStrContext())
            {
                return context.Projects
                    .Include("Environments")
                    .Include("Environments.Machines")
                      .Include("Environments.Machines.ConnectionStrings")
                    .FirstOrDefault(_ => _.ProjectId == projectId);
            }
        }
    }
}