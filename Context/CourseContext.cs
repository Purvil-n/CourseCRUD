using CourseCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseCRUD.Context
{
    public class CourseContext : DbContext
    {
        public CourseContext(DbContextOptions<CourseContext> options) : base(options) { }
        public DbSet<CourseEntity> Courses { get; set; }
    }
}
