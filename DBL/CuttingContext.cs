using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DBLib
{

    public partial class CuttingContext : DbContext
    {
        private string server;
        public CuttingContext(string currentserver) => this.server = currentserver;

        public CuttingContext(DbContextOptions<CuttingContext> options, string currentserver)
            : base(options) => this.server = currentserver;

        public virtual DbSet<CuttingMap> CuttingMaps { get; set; }

        public virtual DbSet<CuttingMapDetail> CuttingMapDetails { get; set; }

        public virtual DbSet<Detail> Details { get; set; }

        public virtual DbSet<Material> Materials { get; set; }

        public virtual DbSet<Sheet> Sheets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(server); //Подключение к бд (аналогично: optionsBuilder.UseSqlite("Data Source=helloapp456.db");)

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
            }); //.HasCheckConstraint("Age", "Age > 0 AND Age < 120"); Ввод ограничений на передаваемое значение

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