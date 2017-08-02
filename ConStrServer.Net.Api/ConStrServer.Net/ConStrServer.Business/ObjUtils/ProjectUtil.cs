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
            List<ConnectionString> connectionStrings = new List<ConnectionString>();
            if (projectModel.ConnectionStrings != null)
            {
                foreach (var conStr in projectModel.ConnectionStrings)
                {
                    connectionStrings.Add(ConnectionStringUtil.CastToDbo(conStr));
                }
            }
            return new Project
            {
                MachineId = projectModel.MachineId,
                ProjectId = projectModel.ProjectId,
                ProjectName = projectModel.ProjectName,
                ProjectOwner = projectModel.ProjectOwner,
                ConnectionStrings = connectionStrings
            };
        }
    }
}
