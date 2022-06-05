using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MvcTutorialEF.Models
{
    public partial class HomeworkDBContext : DbContext
    {
        public HomeworkDBContext()
        {
        }

        public HomeworkDBContext(DbContextOptions<HomeworkDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Food> Foods { get; set; } = null!;
        public virtual DbSet<TblFood> TblFoods { get; set; } = null!;
        public virtual DbSet<TblHero> TblHeroes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Food>(entity =>
            {
                entity.Property(e => e.Comment).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Style).HasMaxLength(50);
            });

            modelBuilder.Entity<TblFood>(entity =>
            {
                entity.ToTable("TblFood");

                entity.Property(e => e.Comment).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Style).HasMaxLength(50);
            });

            modelBuilder.Entity<TblHero>(entity =>
            {
                entity.ToTable("TblHero");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
