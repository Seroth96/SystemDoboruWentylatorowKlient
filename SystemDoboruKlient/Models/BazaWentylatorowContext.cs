using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SystemDoboruKlient.Models
{
    public partial class BazaWentylatorowContext : DbContext
    {
        public BazaWentylatorowContext()
        {
        }

        public BazaWentylatorowContext(DbContextOptions<BazaWentylatorowContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Coefficients> Coefficients { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<Natures> Natures { get; set; }
        public virtual DbSet<Wentylators> Wentylators { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
             //   optionsBuilder.UseNpgsql("host=localhost;port=5432;database=BazaWentylatorow;user id=postgres;password=Test1234!xx");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coefficients>(entity =>
            {
                entity.HasIndex(e => e.WentylatorId)
                    .HasName("Coefficients_IX_Wentylator_ID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.WentylatorId).HasColumnName("Wentylator_ID");

                entity.HasOne(d => d.Wentylator)
                    .WithMany(p => p.Coefficients)
                    .HasForeignKey(d => d.WentylatorId)
                    .HasConstraintName("FK_public.Coefficients_public.Wentylators_Wentylator_ID");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey });

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.ContextKey)
                    .HasMaxLength(300)
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasDefaultValueSql("'\\x'::bytea");

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasDefaultValueSql("''::character varying");
            });

            modelBuilder.Entity<Natures>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<Wentylators>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("Wentylators_IX_Name")
                    .IsUnique();

                entity.HasIndex(e => e.NatureId)
                    .HasName("Wentylators_IX_NatureId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AirMassFlowTo).HasColumnName("AirMAssFlowTo");

                entity.HasOne(d => d.Nature)
                    .WithMany(p => p.Wentylators)
                    .HasForeignKey(d => d.NatureId)
                    .HasConstraintName("FK_public.Wentylators_public.Natures_NatureId");
            });
        }
    }
}
