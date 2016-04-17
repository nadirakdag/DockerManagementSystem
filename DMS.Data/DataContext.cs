using System.Collections.Generic;
using System.IO;
using Microsoft.Data.Entity;
using Microsoft.Extensions.PlatformAbstractions;
using DMS.Core.Entities;
    
namespace DMS.Data
{
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
            var path = PlatformServices.Default.Application.ApplicationBasePath;
            optionsBuilder.UseSqlite("Filename=" + Path.Combine(path, "dms.db"));
        }
    }
}