using ConStrServer.Models.Dbo;
using System.Data.Entity;

namespace ConStrServer.Data.Infrastructure
{
    public class ConStrContext : DbContext
    {
        private static readonly string DatabaseName = System.Configuration.ConfigurationManager.AppSettings["DatabaseName"];

        public ConStrContext()
            : base(DatabaseName)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<EnvironmentInfo> Environments { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<ConnectionString> ConnectionStrings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EnvironmentInfo>().HasKey(_ => _.EnvironmentId);
            modelBuilder.Entity<EnvironmentInfo>().HasMany(_ => _.Machines)
                .WithOptional().HasForeignKey(_ => _.EnvironmentId).WillCascadeOnDelete(true);

            modelBuilder.Entity<Machine>().HasKey(_ => _.MachineId);
            modelBuilder.Entity<Machine>().HasMany(_ => _.ConnectionStrings)
                .WithOptional().HasForeignKey(_ => _.MachineId).WillCascadeOnDelete(true);

            modelBuilder.Entity<Project>().HasKey(_ => _.ProjectId);
            modelBuilder.Entity<Project>().HasMany(_ => _.Environments)
                .WithOptional().HasForeignKey(_ => _.ProjectId).WillCascadeOnDelete(true);

            modelBuilder.Entity<ConnectionString>().HasKey(_ => _.ConnectionStringId);

            base.OnModelCreating(modelBuilder);
        }
    }

    public class MyDbContextInitializer : DropCreateDatabaseIfModelChanges<ConStrContext>
    {
        protected override void Seed(ConStrContext dbContext)
        {
            // seed data
            base.Seed(dbContext);

            dbContext.SaveChanges();
        }
    }
}