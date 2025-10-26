using EfMaterialApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EfMaterialApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Material> Materials => Set<Material>();
}
