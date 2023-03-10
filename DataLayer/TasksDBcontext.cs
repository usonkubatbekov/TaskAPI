using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class TasksDBcontext : DbContext
    {
        public DbSet<TaskEntity> Tasks { get; set;}

        public DbSet<FilesPath> Files { get; set;}

        public TasksDBcontext (DbContextOptions<TasksDBcontext> options)
            : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FilesPath>()
                .HasOne(u => u.TaskEntity)
                .WithMany(c => c.FilesPaths)
                .HasForeignKey(u => u.TaskId);
        }

    }
}
