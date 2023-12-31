﻿// <auto-generated />
using System;
using CititesManager.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CititesManager.WebAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230818173338_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CititesManager.WebAPI.Models.City", b =>
                {
                    b.Property<Guid>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            CityId = new Guid("445a009d-48b4-459d-a3b4-080e5884663e"),
                            CityName = "Asuncion"
                        },
                        new
                        {
                            CityId = new Guid("cee2e14a-c71b-44ae-9d66-f408fbecddb5"),
                            CityName = "New York"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
