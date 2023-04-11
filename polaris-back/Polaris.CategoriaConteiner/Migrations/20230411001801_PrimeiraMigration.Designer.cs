﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Polaris.CategoriaConteiner.Context;

#nullable disable

namespace Polaris.CategoriaConteiner.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230411001801_PrimeiraMigration")]
    partial class PrimeiraMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Polaris.CategoriaConteiner.Models.CategoriaConteiner", b =>
                {
                    b.Property<int>("CategoriaConteinerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<Guid>("CategoriaConteinerUuid")
                        .HasColumnType("char(36)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("CategoriaConteinerId");

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.ToTable("CategoriaConteineres");
                });
#pragma warning restore 612, 618
        }
    }
}