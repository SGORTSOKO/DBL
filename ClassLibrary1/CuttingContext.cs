using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DBLib
{

    public partial class CuttingContext : DbContext
    {
        public CuttingContext()
        {
        }

        public CuttingContext(DbContextOptions<CuttingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CuttingMap> CuttingMaps { get; set; }

        public virtual DbSet<CuttingMapDetail> CuttingMapDetails { get; set; }

        public virtual DbSet<Detail> Details { get; set; }

        public virtual DbSet<Material> Materials { get; set; }

        public virtual DbSet<Sheet> Sheets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Cutting");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CuttingMap>(entity =>
            {
                entity.ToTable("CuttingMap");

                entity.Property(e => e.FullName).HasMaxLength(200);
                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.Material).WithMany(p => p.CuttingMaps)
                    .HasForeignKey(d => d.MaterialId)
                    .HasConstraintName("FK_CuttingMap_Material");

                entity.HasOne(d => d.Sheet).WithMany(p => p.CuttingMaps)
                    .HasForeignKey(d => d.SheetId)
                    .HasConstraintName("FK_CuttingMap_Sheet");
            });

            modelBuilder.Entity<CuttingMapDetail>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_CuttingMapDetail_1");

                entity.ToTable("CuttingMapDetail");

                entity.HasOne(d => d.CuttingMap).WithMany(p => p.CuttingMapDetails)
                    .HasForeignKey(d => d.CuttingMapId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CuttingMapDetail_CuttingMap");

                entity.HasOne(d => d.Detail).WithMany(p => p.CuttingMapDetails)
                    .HasForeignKey(d => d.DetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CuttingMapDetail_Detail");
            });

            modelBuilder.Entity<Detail>(entity =>
            {
                entity.ToTable("Detail");

                entity.Property(e => e.Contours).HasColumnType("image");
                entity.Property(e => e.FullName).HasMaxLength(200);
                entity.Property(e => e.Title).HasMaxLength(100);
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.ToTable("Material");

                entity.Property(e => e.FullName).HasMaxLength(200);
                entity.Property(e => e.Title).HasMaxLength(100);
            });

            modelBuilder.Entity<Sheet>(entity =>
            {
                entity.ToTable("Sheet");

                entity.Property(e => e.FullName).HasMaxLength(200);
                entity.Property(e => e.Title).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
};