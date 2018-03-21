using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectXCore.Controllers;
using ProjectXCore.Models;

namespace ProjectXCore.Data
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Workers> Workers { get; set; }
        public DbSet<ProjectWorkers> ProjectWorkers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable("Clients");
            modelBuilder.Entity<Project>().ToTable("Projects");
            modelBuilder.Entity<Workers>().ToTable("Workers");

            //many to many relationship
            modelBuilder.Entity<ProjectWorkers>().HasKey(x => new { x.ProjectId, x.WorkerId });
            //If you name your foreign keys correctly, then you don't need this.
            modelBuilder.Entity<ProjectWorkers>()
                .HasOne(pt => pt.Project)
                .WithMany(p => p.WorkersLink)
                .HasForeignKey(pt => pt.ProjectId);

           //modelBuilder.Entity<ProjectWorkers>()
           //     .HasOne(pt => pt.Workers)
           //     .WithMany(t => t.ProjectsLink)
           //     .HasForeignKey(pt => pt.WorkerId);
        }

        public static implicit operator ProjectContext(WorkersController v)
        {
            throw new NotImplementedException();
        }
    }
}
