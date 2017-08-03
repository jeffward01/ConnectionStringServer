using System.Collections.Generic;
using ConStrServer.Models.Dbo;

namespace ConStrServer.Data.Repositories
{
    public interface IProjectRepository
    {
        Project Create(Project project);
        Project Edit(Project project);
        Project Delete(int projectId);
        List<Project> GetAll();
        Project GetByProjectId(int projectId);
    }
}