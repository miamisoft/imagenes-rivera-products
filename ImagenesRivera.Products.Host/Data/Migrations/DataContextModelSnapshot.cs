﻿// <auto-generated />
using System;
using ImagenesRivera.Products.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ImagenesRivera.Products.Host.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ImagenesRivera.Products.Data.Entities.KeyChainBookPage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomText");

                    b.Property<string>("ImageUrl");

                    b.Property<int>("KeyChainBookId");

                    b.Property<int>("Number");

                    b.HasKey("Id");

                    b.HasIndex("KeyChainBookId");

                    b.ToTable("KeyChainBookPage");
                });

            modelBuilder.Entity("ImagenesRivera.Products.Data.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime?>("CreatedOn");

                    b.Property<bool?>("IsDeleted");

                    b.Property<int?>("LastModifiedBy");

                    b.Property<DateTime?>("LastModifiedOn");

                    b.Property<string>("OrderID")
                        .IsRequired();

                    b.Property<int>("PayerId");

                    b.Property<int>("ShippingId");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("PayerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ImagenesRivera.Products.Data.Entities.Payer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime?>("CreatedOn");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<bool?>("IsDeleted");

                    b.Property<int?>("LastModifiedBy");

                    b.Property<DateTime?>("LastModifiedOn");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("PayerID")
                        .IsRequired();

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ImagenesRivera.Products.Data.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime?>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<bool?>("IsDeleted");

                    b.Property<int?>("LastModifiedBy");

                    b.Property<DateTime?>("LastModifiedOn");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Price")
                        .IsRequired();

                    b.Property<string>("Sku");

                    b.Property<string>("Tax");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Product");
                });

            modelBuilder.Entity("ImagenesRivera.Products.Data.Entities.ProductOrders", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("OrderDetailsId");

                    b.HasKey("ProductId", "OrderDetailsId");

                    b.HasIndex("OrderDetailsId");

                    b.ToTable("ProductOrders");
                });

            modelBuilder.Entity("ImagenesRivera.Products.Data.Entities.Shipping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime?>("CreatedOn");

                    b.Property<bool?>("IsDeleted");

                    b.Property<int?>("LastModifiedBy");

                    b.Property<DateTime?>("LastModifiedOn");

                    b.Property<string>("Name");

                    b.Property<int>("OrderDetailsId");

                    b.HasKey("Id");

                    b.HasIndex("OrderDetailsId")
                        .IsUnique();

                    b.ToTable("Shipping");
                });

            modelBuilder.Entity("ImagenesRivera.Products.Data.Entities.KeyChainBook", b =>
                {
                    b.HasBaseType("ImagenesRivera.Products.Data.Entities.Product");

                    b.Property<string>("Skin");

                    b.Property<string>("Title");

                    b.ToTable("KeyChainBook");

                    b.HasDiscriminator().HasValue("KeyChainBook");
                });

            modelBuilder.Entity("ImagenesRivera.Products.Data.Entities.KeyChainBookPage", b =>
                {
                    b.HasOne("ImagenesRivera.Products.Data.Entities.KeyChainBook", "KeyChainBook")
                        .WithMany("Pages")
                        .HasForeignKey("KeyChainBookId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ImagenesRivera.Products.Data.Entities.Order", b =>
                {
                    b.HasOne("ImagenesRivera.Products.Data.Entities.Payer", "Payer")
                        .WithMany("Orders")
                        .HasForeignKey("PayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ImagenesRivera.Products.Data.Entities.Payer", b =>
                {
                    b.OwnsOne("ImagenesRivera.Products.Data.Entities.Address", "Address", b1 =>
                        {
                            b1.Property<int>("PayerId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Address1")
                                .IsRequired();

                            b1.Property<string>("Address2");

                            b1.Property<string>("City")
                                .IsRequired();

                            b1.Property<string>("ZipCode")
                                .IsRequired();

                            b1.ToTable("Customers");

                            b1.HasOne("ImagenesRivera.Products.Data.Entities.Payer")
                                .WithOne("Address")
                                .HasForeignKey("ImagenesRivera.Products.Data.Entities.Address", "PayerId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("ImagenesRivera.Products.Data.Entities.ProductOrders", b =>
                {
                    b.HasOne("ImagenesRivera.Products.Data.Entities.Order", "OrderDetails")
                        .WithMany("Products")
                        .HasForeignKey("OrderDetailsId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ImagenesRivera.Products.Data.Entities.Product", "Product")
                        .WithMany("Orders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ImagenesRivera.Products.Data.Entities.Shipping", b =>
                {
                    b.HasOne("ImagenesRivera.Products.Data.Entities.Order", "OrderDetails")
                        .WithOne("Shipping")
                        .HasForeignKey("ImagenesRivera.Products.Data.Entities.Shipping", "OrderDetailsId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("ImagenesRivera.Products.Data.Entities.Address", "Address", b1 =>
                        {
                            b1.Property<int>("ShippingId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Address1")
                                .IsRequired();

                            b1.Property<string>("Address2");

                            b1.Property<string>("City")
                                .IsRequired();

                            b1.Property<string>("ZipCode")
                                .IsRequired();

                            b1.ToTable("Shipping");

                            b1.HasOne("ImagenesRivera.Products.Data.Entities.Shipping")
                                .WithOne("Address")
                                .HasForeignKey("ImagenesRivera.Products.Data.Entities.Address", "ShippingId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
