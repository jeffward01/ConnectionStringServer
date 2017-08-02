using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConStrServer.Models.Dbo;
using ConStrServer.Models.Dto;

namespace ConStrServer.Business.ObjUtils
{
    public static class ConnectionStringUtil
    {
        public static ConnectionString CastToDbo(ConnectionStringModel connectionStringModel)
        {
            return new ConnectionString
            {
                ConnectionStringId = connectionStringModel.ConnectionStringId,
                ConnectionStringName = connectionStringModel.ConnectionStringName,
                ConnectionStringUrl = connectionStringModel.ConnectionStringUrl
            };
        }
    }
}
