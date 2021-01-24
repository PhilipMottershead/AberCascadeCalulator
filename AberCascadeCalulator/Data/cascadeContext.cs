using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AberCascadeCalulator.Models;

namespace AberCascadeCalulator.Data
{
    public partial class cascadeContext : DbContext
    {
        public cascadeContext()
        {
        }

        public cascadeContext(DbContextOptions<cascadeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<Scheme> Schemes { get; set; }
        public virtual DbSet<SchemeModule> SchemeModules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("DataSource=cascade.db;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Module>(entity =>
            {
                entity.ToTable("module");

                entity.Property(e => e.ModuleId)
                    .HasColumnType("text")
                    .HasColumnName("module_id");

                entity.Property(e => e.Coordinator)
                    .HasColumnType("text")
                    .HasColumnName("coordinator");

                entity.Property(e => e.Credits)
                    .HasColumnType("interger")
                    .HasColumnName("credits");

                entity.Property(e => e.Department)
                    .HasColumnType("text")
                    .HasColumnName("department");

                entity.Property(e => e.Semester)
                    .HasColumnType("text")
                    .HasColumnName("semester");

                entity.Property(e => e.Title)
                    .HasColumnType("text")
                    .HasColumnName("title");

                entity.Property(e => e.Url)
                    .HasColumnType("text")
                    .HasColumnName("url");

                entity.Property(e => e.Welsh)
                    .HasColumnType("bool")
                    .HasColumnName("welsh");

                entity.Property(e => e.Year)
                    .HasColumnType("text")
                    .HasColumnName("year");
            });

            modelBuilder.Entity<Scheme>(entity =>
            {
                entity.ToTable("scheme");

                entity.Property(e => e.SchemeId)
                    .HasColumnType("text")
                    .HasColumnName("scheme_id");

                entity.Property(e => e.Award)
                    .HasColumnType("text")
                    .HasColumnName("award");

                entity.Property(e => e.Department)
                    .HasColumnType("text")
                    .HasColumnName("department");

                entity.Property(e => e.Duration)
                    .HasColumnType("interger")
                    .HasColumnName("duration");

                entity.Property(e => e.SchemeType)
                    .HasColumnType("text")
                    .HasColumnName("scheme_type");

                entity.Property(e => e.Title)
                    .HasColumnType("text")
                    .HasColumnName("title");

                entity.Property(e => e.UndergraduateOrPostgraduate)
                    .HasColumnType("text")
                    .HasColumnName("undergraduate_or_postgraduate");

                entity.Property(e => e.Url)
                    .HasColumnType("text")
                    .HasColumnName("url");

                entity.Property(e => e.Year)
                    .HasColumnType("interger")
                    .HasColumnName("year");
            });

            modelBuilder.Entity<SchemeModule>(entity =>
            {
                entity.ToTable("scheme_module");

                entity.Property(e => e.ModuleId)
                    .HasColumnType("text")
                    .HasColumnName("module_id");

                entity.Property(e => e.ModuleType)
                    .HasColumnType("text")
                    .HasColumnName("module_type");

                entity.Property(e => e.SchemeId)
                    .HasColumnType("text")
                    .HasColumnName("scheme_id");

                entity.HasOne(d => d.Module)
                    .WithMany()
                    .HasForeignKey(d => d.ModuleId);

                entity.HasOne(d => d.Scheme)
                    .WithMany()
                    .HasForeignKey(d => d.SchemeId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
