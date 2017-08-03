using ConStrServer.Business.ObjUtils;
using ConStrServer.Data.Repositories;
using ConStrServer.Models.Dbo;
using ConStrServer.Models.Dto;

namespace ConStrServer.Business.Managers
{
    public class ProjectManager
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectManager(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public Project CreateProject(ProjectModel newProject)
        {
            var project = ProjectUtil.CastToDbo(newProject);
            return _projectRepository.Create(project);
        }
    }
}