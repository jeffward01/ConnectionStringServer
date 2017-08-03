using System.Collections.Generic;
using ConStrServer.Business.ObjUtils;
using ConStrServer.Data.Repositories;
using ConStrServer.Models.Dbo;
using ConStrServer.Models.Dto;

namespace ConStrServer.Business.Managers
{
    public class ProjectManager : IProjectManager
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

        public Project EditProject(ProjectModel editProject)
        {
            var project = ProjectUtil.CastToDbo(editProject);
            return _projectRepository.Edit(project);
        }

        public Project DeleteProject(int projectId)
        {
            return _projectRepository.Delete(projectId);
        }

        public Project GetProjectById(int projectId)
        {
            return _projectRepository.GetByProjectId(projectId);
        }

        public List<Project> GetAllProjects()
        {
            return _projectRepository.GetAll();
        }



    }
}