namespace DMS.Data
{
    using Core.Entities;
    using Microsoft.Data.Entity;
    using Microsoft.Extensions.Configuration;

    public class DataContext : DbContext
    {
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Container> Containers { get; set; }
        public DbSet<ContainerImage> ContainerImages { get; set; }
        public DbSet<Host> Hosts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
           .AddJsonFile("..//..//config.json");
            var configuration = builder.Build();

            var sqlConnectionString = configuration["DataAccessSqliteProvider:ConnectionString"];

            optionsBuilder.UseSqlite(sqlConnectionString);
        }
    }
}
