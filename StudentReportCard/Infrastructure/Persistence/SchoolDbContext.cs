using Microsoft.EntityFrameworkCore;
using StudentReportCard.Domain.Entities;
using System.Collections.Generic;
using System.Security.Claims;

namespace StudentReportCard.Infrastructure.Persistence
{
    public interface ISchoolDbContext
    {
        DbSet<Student> Students { get; }
        DbSet<StudentClass> Classes { get; }
        DbSet<Subject> Subjects { get; }
        DbSet<Exam> Exams { get; }
        DbSet<Mark> Marks { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }

    public class SchoolDbContext : DbContext, ISchoolDbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }

        public DbSet<Student> Students => Set<Student>();
        public DbSet<StudentClass> Classes => Set<StudentClass>();
        public DbSet<Subject> Subjects => Set<Subject>();
        public DbSet<Exam> Exams => Set<Exam>();
        public DbSet<Mark> Marks => Set<Mark>();
    }

}
