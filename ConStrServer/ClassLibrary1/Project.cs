namespace ConStrServer.Models
{
    public class Project : BaseEntity
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectOwner { get; set; }

        public int EnvironmentId { get; set; }
        public virtual Environment Environment { get; set; }
    }
}