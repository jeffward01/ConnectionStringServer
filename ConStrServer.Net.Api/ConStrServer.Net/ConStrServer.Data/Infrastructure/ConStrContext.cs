using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConStrServer.Models.Dbo;

namespace ConStrServer.Data.Infrastructure
{
    public class ConStrContext : DbContext
    {
        public ConStrContext()
            : base("ConStrContext")
        {
        }

     

        public DbSet<Project> Projects { get; set; }
        public DbSet<Environment> Environments { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<ConnectionString> ConnectionStrings { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Environment>().HasKey(_ => _.EnvironmentId);
            modelBuilder.Entity<Environment>().HasMany(_ => _.Machines)
                .WithOptional().HasForeignKey(_ => _.EnvironmentId).WillCascadeOnDelete(true);

            modelBuilder.Entity<Machine>().HasKey(_ => _.MachineId);
            modelBuilder.Entity<Machine>().HasMany(_ => _.Projects)
                .WithOptional().HasForeignKey(_ => _.MachineId).WillCascadeOnDelete(true);


            modelBuilder.Entity<Project>().HasKey(_ => _.ProjectId);
            modelBuilder.Entity<Project>().HasMany(_ => _.ConnectionStrings)
                .WithOptional().HasForeignKey(_ => _.ProjectId).WillCascadeOnDelete(true);

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
