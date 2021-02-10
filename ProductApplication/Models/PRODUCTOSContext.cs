using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ProductApplication.Models
{
    public partial class PRODUCTOSContext : DbContext
    {
        public PRODUCTOSContext()
        {
        }

        public PRODUCTOSContext(DbContextOptions<PRODUCTOSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCondition> ProductConditions { get; set; }
        public virtual DbSet<ProductStatus> ProductStatuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=PRODUCTOS;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProdId)
                    .HasName("PK__PRODUCT__56958AB2F708DB90");

                entity.ToTable("PRODUCT");

                entity.Property(e => e.ProdId).HasColumnName("prod_id");

                entity.Property(e => e.ProdCondition).HasColumnName("prod_condition");

                entity.Property(e => e.ProdName)
                    .HasMaxLength(255)
                    .HasColumnName("prod_name");

                entity.Property(e => e.ProdStatus).HasColumnName("prod_status");
            });

            modelBuilder.Entity<ProductCondition>(entity =>
            {
                entity.HasKey(e => e.CondId)
                    .HasName("PK__PRODUCT___20AF6E2A6B08C683");

                entity.ToTable("PRODUCT_CONDITION");

                entity.Property(e => e.CondId)
                    .ValueGeneratedNever()
                    .HasColumnName("cond_id");

                entity.Property(e => e.CondName)
                    .HasMaxLength(255)
                    .HasColumnName("cond_name");
            });

            modelBuilder.Entity<ProductStatus>(entity =>
            {
                entity.HasKey(e => e.CondId)
                    .HasName("PK__PRODUCT___20AF6E2AA0F42269");

                entity.ToTable("PRODUCT_STATUS");

                entity.Property(e => e.CondId)
                    .ValueGeneratedNever()
                    .HasColumnName("cond_id");

                entity.Property(e => e.CondName)
                    .HasMaxLength(255)
                    .HasColumnName("cond_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
