using System.Collections.Generic;
using ConStrServer.Models.Dbo;
using ConStrServer.Models.Dto;

namespace ConStrServer.Business.Managers
{
    public interface IProjectManager
    {
        Project CreateProject(ProjectModel newProject);
        Project EditProject(ProjectModel editProject);
        Project DeleteProject(int projectId);
        Project GetProjectById(int projectId);
        List<Project> GetAllProjects();
    }
}