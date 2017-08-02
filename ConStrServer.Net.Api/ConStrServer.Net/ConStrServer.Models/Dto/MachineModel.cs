using ConStrServer.Models.Dbo;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ConStrServer.Models.Dto
{
    [DataContract]
    public class MachineModel
    {
        [DataMember(Name = "MachineId")]
        public int MachineId { get; set; }

        [DataMember(Name = "EnvironmentId")]
        public int EnvironmentId { get; set; }

        [DataMember(Name = "MachineNickName")]
        public string MachineNickName { get; set; }

        [DataMember(Name = "MachineName")]
        public string MachineName { get; set; }

        [DataMember(Name = "MachineIpAddress")]
        public string MachineIpAddress { get; set; }

        [DataMember(Name = "MachinePort")]
        public int MachinePort { get; set; }

        [DataMember(Name = "Projects")]
        public virtual List<ProjectModel> Projects { get; set; }
    }
}