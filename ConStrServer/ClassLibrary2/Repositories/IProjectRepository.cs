using System.Collections.Generic;
using ConStrServer.Models;

namespace ConStrServer.Data.Repositories
{
    public interface IProjectRepository
    {
        Project AddProject(Project Project);
        Project EditProject(Project Project);
        Project GetProjectById(int ProjectId);
        List<Project> GetAllProjects();
    }
}