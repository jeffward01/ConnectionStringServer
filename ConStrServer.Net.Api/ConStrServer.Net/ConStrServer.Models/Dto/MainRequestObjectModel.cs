using System.Runtime.Serialization;

namespace ConStrServer.Models.Dto
{
    [DataContract]
    public class MainRequestObjectModel
    {
        [DataMember(Name = "EnvironmentName")]
        public string EnvironmentName { get; set; }

        [DataMember(Name = "MachineName")]
        public string MachineName { get; set; }

        [DataMember(Name = "ConnectionStringName")]
        public string ConnectionStringName { get; set; }

        [DataMember(Name = "ProjectName")]
        public string ProjectName { get; set; }
    }
}