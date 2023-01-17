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
    [Migration("20230116213934_migration7")]
    partial class migration7
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
                            Url = "https://play-lh.googleusercontent.com/QS31MR9QEDSRV4V8qro8YtwT72OvUJJPpWrgyqDLwNgLcEGDe2D7EJnakRJRIhYWUw"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Shooters (FPS and TPS)",
                            Url = "https://www.denofgeek.com/wp-content/uploads/2021/07/Far-Cry-2.jpg"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Multiplayer online battle arena (MOBA)",
                            Url = "https://i.ytimg.com/vi/lD-nWRWo7NU/maxresdefault.jpg"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Role-playing (RPG, ARPG, and More)",
                            Url = "https://www.giantbomb.com/a/uploads/scale_medium/9/97089/2256747-4.png"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Electronics",
                            Url = "https://www.giantbomb.com/a/uploads/scale_medium/9/97089/2256747-4.png"
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
                            ImageURL = "images/3.png",
                            Title = "Game 1"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Description = "The second game",
                            ImageURL = "images/4.png",
                            Title = "Game 2"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            Description = "the third game",
                            ImageURL = "images/3.png",
                            Title = "Game 3"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 4,
                            Description = "The fourth game",
                            ImageURL = "images/4.png",
                            Title = "Game 4"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 5,
                            Description = "The latest iPhone with a 6.1-inch Super Retina XDR display.",
                            ImageURL = "https://example.com/iphone12.jpg",
                            Title = "Apple iPhone 12"
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 5,
                            Description = "The latest Samsung flagship with a 6.2-inch Dynamic AMOLED 2X display.",
                            ImageURL = "https://example.com/samsungs21.jpg",
                            Title = "Samsung Galaxy S21"
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 5,
                            Description = "A budget-friendly phone from Google with a 5.8-inch OLED display.",
                            ImageURL = "https://example.com/pixel4a.jpg",
                            Title = "Google Pixel 4a"
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 5,
                            Description = "A high-performance phone with a 6.55-inch Fluid AMOLED display.",
                            ImageURL = "https://example.com/oneplus8t.jpg",
                            Title = "OnePlus 8T"
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 5,
                            Description = "The latest gaming console from Sony with 8K graphics and ray tracing.",
                            ImageURL = "https://example.com/ps5.jpg",
                            Title = "Sony PlayStation 5"
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 5,
                            Description = "The latest gaming console from Microsoft with 4K graphics and 120fps.",
                            ImageURL = "https://example.com/xboxseriesx.jpg",
                            Title = "Microsoft Xbox Series X"
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 5,
                            Description = "A portable gaming console from Nintendo with a 6.2-inch capacitive touchscreen.",
                            ImageURL = "https://example.com/switch.jpg",
                            Title = "Nintendo Switch"
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 5,
                            Description = "A 4K OLED TV with AI ThinQ and Google Assistant built-in.",
                            ImageURL = "https://example.com/lgoledcx.jpg",
                            Title = "LG OLED CX Series TV"
                        },
                        new
                        {
                            Id = 13,
                            CategoryId = 5,
                            Description = "A 8K QLED TV with Quantum Processor 8K and Alexa built-in.",
                            ImageURL = "https://example.com/samsungqn900a.jpg",
                            Title = "Samsung QN900A Series TV"
                        },
                        new
                        {
                            Id = 14,
                            CategoryId = 5,
                            Description = "A 4K OLED TV with Acoustic Surface Audio and Android TV built-in.",
                            ImageURL = "https://example.com/sonya8h.jpg",
                            Title = "Sony A8H Series TV"
                        },
                        new
                        {
                            Id = 16,
                            CategoryId = 1,
                            Description = "The highly-anticipated sequel to the critically-acclaimed game.",
                            ImageURL = "",
                            Title = "The Last of Us Part II"
                        },
                        new
                        {
                            Id = 17,
                            CategoryId = 1,
                            Description = "An open-world RPG set in a futuristic metropolis.",
                            ImageURL = "",
                            Title = "Cyberpunk 2077"
                        },
                        new
                        {
                            Id = 18,
                            CategoryId = 1,
                            Description = "An action RPG set in a post-apocalyptic world ruled by robotic creatures.",
                            ImageURL = "",
                            Title = "Horizon Zero Dawn"
                        },
                        new
                        {
                            Id = 19,
                            CategoryId = 1,
                            Description = "An epic tale of life in America's unforgiving heartland.",
                            ImageURL = "",
                            Title = "Red Dead Redemption 2"
                        },
                        new
                        {
                            Id = 20,
                            CategoryId = 1,
                            Description = "An open-world action RPG based on the bestselling fantasy series.",
                            ImageURL = "",
                            Title = "The Witcher 3: Wild Hunt"
                        },
                        new
                        {
                            Id = 21,
                            CategoryId = 1,
                            Description = "An action game developed by Hideo Kojima, creator of the Metal Gear series.",
                            ImageURL = "",
                            Title = "Death Stranding"
                        },
                        new
                        {
                            Id = 22,
                            CategoryId = 1,
                            Description = "An open-air adventure game set in a vast wilderness.",
                            ImageURL = "",
                            Title = "The Legend of Zelda: Breath of the Wild"
                        },
                        new
                        {
                            Id = 23,
                            CategoryId = 1,
                            Description = "A 3D platformer featuring Mario's first sandbox-style gameplay.",
                            ImageURL = "",
                            Title = "Super Mario Odyssey"
                        },
                        new
                        {
                            Id = 24,
                            CategoryId = 1,
                            Description = "A role-playing game that follows a group of high school students.",
                            ImageURL = "",
                            Title = "Persona 5"
                        },
                        new
                        {
                            Id = 25,
                            CategoryId = 1,
                            Description = "A modern retelling of the classic RPG.",
                            ImageURL = "",
                            Title = "Final Fantasy VII Remake"
                        },
                        new
                        {
                            Id = 26,
                            CategoryId = 1,
                            Description = "A game where players take on the role of a hunter and slay different monsters",
                            ImageURL = "",
                            Title = "Monster Hunter: World"
                        },
                        new
                        {
                            Id = 27,
                            CategoryId = 1,
                            Description = "A team-based first-person shooter game developed by Blizzard Entertainment.",
                            ImageURL = "",
                            Title = "Overwatch"
                        },
                        new
                        {
                            Id = 28,
                            CategoryId = 1,
                            Description = "A sandbox game where players can build and explore virtual worlds.",
                            ImageURL = "",
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
                        });
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