﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using aspnetapp;

#nullable disable

namespace aspnetapp.Migrations
{
    [DbContext(typeof(CounterContext))]
    [Migration("20220306084413_addmenu")]
    partial class addmenu
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8_general_ci")
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8");

            modelBuilder.Entity("aspnetapp.Counter", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("count")
                        .HasColumnType("int");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("updatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("id");

                    b.ToTable("Counters", (string)null);
                });

            modelBuilder.Entity("aspnetapp.Menu", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("MenuDetail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MenuEname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MenuName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("icon")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("updatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("id");

                    b.ToTable("Menus", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
