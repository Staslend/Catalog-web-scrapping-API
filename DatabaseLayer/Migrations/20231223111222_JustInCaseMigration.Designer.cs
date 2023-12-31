﻿// <auto-generated />
using System;
using DatabaseLayer.DataContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DatabaseLayer.Migrations
{
    [DbContext(typeof(ProductAPIDbContext))]
    [Migration("20231223111222_JustInCaseMigration")]
    partial class JustInCaseMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DatabaseLayer.Models.ActionDataModel", b =>
                {
                    b.Property<int>("action_data_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("action_data_id"));

                    b.Property<string>("action_data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("action_id")
                        .HasColumnType("int");

                    b.Property<int>("action_id1")
                        .HasColumnType("int");

                    b.HasKey("action_data_id");

                    b.HasIndex("action_id1");

                    b.ToTable("ActionDataModel");
                });

            modelBuilder.Entity("DatabaseLayer.Models.ActionModel", b =>
                {
                    b.Property<int>("action_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("action_id"));

                    b.Property<int?>("ShopModelshop_id")
                        .HasColumnType("int");

                    b.Property<int?>("URLModelurl_id")
                        .HasColumnType("int");

                    b.Property<int>("action_name")
                        .HasColumnType("int");

                    b.HasKey("action_id");

                    b.HasIndex("ShopModelshop_id");

                    b.HasIndex("URLModelurl_id");

                    b.ToTable("ActionModel");
                });

            modelBuilder.Entity("DatabaseLayer.Models.ProductModel", b =>
                {
                    b.Property<int>("product_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("product_id"));

                    b.Property<string>("shop_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("shop_id1")
                        .HasColumnType("int");

                    b.HasKey("product_id");

                    b.HasIndex("shop_id1");

                    b.ToTable("products");
                });

            modelBuilder.Entity("DatabaseLayer.Models.ProductNumericDataModel", b =>
                {
                    b.Property<int>("product_data_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("product_data_id"));

                    b.Property<int>("product_id")
                        .HasColumnType("int");

                    b.Property<int>("product_id1")
                        .HasColumnType("int");

                    b.Property<string>("product_property_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("property_value")
                        .HasColumnType("float");

                    b.HasKey("product_data_id");

                    b.HasIndex("product_id1");

                    b.ToTable("productsNumericData");
                });

            modelBuilder.Entity("DatabaseLayer.Models.ProductTextDataModel", b =>
                {
                    b.Property<int>("product_data_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("product_data_id"));

                    b.Property<int>("product_id")
                        .HasColumnType("int");

                    b.Property<int>("product_id1")
                        .HasColumnType("int");

                    b.Property<string>("product_property_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("property_value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("product_data_id");

                    b.HasIndex("product_id1");

                    b.ToTable("productsTextData");
                });

            modelBuilder.Entity("DatabaseLayer.Models.ShopModel", b =>
                {
                    b.Property<int>("shop_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("shop_id"));

                    b.Property<string>("pageProperty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("shop_domain_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("shop_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("shop_id");

                    b.ToTable("shops");
                });

            modelBuilder.Entity("DatabaseLayer.Models.URLModel", b =>
                {
                    b.Property<int>("url_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("url_id"));

                    b.Property<bool>("multipaged")
                        .HasColumnType("bit");

                    b.Property<string>("pageProperty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("shop_id")
                        .HasColumnType("int");

                    b.Property<int?>("shop_id1")
                        .HasColumnType("int");

                    b.Property<string>("url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("url_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("url_id");

                    b.HasIndex("shop_id1");

                    b.ToTable("URLs");
                });

            modelBuilder.Entity("DatabaseLayer.Models.XPathModel", b =>
                {
                    b.Property<int>("xpath_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("xpath_id"));

                    b.Property<int?>("ShopModelshop_id")
                        .HasColumnType("int");

                    b.Property<int?>("URLModelurl_id")
                        .HasColumnType("int");

                    b.Property<string>("atribute")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("property_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("xpath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("xpath_id");

                    b.HasIndex("ShopModelshop_id");

                    b.HasIndex("URLModelurl_id");

                    b.ToTable("XPathModel");
                });

            modelBuilder.Entity("DatabaseLayer.Models.ActionDataModel", b =>
                {
                    b.HasOne("DatabaseLayer.Models.ActionModel", "action")
                        .WithMany("action_data")
                        .HasForeignKey("action_id1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("action");
                });

            modelBuilder.Entity("DatabaseLayer.Models.ActionModel", b =>
                {
                    b.HasOne("DatabaseLayer.Models.ShopModel", null)
                        .WithMany("actions")
                        .HasForeignKey("ShopModelshop_id");

                    b.HasOne("DatabaseLayer.Models.URLModel", null)
                        .WithMany("actions")
                        .HasForeignKey("URLModelurl_id");
                });

            modelBuilder.Entity("DatabaseLayer.Models.ProductModel", b =>
                {
                    b.HasOne("DatabaseLayer.Models.ShopModel", "shop")
                        .WithMany()
                        .HasForeignKey("shop_id1");

                    b.Navigation("shop");
                });

            modelBuilder.Entity("DatabaseLayer.Models.ProductNumericDataModel", b =>
                {
                    b.HasOne("DatabaseLayer.Models.ProductModel", "product")
                        .WithMany("product_numeric_data")
                        .HasForeignKey("product_id1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("product");
                });

            modelBuilder.Entity("DatabaseLayer.Models.ProductTextDataModel", b =>
                {
                    b.HasOne("DatabaseLayer.Models.ProductModel", "product")
                        .WithMany("product_text_data")
                        .HasForeignKey("product_id1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("product");
                });

            modelBuilder.Entity("DatabaseLayer.Models.URLModel", b =>
                {
                    b.HasOne("DatabaseLayer.Models.ShopModel", "shop")
                        .WithMany()
                        .HasForeignKey("shop_id1");

                    b.Navigation("shop");
                });

            modelBuilder.Entity("DatabaseLayer.Models.XPathModel", b =>
                {
                    b.HasOne("DatabaseLayer.Models.ShopModel", null)
                        .WithMany("xPaths")
                        .HasForeignKey("ShopModelshop_id");

                    b.HasOne("DatabaseLayer.Models.URLModel", null)
                        .WithMany("xPaths")
                        .HasForeignKey("URLModelurl_id");
                });

            modelBuilder.Entity("DatabaseLayer.Models.ActionModel", b =>
                {
                    b.Navigation("action_data");
                });

            modelBuilder.Entity("DatabaseLayer.Models.ProductModel", b =>
                {
                    b.Navigation("product_numeric_data");

                    b.Navigation("product_text_data");
                });

            modelBuilder.Entity("DatabaseLayer.Models.ShopModel", b =>
                {
                    b.Navigation("actions");

                    b.Navigation("xPaths");
                });

            modelBuilder.Entity("DatabaseLayer.Models.URLModel", b =>
                {
                    b.Navigation("actions");

                    b.Navigation("xPaths");
                });
#pragma warning restore 612, 618
        }
    }
}
