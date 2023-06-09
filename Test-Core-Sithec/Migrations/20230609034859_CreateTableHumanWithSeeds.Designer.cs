﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Test_Core_Sithec.Models;

#nullable disable

namespace Test_Core_Sithec.Migrations
{
    [DbContext(typeof(HumanContext))]
    [Migration("20230609034859_CreateTableHumanWithSeeds")]
    partial class CreateTableHumanWithSeeds
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Test_Core_Sithec.Models.Human", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte>("Age")
                        .HasColumnType("tinyint");

                    b.Property<bool?>("Gender")
                        .HasColumnType("bit");

                    b.Property<decimal>("Height")
                        .HasPrecision(3, 2)
                        .HasColumnType("decimal(3,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<decimal>("Weight")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Id");

                    b.ToTable("Humans", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = (byte)23,
                            Gender = false,
                            Height = 1.11m,
                            Name = "Human 1",
                            Weight = 112m
                        },
                        new
                        {
                            Id = 2,
                            Age = (byte)18,
                            Gender = true,
                            Height = 1.56m,
                            Name = "Human 2",
                            Weight = 112m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
