﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tekus.Core.Infrastructure.DataAccess;

namespace Tekus.Core.Infrastructure.Migrations
{
    [DbContext(typeof(TekusDbContext))]
    partial class TekusDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Tekus.Core.Domain.Entities.CustomAttribute", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("Provider")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Provider");

                    b.ToTable("CustomAttribute");
                });

            modelBuilder.Entity("Tekus.Core.Domain.Entities.Provider", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nit")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Provider");
                });

            modelBuilder.Entity("Tekus.Core.Domain.Entities.Service", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreaterAt")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Value")
                        .HasColumnType("numeric(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("Tekus.Core.Domain.Entities.ServiceProvider", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("CreaterAt")
                        .HasColumnType("datetime");

                    b.Property<Guid>("Provider")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Service")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Provider");

                    b.HasIndex("Service");

                    b.ToTable("ServiceProvider");
                });

            modelBuilder.Entity("Tekus.Core.Domain.Entities.CustomAttribute", b =>
                {
                    b.HasOne("Tekus.Core.Domain.Entities.Provider", "ProviderNavigation")
                        .WithMany("CustomAttributes")
                        .HasForeignKey("Provider")
                        .HasConstraintName("FK_CustomAttribute_Provider")
                        .IsRequired();

                    b.Navigation("ProviderNavigation");
                });

            modelBuilder.Entity("Tekus.Core.Domain.Entities.ServiceProvider", b =>
                {
                    b.HasOne("Tekus.Core.Domain.Entities.Provider", "ProviderNavigation")
                        .WithMany("ServiceProviders")
                        .HasForeignKey("Provider")
                        .HasConstraintName("FK_ServiceProvider_Provider")
                        .IsRequired();

                    b.HasOne("Tekus.Core.Domain.Entities.Service", "ServiceNavigation")
                        .WithMany("ServiceProviders")
                        .HasForeignKey("Service")
                        .HasConstraintName("FK_ServiceProvider_Service")
                        .IsRequired();

                    b.Navigation("ProviderNavigation");

                    b.Navigation("ServiceNavigation");
                });

            modelBuilder.Entity("Tekus.Core.Domain.Entities.Provider", b=>
                {
                    b.Navigation("CustomAttributes");

                    b.Navigation("ServiceProviders");
                });

            modelBuilder.Entity("Tekus.Core.Domain.Entities.Service", b =>
                {
                    b.Navigation("ServiceProviders");
                });
            modelBuilder.Entity("Tekus.Core.Domain.Entities.Service", b =>
            {
                b.Navigation("ServiceProviders");
            });
#pragma warning restore 612, 618
        }
    }
}
