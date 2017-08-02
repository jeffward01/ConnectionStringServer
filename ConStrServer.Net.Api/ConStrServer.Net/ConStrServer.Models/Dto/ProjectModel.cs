using ConStrServer.Models.Dbo;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ConStrServer.Models.Dto
{
    [DataContract]
    public class ProjectModel
    {
        [DataMember(Name = "ProjectId")]
        public int ProjectId { get; set; }

        [DataMember(Name = "ProjectName")]
        public string ProjectName { get; set; }

        [DataMember(Name = "ProjectOwner")]
        public string ProjectOwner { get; set; }

        [DataMember(Name = "MachineId")]
        public int MachineId { get; set; }

        [DataMember(Name = "ConnectionStrings")]
        public virtual List<ConnectionStringModel> ConnectionStrings { get; set; }
    }
}