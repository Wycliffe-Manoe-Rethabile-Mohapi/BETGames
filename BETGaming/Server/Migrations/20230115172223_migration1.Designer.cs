﻿// <auto-generated />
using BETGaming.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BETGaming.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230115172223_migration1")]
    partial class migration1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BETGaming.Shared.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "The first game",
                            ImageURL = "images/3.png",
                            Price = 1.0m,
                            Title = "Game 1"
                        },
                        new
                        {
                            Id = 2,
                            Description = "The second game",
                            ImageURL = "images/4.png",
                            Price = 2.0m,
                            Title = "Game 2"
                        },
                        new
                        {
                            Id = 3,
                            Description = "the third game",
                            ImageURL = "images/3.png",
                            Price = 3.0m,
                            Title = "Game 3"
                        },
                        new
                        {
                            Id = 4,
                            Description = "The fourth game",
                            ImageURL = "images/4.png",
                            Price = 4.0m,
                            Title = "Game 4"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
