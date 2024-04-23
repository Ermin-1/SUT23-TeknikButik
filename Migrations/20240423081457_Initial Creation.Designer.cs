﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SUT23_TeknikButik.Data;

#nullable disable

namespace SUT23_TeknikButik.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240423081457_Initial Creation")]
    partial class InitialCreation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SUT23_TeknikButikModels.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            Adress = "Horseshoeroad 2",
                            Email = "Ermin.husic@hotmail.com",
                            FirstName = "Ermin",
                            LastName = "Husic",
                            Phone = "07777777777"
                        },
                        new
                        {
                            CustomerId = 2,
                            Adress = "Blacksheeproad 44",
                            Email = "oskar.johansson@hotmail.com",
                            FirstName = "Oskar",
                            LastName = "Johansson",
                            Phone = "077333333"
                        });
                });

            modelBuilder.Entity("SUT23_TeknikButikModels.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderPlaced")
                        .HasColumnType("datetime2");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            CustomerId = 1,
                            OrderPlaced = new DateTime(2021, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            OrderId = 2,
                            CustomerId = 2,
                            OrderPlaced = new DateTime(2023, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            OrderId = 3,
                            CustomerId = 2,
                            OrderPlaced = new DateTime(2020, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("SUT23_TeknikButikModels.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Category = 0,
                            Price = 8500.00m,
                            ProductName = "Iphone 13"
                        },
                        new
                        {
                            ProductId = 2,
                            Category = 0,
                            Price = 10000.00m,
                            ProductName = "Samsung 14"
                        },
                        new
                        {
                            ProductId = 3,
                            Category = 1,
                            Price = 20000.00m,
                            ProductName = "Asus Rog"
                        });
                });

            modelBuilder.Entity("SUT23_TeknikButikModels.Order", b =>
                {
                    b.HasOne("SUT23_TeknikButikModels.Customer", "Customer")
                        .WithMany("Order")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("SUT23_TeknikButikModels.Customer", b =>
                {
                    b.Navigation("Order");
                });
#pragma warning restore 612, 618
        }
    }
}
