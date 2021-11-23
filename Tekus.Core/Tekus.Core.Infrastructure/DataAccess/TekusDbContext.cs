using Microsoft.EntityFrameworkCore;
using Tekus.Core.Domain.Entities;

namespace Tekus.Core.Infrastructure.DataAccess
{
    public class TekusDbContext : DbContext
    {

        public TekusDbContext(DbContextOptions<TekusDbContext> options)
    : base(options)
        { }

        public virtual DbSet<CustomAttribute> CustomAttributes { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<ServiceProvider> ServiceProviders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Service");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreaterAt).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Value).HasColumnType("numeric(18, 2)");
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.ToTable("Provider");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Nit)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ServiceProvider>(entity =>
            {
                entity.ToTable("ServiceProvider");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.CreaterAt).HasColumnType("datetime");

                entity.HasOne(d => d.ProviderNavigation)
                    .WithMany(p => p.ServiceProviders)
                    .HasForeignKey(d => d.Provider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceProvider_Provider");

                entity.HasOne(d => d.ServiceNavigation)
                    .WithMany(p => p.ServiceProviders)
                    .HasForeignKey(d => d.Service)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceProvider_Service");
            });

            modelBuilder.Entity<CustomAttribute>(entity =>
            {
                entity.ToTable("CustomAttribute");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Value).IsRequired();

                entity.HasOne(d => d.ProviderNavigation)
                    .WithMany(p => p.CustomAttributes)
                    .HasForeignKey(d => d.Provider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomAttribute_Provider");
            });
        }

    }
}
