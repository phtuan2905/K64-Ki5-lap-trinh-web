using System.Data;
using LTW_Day08Lab_StudentManager.Models;
using Microsoft.EntityFrameworkCore;

namespace LTW_Day08Lab_StudentManager.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<StdClass> StdClasses { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Subjects> Subjects { get; set; }

        public DbSet<Marks> Marks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Marks>()
        .   HasKey(pw => new { pw.SubjectId, pw.StudentId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
