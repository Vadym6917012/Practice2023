﻿// <auto-generated />
using System;
using AutomobileCatalog.Server.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AutomobileCatalog.Server.Core.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230126154034_Test")]
    partial class Test
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AutomobileCatalog.Server.Core.Make", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Makes");
                });

            modelBuilder.Entity("AutomobileCatalog.Server.Core.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("MakeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VehicleColorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MakeId");

                    b.HasIndex("VehicleColorId");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("AutomobileCatalog.Server.Core.Price", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("InitialPriceDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId")
                        .IsUnique();

                    b.ToTable("Prices");
                });

            modelBuilder.Entity("AutomobileCatalog.Server.Core.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("EngineCapacity")
                        .HasColumnType("float");

                    b.Property<int?>("VehicleModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehicleModelId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("AutomobileCatalog.Server.Core.VehicleColor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VehicleColors");
                });

            modelBuilder.Entity("AutomobileCatalog.Server.Core.Model", b =>
                {
                    b.HasOne("AutomobileCatalog.Server.Core.Make", "Make")
                        .WithMany("Models")
                        .HasForeignKey("MakeId");

                    b.HasOne("AutomobileCatalog.Server.Core.VehicleColor", "VehicleColor")
                        .WithMany("Models")
                        .HasForeignKey("VehicleColorId");

                    b.Navigation("Make");

                    b.Navigation("VehicleColor");
                });

            modelBuilder.Entity("AutomobileCatalog.Server.Core.Price", b =>
                {
                    b.HasOne("AutomobileCatalog.Server.Core.Vehicle", "Vehicle")
                        .WithOne("Price")
                        .HasForeignKey("AutomobileCatalog.Server.Core.Price", "VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("AutomobileCatalog.Server.Core.Vehicle", b =>
                {
                    b.HasOne("AutomobileCatalog.Server.Core.Model", "VehicleModel")
                        .WithMany("Vehicles")
                        .HasForeignKey("VehicleModelId");

                    b.Navigation("VehicleModel");
                });

            modelBuilder.Entity("AutomobileCatalog.Server.Core.Make", b =>
                {
                    b.Navigation("Models");
                });

            modelBuilder.Entity("AutomobileCatalog.Server.Core.Model", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("AutomobileCatalog.Server.Core.Vehicle", b =>
                {
                    b.Navigation("Price");
                });

            modelBuilder.Entity("AutomobileCatalog.Server.Core.VehicleColor", b =>
                {
                    b.Navigation("Models");
                });
#pragma warning restore 612, 618
        }
    }
}
