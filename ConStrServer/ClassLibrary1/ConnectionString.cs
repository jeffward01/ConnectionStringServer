using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConStrServer.Models
{
    public class ConnectionString : BaseEntity
    {
        public int ConnectionStringId { get; set; }

        public int MachineId { get; set; }
        public string Name { get; set; }
        public string ConnectionStringUrl { get; set; }
    }
}
