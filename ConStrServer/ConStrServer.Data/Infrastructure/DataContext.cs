using ConStrServer.Models;
using Microsoft.EntityFrameworkCore;

namespace ConStrServer.Data.Infrastructure
{
    public class DataContext : DbContext
    {
        //public DataContext(DbContextOptions<DataContext> options)
        //    : base(options)
        //{
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
         //   optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyDatabase;Trusted_Connection=True;");
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Environment> Environments { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<ConnectionString> ConnectionStrings { get; set; }


     


        }
}