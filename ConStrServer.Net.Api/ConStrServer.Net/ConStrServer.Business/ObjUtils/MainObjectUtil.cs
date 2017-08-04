using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConStrServer.Models.Dbo;
using ConStrServer.Models.Dto;

namespace ConStrServer.Business.ObjUtils
{
    public static class MainObjectUtil
    {
        public static MainRequestObject CastToDbo(MainRequestObjectModel mainRequestObjectModel)
        {
            return new MainRequestObject
            {
                ConnectionStringName = mainRequestObjectModel.ConnectionStringName,
                EnvironmentName = mainRequestObjectModel.EnvironmentName,
                MachineName = mainRequestObjectModel.MachineName,
                ProjectName = mainRequestObjectModel.ProjectName
            };
        }
    }
}
