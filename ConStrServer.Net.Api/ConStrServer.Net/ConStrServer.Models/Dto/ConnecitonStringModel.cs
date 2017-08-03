using System.Runtime.Serialization;

namespace ConStrServer.Models.Dto
{
    [DataContract]
    public class ConnectionStringModel
    {
        [DataMember]
        public int ConnectionStringId { get; set; }

        [DataMember(Name = "MachineId")]
        public int? MachineId { get; set; }

        [DataMember(Name = "ConnectionStringName")]
        public string ConnectionStringName { get; set; }

        [DataMember(Name = "ConnectionStringUrl")]
        public string ConnectionStringUrl { get; set; }
    }
}