using ConStrServer.Data.Repositories;
using ConStrServer.Models;
using System;
using System.Collections.Generic;

namespace ConStrServer.Business.Managers
{
    public class ProjectManager : IProjectManager
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectManager(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public Project CreateProject(Project project)
        {
            project.CreatedDateTime = DateTime.Now;
            return _projectRepository.AddProject(project);
        }

        public List<Project> GetAllProjects()
        {
            //to do, add connection strings and other child data to bring back
            return _projectRepository.GetAllProjects();
        }

        public Project EditProject(Project project)
        {
            project.ModifiDateTime = DateTime.Now;

            return _projectRepository.EditProject(project);
        }

        public Project DeleteProject(int projectId)
        {
            var prjet = _projectRepository.GetProjectById(projectId);
            prjet.DeleteDateTime = DateTime.Now;
            _projectRepository.EditProject(prjet);
            return new Project();
        }
    }
}