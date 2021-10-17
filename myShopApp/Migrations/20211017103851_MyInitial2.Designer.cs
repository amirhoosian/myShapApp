﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using myShopApp.models;

namespace myShopApp.Migrations
{
    [DbContext(typeof(context))]
    [Migration("20211017103851_MyInitial2")]
    partial class MyInitial2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("factorDetailproduct", b =>
                {
                    b.Property<int>("factordetailsid")
                        .HasColumnType("int");

                    b.Property<int>("productsid")
                        .HasColumnType("int");

                    b.HasKey("factordetailsid", "productsid");

                    b.HasIndex("productsid");

                    b.ToTable("factorDetailproduct");
                });

            modelBuilder.Entity("myShopApp.models.catgory", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("catgory");
                });

            modelBuilder.Entity("myShopApp.models.factorDetail", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("factorid")
                        .HasColumnType("int");

                    b.Property<decimal>("fianlPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("itemPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("numbers")
                        .HasColumnType("int");

                    b.Property<int>("productid")
                        .HasColumnType("int");

                    b.Property<string>("sellerName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("factorid")
                        .IsUnique();

                    b.ToTable("factorDetails");
                });

            modelBuilder.Entity("myShopApp.models.factors", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("buyerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("funalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("factors");
                });

            modelBuilder.Entity("myShopApp.models.product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("catgoryid")
                        .HasColumnType("int");

                    b.Property<int>("catid")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("sellerName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("catgoryid");

                    b.ToTable("product");
                });

            modelBuilder.Entity("factorDetailproduct", b =>
                {
                    b.HasOne("myShopApp.models.factorDetail", null)
                        .WithMany()
                        .HasForeignKey("factordetailsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("myShopApp.models.product", null)
                        .WithMany()
                        .HasForeignKey("productsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("myShopApp.models.factorDetail", b =>
                {
                    b.HasOne("myShopApp.models.factors", "factor")
                        .WithOne("factordetail")
                        .HasForeignKey("myShopApp.models.factorDetail", "factorid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("factor");
                });

            modelBuilder.Entity("myShopApp.models.product", b =>
                {
                    b.HasOne("myShopApp.models.catgory", "catgory")
                        .WithMany("products")
                        .HasForeignKey("catgoryid");

                    b.Navigation("catgory");
                });

            modelBuilder.Entity("myShopApp.models.catgory", b =>
                {
                    b.Navigation("products");
                });

            modelBuilder.Entity("myShopApp.models.factors", b =>
                {
                    b.Navigation("factordetail");
                });
#pragma warning restore 612, 618
        }
    }
}
