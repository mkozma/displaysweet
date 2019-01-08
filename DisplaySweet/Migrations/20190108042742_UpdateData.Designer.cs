﻿// <auto-generated />
using System;
using DisplaySweet;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DisplaySweet.Migrations
{
    [DbContext(typeof(DisplaySweetDbContext))]
    [Migration("20190108042742_UpdateData")]
    partial class UpdateData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DisplaySweet.Component", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid?>("NavigationId");

                    b.Property<Guid?>("NavigationId1");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("NavigationId");

                    b.HasIndex("NavigationId1");

                    b.ToTable("Components");
                });

            modelBuilder.Entity("DisplaySweet.Navigation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Index");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("Navigation");
                });

            modelBuilder.Entity("DisplaySweet.Component", b =>
                {
                    b.HasOne("DisplaySweet.Navigation")
                        .WithMany("Components")
                        .HasForeignKey("NavigationId");

                    b.HasOne("DisplaySweet.Navigation")
                        .WithMany()
                        .HasForeignKey("NavigationId1");
                });
#pragma warning restore 612, 618
        }
    }
}
