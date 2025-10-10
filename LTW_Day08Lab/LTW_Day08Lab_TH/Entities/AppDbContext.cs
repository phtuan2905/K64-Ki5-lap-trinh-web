using LTW_Day08Lab_TH.Models;
using Microsoft.EntityFrameworkCore;

namespace LTW_Day08Lab_TH.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<LTW_Day08Lab_TH.Models.Banner> Banner { get; set; } = default!;

    }
}
