using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConStrServer.Data.Infrastructure;
using ConStrServer.Models;

namespace ConStrServer.Data.Repositories
{
    public class ProjectRepository
    {
        public Project AddProject(Project Project)
        {
            using (var db = new DataContext())
            {
                db.Projects.Add(Project);
                db.SaveChanges();
                return Project;
            }
        }

        public Project EditProject(Project Project)
        {
            using (var db = new DataContext())
            {
                db.Entry(Project).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return Project;
            }
        }


        public Project GetProjectById(int ProjectId)
        {
            using (var db = new DataContext())
            {
                return db.Projects.FirstOrDefault(_ => _.ProjectId == ProjectId && _.DeleteDateTime == null);
            }
        }

        public List<Project> GetAllProjects()
        {
            using (var db = new DataContext())
            {
                return db.Projects
                     .Where(b => b.DeleteDateTime == null).ToList();
            }
        }
    }
}
