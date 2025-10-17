using Microsoft.EntityFrameworkCore;

namespace LTW_Day09Lab_CodeFirst.Models
{
    public class TvcDay09LabCFContext : DbContext
    {
        public TvcDay09LabCFContext(DbContextOptions<TvcDay09LabCFContext> options) : base(options) { }

        public DbSet<TvcSanPham> tvcSanPhams { get; set; }

        public DbSet<TvcLoaiSanPham> tvcLoaiSanPhams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TvcSanPham>()
                .HasOne(sp => sp.TvcLoaiSanPham)
                .WithMany(loai => loai.tvcSanPhams)
                .HasForeignKey(sp => sp.tvcLoaiSanPhamID)
                .IsRequired(false);
        }
    }
}
