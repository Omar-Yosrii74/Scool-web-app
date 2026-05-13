using Microsoft.EntityFrameworkCore;
using MySchoolApp.Models;


namespace MySchoolApp.Data

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSets
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<StuCrsRes> StuCrsRes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<StuCrsRes>()
                .HasKey(s => new { s.StudentId, s.CourseId });

          
            modelBuilder.Entity<StuCrsRes>()
                .HasOne(s => s.Student)
                .WithMany()
                .HasForeignKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StuCrsRes>()
                .HasOne(c => c.Course)
                .WithMany()
                .HasForeignKey(c => c.CourseId)
                .OnDelete(DeleteBehavior.NoAction);

            // Seed Data 
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Computer Science", MgrName = "Dr. Ahmed" },
                new Department { Id = 2, Name = "Mathematics", MgrName = "Dr. Sara" }
            );

            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "Ali Hassan", Age = 22, DepartmentId = 1 },
                new Student { Id = 2, Name = "Mona Karim", Age = 27, DepartmentId = 1 },
                new Student { Id = 3, Name = "Omar Saad", Age = 20, DepartmentId = 2 }
            );

            modelBuilder.Entity<Teacher>()
               .HasOne(t => t.Department)
               .WithMany(d => d.Teachers)
               .HasForeignKey(t => t.DepartmentId)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Teacher>()
                .Property(t => t.Salary)
                .HasPrecision(18, 2);
        }
    }
}