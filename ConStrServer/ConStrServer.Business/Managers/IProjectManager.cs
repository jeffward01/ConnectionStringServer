using System.Collections.Generic;
using ConStrServer.Models;

namespace ConStrServer.Business.Managers
{
    public interface IProjectManager
    {
        Project CreateProject(Project project);
        List<Project> GetAllProjects();
        Project EditProject(Project project);
        Project DeleteProject(int projectId);
    }
}