﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WebApp.Models;

namespace WebApp.Migrations
{
    [DbContext(typeof(WebAppContext))]
    [Migration("20170726195916_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApp.Models.Catalog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descriptuon")
                        .IsRequired();

                    b.Property<int?>("EquipmentId")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("EquipmentId");

                    b.ToTable("Catalogs");
                });

            modelBuilder.Entity("WebApp.Models.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Equipments");
                });

            modelBuilder.Entity("WebApp.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CatalogId")
                        .IsRequired();

                    b.Property<string>("Descriptuon")
                        .IsRequired();

                    b.Property<string>("Img")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Price")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CatalogId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("WebApp.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("WebApp.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Login")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Patronymic")
                        .IsRequired();

                    b.Property<int?>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebApp.Models.Catalog", b =>
                {
                    b.HasOne("WebApp.Models.Equipment", "Equipment")
                        .WithMany()
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApp.Models.Product", b =>
                {
                    b.HasOne("WebApp.Models.Catalog", "Catalog")
                        .WithMany()
                        .HasForeignKey("CatalogId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApp.Models.User", b =>
                {
                    b.HasOne("WebApp.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}