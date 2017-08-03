using System.Collections.Generic;
using System.Linq;
using ConStrServer.Business.ObjUtils;
using ConStrServer.Data.Repositories;
using ConStrServer.Models.Dbo;
using ConStrServer.Models.Dto;

namespace ConStrServer.Business.Managers
{
    public class ProjectManager : IProjectManager
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IEnvironmentInfoRepository _environmentInfoRepository;
        public ProjectManager(IProjectRepository projectRepository, IEnvironmentInfoRepository environmentInfoRepository)
        {
            _environmentInfoRepository = environmentInfoRepository;
            _projectRepository = projectRepository;
        }

        public Project CreateProject(ProjectModel newProject)
        {
            var project = ProjectUtil.CastToDbo(newProject);
            var environmentsToAdd = project.Environments;
            project.Environments = null;
            var newlyAddedProject = _projectRepository.Create(project);
            if (environmentsToAdd != null)
            {
                foreach (var env in environmentsToAdd)
                {
                    env.ProjectId = newlyAddedProject.ProjectId;
                    _environmentInfoRepository.Create(env);
                }
            }
            return _projectRepository.GetByProjectId(newlyAddedProject.ProjectId);
        }

        public Project EditProject(ProjectModel editProject)
        {
            var project = ProjectUtil.CastToDbo(editProject);
            var environmentsToAdd = project.Environments;
            project.Environments = null;
            var updatedProject = _projectRepository.Edit(project);

            if (environmentsToAdd != null)
            {
                foreach (var env in environmentsToAdd)
                {
                    if (env.EnvironmentId != 0)
                    {
                        env.Machines = null;
                        env.ProjectId = updatedProject.ProjectId;
                        _environmentInfoRepository.Edit(env);
                    }
                    else
                    {
                        env.ProjectId = updatedProject.ProjectId;
                        _environmentInfoRepository.Create(env);
                    }

                }
            }
            //delete all deleted envinroments
            var envsToSave = environmentsToAdd.Select(_ => _.EnvironmentId);
            var allEnvIds = _environmentInfoRepository.GetAllEnvIds(updatedProject.ProjectId);
            var idsToDelete = allEnvIds.Except(envsToSave).ToList();
            foreach (var id in idsToDelete)
            {
                _environmentInfoRepository.Delete(id);
            }
          
          



            return _projectRepository.GetByProjectId(updatedProject.ProjectId);
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