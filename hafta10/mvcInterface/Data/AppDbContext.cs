using Microsoft.EntityFrameworkCore;
using mvcInterface.Models;

namespace mvcInterface.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) {}

        public DbSet<Student> Students => Set<Student>();
        public DbSet<Course> Courses => Set<Course>();
    }
}
