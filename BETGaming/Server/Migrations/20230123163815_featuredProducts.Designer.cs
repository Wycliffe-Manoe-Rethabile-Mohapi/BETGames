﻿// <auto-generated />
using System;
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
    [Migration("20230123163815_featuredProducts")]
    partial class featuredProducts
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BETGaming.Shared.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Sandbox",
                            Url = "Sandbox"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Shooters",
                            Url = "Shooters"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Multiplayer",
                            Url = "Multiplayer"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Role-playing",
                            Url = "Role-playing"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Electronics",
                            Url = "Electronics"
                        });
                });

            modelBuilder.Entity("BETGaming.Shared.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Featured")
                        .HasColumnType("bit");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "The first game",
                            Featured = true,
                            ImageURL = "https://www.trustedreviews.com/wp-content/uploads/sites/54/2019/01/Best-FPS-Games.jpg",
                            Title = "Game 1"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Description = "The second game",
                            Featured = false,
                            ImageURL = "https://www.trustedreviews.com/wp-content/uploads/sites/54/2019/01/Best-FPS-Games.jpg",
                            Title = "Game 2"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            Description = "the third game",
                            Featured = false,
                            ImageURL = "https://www.trustedreviews.com/wp-content/uploads/sites/54/2019/01/Best-FPS-Games.jpg",
                            Title = "Game 3"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 4,
                            Description = "The fourth game",
                            Featured = false,
                            ImageURL = "https://www.trustedreviews.com/wp-content/uploads/sites/54/2019/01/Best-FPS-Games.jpg",
                            Title = "Game 4"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 5,
                            Description = "The latest iPhone with a 6.1-inch Super Retina XDR display.",
                            Featured = true,
                            ImageURL = "https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg",
                            Title = "Apple iPhone 12"
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 5,
                            Description = "The latest Samsung flagship with a 6.2-inch Dynamic AMOLED 2X display.",
                            Featured = false,
                            ImageURL = "https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg",
                            Title = "Samsung Galaxy S21"
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 5,
                            Description = "A budget-friendly phone from Google with a 5.8-inch OLED display.",
                            Featured = false,
                            ImageURL = "https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg",
                            Title = "Google Pixel 4a"
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 5,
                            Description = "A high-performance phone with a 6.55-inch Fluid AMOLED display.",
                            Featured = false,
                            ImageURL = "https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg",
                            Title = "OnePlus 8T"
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 5,
                            Description = "The latest gaming console from Sony with 8K graphics and ray tracing.",
                            Featured = false,
                            ImageURL = "https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg",
                            Title = "Sony PlayStation 5"
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 5,
                            Description = "The latest gaming console from Microsoft with 4K graphics and 120fps.",
                            Featured = false,
                            ImageURL = "https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg",
                            Title = "Microsoft Xbox Series X"
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 5,
                            Description = "A portable gaming console from Nintendo with a 6.2-inch capacitive touchscreen.",
                            Featured = false,
                            ImageURL = "https://example.com/switch.jpg",
                            Title = "Nintendo Switch"
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 5,
                            Description = "A 4K OLED TV with AI ThinQ and Google Assistant built-in.",
                            Featured = false,
                            ImageURL = "https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg",
                            Title = "LG OLED CX Series TV"
                        },
                        new
                        {
                            Id = 13,
                            CategoryId = 5,
                            Description = "A 8K QLED TV with Quantum Processor 8K and Alexa built-in.",
                            Featured = false,
                            ImageURL = "https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg",
                            Title = "Samsung QN900A Series TV"
                        },
                        new
                        {
                            Id = 14,
                            CategoryId = 5,
                            Description = "A 4K OLED TV with Acoustic Surface Audio and Android TV built-in.",
                            Featured = false,
                            ImageURL = "https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg",
                            Title = "Sony A8H Series TV"
                        },
                        new
                        {
                            Id = 16,
                            CategoryId = 1,
                            Description = "The highly-anticipated sequel to the critically-acclaimed game.",
                            Featured = false,
                            ImageURL = "https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg",
                            Title = "The Last of Us Part II"
                        },
                        new
                        {
                            Id = 17,
                            CategoryId = 1,
                            Description = "An open-world RPG set in a futuristic metropolis.",
                            Featured = false,
                            ImageURL = "",
                            Title = "Cyberpunk 2077"
                        },
                        new
                        {
                            Id = 18,
                            CategoryId = 1,
                            Description = "An action RPG set in a post-apocalyptic world ruled by robotic creatures.",
                            Featured = false,
                            ImageURL = "https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg",
                            Title = "Horizon Zero Dawn"
                        },
                        new
                        {
                            Id = 19,
                            CategoryId = 1,
                            Description = "An epic tale of life in America's unforgiving heartland.",
                            Featured = false,
                            ImageURL = "https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg",
                            Title = "Red Dead Redemption 2"
                        },
                        new
                        {
                            Id = 20,
                            CategoryId = 1,
                            Description = "An open-world action RPG based on the bestselling fantasy series.",
                            Featured = false,
                            ImageURL = "https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg",
                            Title = "The Witcher 3: Wild Hunt"
                        },
                        new
                        {
                            Id = 21,
                            CategoryId = 1,
                            Description = "An action game developed by Hideo Kojima, creator of the Metal Gear series.",
                            Featured = false,
                            ImageURL = "https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg",
                            Title = "Death Stranding"
                        },
                        new
                        {
                            Id = 22,
                            CategoryId = 1,
                            Description = "An open-air adventure game set in a vast wilderness.",
                            Featured = false,
                            ImageURL = "https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg",
                            Title = "The Legend of Zelda: Breath of the Wild"
                        },
                        new
                        {
                            Id = 23,
                            CategoryId = 1,
                            Description = "A 3D platformer featuring Mario's first sandbox-style gameplay.",
                            Featured = false,
                            ImageURL = "https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg",
                            Title = "Super Mario Odyssey"
                        },
                        new
                        {
                            Id = 24,
                            CategoryId = 1,
                            Description = "A role-playing game that follows a group of high school students.",
                            Featured = false,
                            ImageURL = "https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg",
                            Title = "Persona 5"
                        },
                        new
                        {
                            Id = 25,
                            CategoryId = 1,
                            Description = "A modern retelling of the classic RPG.",
                            Featured = false,
                            ImageURL = "",
                            Title = "Final Fantasy VII Remake"
                        },
                        new
                        {
                            Id = 26,
                            CategoryId = 1,
                            Description = "A game where players take on the role of a hunter and slay different monsters",
                            Featured = false,
                            ImageURL = "https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg",
                            Title = "Monster Hunter: World"
                        },
                        new
                        {
                            Id = 27,
                            CategoryId = 1,
                            Description = "A team-based first-person shooter game developed by Blizzard Entertainment.",
                            Featured = false,
                            ImageURL = "https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg",
                            Title = "Overwatch"
                        },
                        new
                        {
                            Id = 28,
                            CategoryId = 1,
                            Description = "A sandbox game where players can build and explore virtual worlds.",
                            Featured = false,
                            ImageURL = "https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg",
                            Title = "Minecraft"
                        });
                });

            modelBuilder.Entity("BETGaming.Shared.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Usb"
                        },
                        new
                        {
                            Id = 2,
                            Name = "CD"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Download"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Hardware"
                        });
                });

            modelBuilder.Entity("BETGaming.Shared.ProductVariant", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int");

                    b.Property<decimal>("OriginalPrice")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("ProductId", "ProductTypeId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("ProductVariants");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            ProductTypeId = 1,
                            OriginalPrice = 5m,
                            Price = 10m
                        },
                        new
                        {
                            ProductId = 1,
                            ProductTypeId = 2,
                            OriginalPrice = 5m,
                            Price = 10m
                        },
                        new
                        {
                            ProductId = 2,
                            ProductTypeId = 1,
                            OriginalPrice = 5m,
                            Price = 10m
                        },
                        new
                        {
                            ProductId = 3,
                            ProductTypeId = 1,
                            OriginalPrice = 5m,
                            Price = 10m
                        },
                        new
                        {
                            ProductId = 4,
                            ProductTypeId = 1,
                            OriginalPrice = 5m,
                            Price = 10m
                        },
                        new
                        {
                            ProductId = 5,
                            ProductTypeId = 1,
                            OriginalPrice = 5m,
                            Price = 10m
                        });
                });

            modelBuilder.Entity("BETGaming.Shared.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PaswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BETGaming.Shared.Product", b =>
                {
                    b.HasOne("BETGaming.Shared.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BETGaming.Shared.ProductVariant", b =>
                {
                    b.HasOne("BETGaming.Shared.Product", "Product")
                        .WithMany("Variants")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BETGaming.Shared.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("BETGaming.Shared.Product", b =>
                {
                    b.Navigation("Variants");
                });
#pragma warning restore 612, 618
        }
    }
}
