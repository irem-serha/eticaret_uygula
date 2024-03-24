﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eticaret_uygula.Data;

#nullable disable

namespace eticaret_uygula.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240311183921_mig")]
    partial class mig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("eticaret_uygula.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("eticaret_uygula.Models.Products", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductCode")
                        .HasColumnType("int");

                    b.Property<string>("ProductDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductPicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductPrice")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("eticaret_uygula.Models.slider", b =>
                {
                    b.Property<int>("SliderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SliderId"), 1L, 1);

                    b.Property<string>("Context")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Header1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Header2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SliderImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SliderName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SliderId");

                    b.ToTable("Slider");
                });

            modelBuilder.Entity("eticaret_uygula.Models.Products", b =>
                {
                    b.HasOne("eticaret_uygula.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("eticaret_uygula.Models.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
