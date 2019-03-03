using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace IssueLog.Models
{
    public class IssueLogDbContext : DbContext
    {
        public IssueLogDbContext() : base("IssueLogDbContext")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Issue> Issues { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                        .HasRequired(m => m.ProjectManager)
                        .WithMany(t => t.ProjectManager)
                        .HasForeignKey(m => m.ProjectManagerId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                        .HasRequired(m => m.Client)
                        .WithMany(t => t.Client)
                        .HasForeignKey(m => m.ClientId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                     .HasRequired(m => m.ProjectLeader)
                     .WithMany(t => t.ProjectLeader)
                     .HasForeignKey(m => m.ProjectLeaderId)
                     .WillCascadeOnDelete(false);

            modelBuilder.Entity<Issue>()
                  .HasRequired(m => m.Project)
                  .WithMany(t => t.Issues)
                  .HasForeignKey(m => m.ProjectId)
                  .WillCascadeOnDelete(false);
        }


    }

}