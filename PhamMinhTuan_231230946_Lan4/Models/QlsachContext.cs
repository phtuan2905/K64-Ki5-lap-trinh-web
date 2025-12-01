using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PhamMinhTuan_231230946_Lan4.Models;

public partial class QlsachContext : DbContext
{
    public QlsachContext()
    {
    }

    public QlsachContext(DbContextOptions<QlsachContext> options)
        : base(options)
    {
    }

    public virtual DbSet<LoaiHang> LoaiHangs { get; set; }

    public virtual DbSet<Sach> Saches { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost,1433;Database=QLSach;User ID=SA;Password=Tuan446448;Trust Server Certificate=True;Authentication=SqlPassword");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LoaiHang>(entity =>
        {
            entity.HasKey(e => e.LoaiHangId).HasName("PK__LoaiHang__F5E8D84BE7030895");

            entity.ToTable("LoaiHang");

            entity.Property(e => e.LoaiHangId)
                .ValueGeneratedNever()
                .HasColumnName("LoaiHangID");
            entity.Property(e => e.TenLoai)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Sach>(entity =>
        {
            entity.HasKey(e => e.SachId).HasName("PK__Sach__F3005E3A5762870C");

            entity.ToTable("Sach");

            entity.Property(e => e.SachId)
                .ValueGeneratedNever()
                .HasColumnName("SachID");
            entity.Property(e => e.DonGia).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.LoaiHangId).HasColumnName("LoaiHangID");
            entity.Property(e => e.TenSach)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.LoaiHang).WithMany(p => p.Saches)
                .HasForeignKey(d => d.LoaiHangId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sach__LoaiHangID__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
