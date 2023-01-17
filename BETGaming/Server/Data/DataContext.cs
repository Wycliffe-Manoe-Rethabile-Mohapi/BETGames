namespace BETGaming.Server.Data
{
    public class DataContext:DbContext
    {
        public DataContext():base()
        {
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<ProductType>().HasData
                (
                    new ProductType()
                    {
                        Id=1,
                        Name = "Usb"
                    },
                    new ProductType()
                    {
                        Id = 2,
                        Name = "CD"
                    },
                    new ProductType()
                    {
                        Id = 3,
                        Name = "Download"
                    },
                    new ProductType()
                    {
                        Id = 4,
                        Name = "Hardware"
                    }
                );

            modelBuilder.Entity<Category>().HasData
                (
                    new Category()
                    {
                        Id = 1,
                        Name = "Sandbox",
                        Url= "Sandbox"
                    },
                    new Category()
                    {
                        Id = 2,
                       Name= "Shooters",
                       Url = "Shooters"

                    },
                    new Category()
                    {
                        Id = 3,
                        Name= "Multiplayer",
                        Url= "Multiplayer"
                    },
                    new Category()
                    {
                        Id = 4, 
                        Name= "Role-playing",
                        Url= "Role-playing"
                    },
                    new Category()
                    {
                        Id = 5,
                        Name = "Electronics",
                        Url = "Electronics"
                    }


                );
            modelBuilder.Entity<Product>().HasData
                (
                    new Product()
                    {
                        Id = 1,
                        Title = "Game 1",
                        Description = "The first game",
                        //Price = 1.0m,
                        ImageURL = "https://www.trustedreviews.com/wp-content/uploads/sites/54/2019/01/Best-FPS-Games.jpg",
                        CategoryId =1

                    },
                        new Product()
                        {
                            Id = 2,
                            Title = "Game 2",
                            Description = "The second game",
                            //Price = 2.0m,
                            ImageURL = "https://www.trustedreviews.com/wp-content/uploads/sites/54/2019/01/Best-FPS-Games.jpg",
                            CategoryId = 2

                        },
                        new Product()
                        {
                            Id = 3,
                            Title = "Game 3",
                            Description = "the third game",
                            //Price = 3.0m,
                            ImageURL = "https://www.trustedreviews.com/wp-content/uploads/sites/54/2019/01/Best-FPS-Games.jpg",
                            CategoryId = 3

                        },
                        new Product()
                        {
                            Id = 4,
                            Title = "Game 4",
                            Description = "The fourth game",
                            //Price = 4.0m,
                            ImageURL = "https://www.trustedreviews.com/wp-content/uploads/sites/54/2019/01/Best-FPS-Games.jpg",
                            CategoryId = 4

                        },
                        new Product { Id = 5, Title = "Apple iPhone 12", Description = "The latest iPhone with a 6.1-inch Super Retina XDR display.", ImageURL = "https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg", CategoryId = 5 },
                        new Product { Id = 6, Title = "Samsung Galaxy S21", Description = "The latest Samsung flagship with a 6.2-inch Dynamic AMOLED 2X display.", ImageURL = "https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg", CategoryId = 5 },
                        new Product { Id = 7, Title = "Google Pixel 4a", Description = "A budget-friendly phone from Google with a 5.8-inch OLED display.", ImageURL = "https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg", CategoryId = 5 },
                        new Product { Id = 8, Title = "OnePlus 8T", Description = "A high-performance phone with a 6.55-inch Fluid AMOLED display.", ImageURL = "https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg", CategoryId = 5 },
                        new Product { Id = 9, Title = "Sony PlayStation 5", Description = "The latest gaming console from Sony with 8K graphics and ray tracing.", ImageURL = "https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg", CategoryId = 5 },
                        new Product { Id = 10, Title = "Microsoft Xbox Series X", Description = "The latest gaming console from Microsoft with 4K graphics and 120fps.", ImageURL = "https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg", CategoryId = 5 },
                        new Product { Id = 11, Title = "Nintendo Switch", Description = "A portable gaming console from Nintendo with a 6.2-inch capacitive touchscreen.", ImageURL = "https://example.com/switch.jpg", CategoryId = 5 },
                        new Product { Id = 12, Title = "LG OLED CX Series TV", Description = "A 4K OLED TV with AI ThinQ and Google Assistant built-in.", ImageURL = "https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg", CategoryId = 5 },
                        new Product { Id = 13, Title = "Samsung QN900A Series TV", Description = "A 8K QLED TV with Quantum Processor 8K and Alexa built-in.", ImageURL = "https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg", CategoryId = 5 },
                        new Product { Id = 14, Title = "Sony A8H Series TV", Description = "A 4K OLED TV with Acoustic Surface Audio and Android TV built-in.", ImageURL = "https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg", CategoryId = 5 },
                        new Product { Id = 16, Title = "The Last of Us Part II", Description = "The highly-anticipated sequel to the critically-acclaimed game.", ImageURL = "https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg", CategoryId = 1 },
                        new Product { Id = 17, Title = "Cyberpunk 2077", Description = "An open-world RPG set in a futuristic metropolis.", ImageURL = "", CategoryId = 1 },
                        new Product { Id = 18, Title = "Horizon Zero Dawn", Description = "An action RPG set in a post-apocalyptic world ruled by robotic creatures.", ImageURL = "https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg", CategoryId = 1 },
                        new Product { Id = 19, Title = "Red Dead Redemption 2", Description = "An epic tale of life in America's unforgiving heartland.", ImageURL = "https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg", CategoryId = 1 },
                        new Product { Id = 20, Title = "The Witcher 3: Wild Hunt", Description = "An open-world action RPG based on the bestselling fantasy series.", ImageURL = "https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg", CategoryId = 1 },
                        new Product { Id = 21, Title = "Death Stranding", Description = "An action game developed by Hideo Kojima, creator of the Metal Gear series.", ImageURL = "https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg", CategoryId = 1 },
                        new Product { Id = 22, Title = "The Legend of Zelda: Breath of the Wild", Description = "An open-air adventure game set in a vast wilderness.", ImageURL = "https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg", CategoryId = 1 },
                        new Product { Id = 23, Title = "Super Mario Odyssey", Description = "A 3D platformer featuring Mario's first sandbox-style gameplay.", ImageURL = "https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg", CategoryId = 1 },
                        new Product { Id = 24, Title = "Persona 5", Description = "A role-playing game that follows a group of high school students.", ImageURL = "https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg", CategoryId = 1 },
                        new Product { Id = 25, Title = "Final Fantasy VII Remake", Description = "A modern retelling of the classic RPG.", ImageURL = "", CategoryId = 1 },
                        new Product { Id = 26, Title = "Monster Hunter: World", Description = "A game where players take on the role of a hunter and slay different monsters", ImageURL = "https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg", CategoryId = 1 },
                        new Product { Id = 27, Title = "Overwatch", Description = "A team-based first-person shooter game developed by Blizzard Entertainment.", ImageURL = "https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg", CategoryId = 1 },
                        //...
                        new Product { Id = 28, Title = "Minecraft", Description = "A sandbox game where players can build and explore virtual worlds.", ImageURL = "https://m.media-amazon.com/images/I/61bK6PMOC3L._AC_SL1500_.jpg", CategoryId = 1 }

                );
            modelBuilder.Entity<ProductVariant>().HasKey(s => new { s.ProductId, s.ProductTypeId });

            modelBuilder.Entity<ProductVariant>().HasData
                (
                    new ProductVariant()
                    {
                        ProductId = 1,
                        ProductTypeId = 1,
                        Price = 10m,
                        OriginalPrice = 5m

                    },
                    new ProductVariant()
                    {
                        ProductId = 1,
                        ProductTypeId = 2,
                        Price = 10m,
                        OriginalPrice = 5m

                    }
                          ,
                            new ProductVariant()
                            {
                                ProductId = 2,
                                ProductTypeId = 1,
                                Price = 10m,
                                OriginalPrice = 5m
                            }
                    ,
                    new ProductVariant()
                    {
                        ProductId = 3,
                        ProductTypeId = 1,
                        Price = 10m,
                        OriginalPrice = 5m
                    }
                    ,
                        new ProductVariant()
                        {
                            ProductId = 4,
                            ProductTypeId = 1,
                            Price = 10m,
                            OriginalPrice = 5m
                        }
                    ,
                    new ProductVariant()
                    {
                        ProductId = 5,
                        ProductTypeId = 1,
                        Price = 10m,
                        OriginalPrice = 5m
                    }
                    //,
                    //new ProductVariant()
                    //{
                    //    ProductId = 6,
                    //    ProductTypeId = 1,
                    //    Price = 10m,
                    //    OriginalPrice = 5m
                    //},
                    //new ProductVariant()
                    //{
                    //    ProductId = 7,
                    //    ProductTypeId = 1,
                    //    Price = 10m,
                    //    OriginalPrice = 5m
                    //},
                    //new ProductVariant()
                    //{
                    //    ProductId = 8,
                    //    ProductTypeId = 1,
                    //    Price = 10m,
                    //    OriginalPrice = 5m
                    //},
                    //new ProductVariant()
                    //{
                    //    ProductId = 9,
                    //    ProductTypeId = 1,
                    //    Price = 10m,
                    //    OriginalPrice = 5m
                    //},
                    //new ProductVariant()
                    //{
                    //    ProductId = 10,
                    //    ProductTypeId = 1,
                    //    Price = 10m,
                    //    OriginalPrice = 5m
                    //},
                    //new ProductVariant()
                    //{
                    //    ProductId = 11,
                    //    ProductTypeId = 1,
                    //    Price = 10m,
                    //    OriginalPrice = 5m
                    //},
                    //new ProductVariant()
                    //{
                    //    ProductId = 12,
                    //    ProductTypeId = 1,
                    //    Price = 10m,
                    //    OriginalPrice = 5m
                    //},
                    //new ProductVariant()
                    //{
                    //    ProductId = 13,
                    //    ProductTypeId = 1,
                    //    Price = 10m,
                    //    OriginalPrice = 5m
                    //},
                    //new ProductVariant()
                    //{
                    //    ProductId = 14,
                    //    ProductTypeId = 1,
                    //    Price = 10m,
                    //    OriginalPrice = 5m
                    //},
                    //new ProductVariant()
                    //{
                    //    ProductId = 15,
                    //    ProductTypeId = 1,
                    //    Price = 10m,
                    //    OriginalPrice = 5m
                    //},
                    //new ProductVariant()
                    //{
                    //    ProductId = 16,
                    //    ProductTypeId = 1,
                    //    Price = 10m,
                    //    OriginalPrice = 5m
                    //},
                    //new ProductVariant()
                    //{
                    //    ProductId = 17,
                    //    ProductTypeId = 1,
                    //    Price = 10m,
                    //    OriginalPrice = 5m
                    //},
                    //new ProductVariant()
                    //{
                    //    ProductId = 18,
                    //    ProductTypeId = 1,
                    //    Price = 10m,
                    //    OriginalPrice = 5m
                    //},
                    //new ProductVariant()
                    //{
                    //    ProductId = 19,
                    //    ProductTypeId = 1,
                    //    Price = 10m,
                    //    OriginalPrice = 5m
                    //},
                    //new ProductVariant()
                    //{
                    //    ProductId = 20,
                    //    ProductTypeId = 1,
                    //    Price = 10m,
                    //    OriginalPrice = 5m
                    //},
                    //new ProductVariant()
                    //{
                    //    ProductId = 21,
                    //    ProductTypeId = 1,
                    //    Price = 10m,
                    //    OriginalPrice = 5m
                    //},
                    //new ProductVariant()
                    //{
                    //    ProductId = 22,
                    //    ProductTypeId = 1,
                    //    Price = 10m,
                    //    OriginalPrice = 5m
                    //},
                    //new ProductVariant()
                    //{
                    //    ProductId = 23,
                    //    ProductTypeId = 1,
                    //    Price = 10m,
                    //    OriginalPrice = 5m
                    //},
                    //new ProductVariant()
                    //{
                    //    ProductId = 24,
                    //    ProductTypeId = 1,
                    //    Price = 10m,
                    //    OriginalPrice = 5m
                    //},
                    //new ProductVariant()
                    //{
                    //    ProductId = 25,
                    //    ProductTypeId = 1,
                    //    Price = 10m,
                    //    OriginalPrice = 5m
                    //},
                    //new ProductVariant()
                    //{
                    //    ProductId = 26,
                    //    ProductTypeId = 1,
                    //    Price = 10m,
                    //    OriginalPrice = 5m
                    //},
                    //new ProductVariant()
                    //{
                    //    ProductId = 27,
                    //    ProductTypeId = 1,
                    //    Price = 10m,
                    //    OriginalPrice = 5m
                    //}

                    );
        }




    }
}
