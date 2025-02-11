using Microsoft.EntityFrameworkCore;

namespace UnivercityDepartment.Models
{
    public class UnivercityContext : DbContext
    {
        public UnivercityContext(DbContextOptions<UnivercityContext> options) : base(options)
        {
        }

        // DbSet для кожної з сутностей
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }

        // Метод для налаштування зв'язків між таблицями
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Зв'язок Faculty -> Departments (Один до багатьох)
            modelBuilder.Entity<Faculty>()
                .HasMany(f => f.Departments)
                .WithOne(d => d.Faculty)
                .HasForeignKey(d => d.FacultyId)
                .OnDelete(DeleteBehavior.Cascade);  // Видалення факультету автоматично видаляє департаменти

            // Зв'язок Faculty -> Teachers (Один до багатьох)
            modelBuilder.Entity<Faculty>()
                .HasMany(f => f.Teachers)
                .WithOne(t => t.Faculty)
                .HasForeignKey(t => t.FacultyId)
                .OnDelete(DeleteBehavior.Cascade);  // Видалення факультету автоматично видаляє викладачів

            // Зв'язок Faculty -> Students (Один до багатьох)
            modelBuilder.Entity<Faculty>()
                .HasMany(f => f.Students)
                .WithOne(s => s.Faculty)
                .HasForeignKey(s => s.FacultyId)
                .OnDelete(DeleteBehavior.Restrict);  // Використання Restrict для захисту від видалення факультету, якщо є студенти

            // Зв'язок Department -> Teachers (Один до багатьох)
            modelBuilder.Entity<Department>()
                .HasMany(d => d.Teachers)
                .WithOne(t => t.Department)
                .HasForeignKey(t => t.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);  // Використання Restrict для захисту від видалення департаменту, якщо є викладачі

            // Зв'язок Department -> Students (Один до багатьох)
            modelBuilder.Entity<Department>()
                .HasMany(d => d.Students)
                .WithOne(s => s.Department)
                .HasForeignKey(s => s.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);  // Використання Restrict для захисту від видалення департаменту, якщо є студенти
        }
    }
}

