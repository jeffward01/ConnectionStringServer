using ConStrServer.Models.Dbo;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ConStrServer.Models.Dto
{
    [DataContract]
    public class EnvironmentInfoModel
    {
        [DataMember(Name = "EnvironmentId")]
        public int EnvironmentId { get; set; }

        [DataMember(Name = "EnvironmentName")]
        public int EnvironmentName { get; set; }

        [DataMember(Name = "LoadBalenced")]
        public bool LoadBalenced { get; set; }

        [DataMember(Name = "Machines")]
        public virtual List<MachineModel> Machines { get; set; }
    }
}