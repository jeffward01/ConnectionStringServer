using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConStrServer.Models.Dbo;
using ConStrServer.Models.Dto;

namespace ConStrServer.Business.ObjUtils
{
    public static class ProjectUtil
    {
        public static Project CastToDbo(ProjectModel projectModel)
        {
            List<EnvironmentInfo> environtments = new List<EnvironmentInfo>();

            if (projectModel.Environments != null)
            {
                foreach (var conStr in projectModel.Environments)
                {
                    environtments.Add(EnvironmentUtil.CastToDbo(conStr));
                }
            }
            return new Project
            {
                ProjectId = projectModel.ProjectId,
                ProjectName = projectModel.ProjectName,
                ProjectOwner = projectModel.ProjectOwner,
                Environments = environtments
            };
        }
    }
}
