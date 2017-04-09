using System;

namespace ConStrServer.Models
{
    public abstract class BaseEntity
    {
        public DateTime CreatedDateTime { get; set; }
        public DateTime ModifiDateTime { get; set; }
        public DateTime DeleteDateTime { get; set; }
    }
}