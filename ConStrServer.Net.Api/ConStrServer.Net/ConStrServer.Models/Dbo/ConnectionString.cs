using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConStrServer.Models.Dbo
{
    public class ConnectionString 
    {
        public int ConnectionStringId { get; set; }

        public int? ProjectId { get; set; }

        public string ConnectionStringName { get; set; }

        public string ConnectionStringUrl { get; set; }
    }
}
