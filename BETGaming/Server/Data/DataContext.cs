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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData
                (
                    new Category()
                    {
                        Id = 1,
                        Name = "Sandbox",
                        Url= "https://play-lh.googleusercontent.com/QS31MR9QEDSRV4V8qro8YtwT72OvUJJPpWrgyqDLwNgLcEGDe2D7EJnakRJRIhYWUw"
                    },
                    new Category()
                    {
                        Id = 2,
                       Name= "Shooters (FPS and TPS)",
                       Url = "https://www.denofgeek.com/wp-content/uploads/2021/07/Far-Cry-2.jpg"

                    },
                    new Category()
                    {
                        Id = 3,
                        Name= "Multiplayer online battle arena (MOBA)",
                        Url= "https://i.ytimg.com/vi/lD-nWRWo7NU/maxresdefault.jpg"
                    },
                    new Category()
                    {
                        Id = 4, 
                        Name= "Role-playing (RPG, ARPG, and More)",
                        Url= "https://www.giantbomb.com/a/uploads/scale_medium/9/97089/2256747-4.png"
                    },
                    new Category()
                    {
                        Id = 5,
                        Name = "Electronics",
                        Url = "https://www.giantbomb.com/a/uploads/scale_medium/9/97089/2256747-4.png"
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
                        ImageURL = "images/3.png",
                        CategoryId=1

                    },
                        new Product()
                        {
                            Id = 2,
                            Title = "Game 2",
                            Description = "The second game",
                            //Price = 2.0m,
                            ImageURL = "images/4.png",
                            CategoryId = 2

                        },
                        new Product()
                        {
                            Id = 3,
                            Title = "Game 3",
                            Description = "the third game",
                            //Price = 3.0m,
                            ImageURL = "images/3.png",
                            CategoryId = 3

                        },
                        new Product()
                        {
                            Id = 4,
                            Title = "Game 4",
                            Description = "The fourth game",
                            //Price = 4.0m,
                            ImageURL = "images/4.png",
                            CategoryId = 4

                        },
                        new Product { Id = 5, Title = "Apple iPhone 12", Description = "The latest iPhone with a 6.1-inch Super Retina XDR display.", ImageURL = "https://example.com/iphone12.jpg", CategoryId = 5 },
                        new Product { Id = 6, Title = "Samsung Galaxy S21", Description = "The latest Samsung flagship with a 6.2-inch Dynamic AMOLED 2X display.", ImageURL = "https://example.com/samsungs21.jpg", CategoryId = 5 },
                        new Product { Id = 7, Title = "Google Pixel 4a", Description = "A budget-friendly phone from Google with a 5.8-inch OLED display.", ImageURL = "https://example.com/pixel4a.jpg", CategoryId = 5 },
                        new Product { Id = 8, Title = "OnePlus 8T", Description = "A high-performance phone with a 6.55-inch Fluid AMOLED display.", ImageURL = "https://example.com/oneplus8t.jpg", CategoryId = 5 },
                        new Product { Id = 9, Title = "Sony PlayStation 5", Description = "The latest gaming console from Sony with 8K graphics and ray tracing.", ImageURL = "https://example.com/ps5.jpg", CategoryId = 5 },
                        new Product { Id = 10, Title = "Microsoft Xbox Series X", Description = "The latest gaming console from Microsoft with 4K graphics and 120fps.", ImageURL = "https://example.com/xboxseriesx.jpg", CategoryId = 5 },
                        new Product { Id = 11, Title = "Nintendo Switch", Description = "A portable gaming console from Nintendo with a 6.2-inch capacitive touchscreen.", ImageURL = "https://example.com/switch.jpg", CategoryId = 5 },
                        new Product { Id = 12, Title = "LG OLED CX Series TV", Description = "A 4K OLED TV with AI ThinQ and Google Assistant built-in.", ImageURL = "https://example.com/lgoledcx.jpg", CategoryId = 5 },
                        new Product { Id = 13, Title = "Samsung QN900A Series TV", Description = "A 8K QLED TV with Quantum Processor 8K and Alexa built-in.", ImageURL = "https://example.com/samsungqn900a.jpg", CategoryId = 5 },
                        new Product { Id = 14, Title = "Sony A8H Series TV", Description = "A 4K OLED TV with Acoustic Surface Audio and Android TV built-in.", ImageURL = "https://example.com/sonya8h.jpg", CategoryId = 5 },
                        new Product { Id = 16, Title = "The Last of Us Part II", Description = "The highly-anticipated sequel to the critically-acclaimed game.", ImageURL = "", CategoryId = 1 },
                        new Product { Id = 17, Title = "Cyberpunk 2077", Description = "An open-world RPG set in a futuristic metropolis.", ImageURL = "", CategoryId = 1 },
                        new Product { Id = 18, Title = "Horizon Zero Dawn", Description = "An action RPG set in a post-apocalyptic world ruled by robotic creatures.", ImageURL = "", CategoryId = 1 },
                        new Product { Id = 19, Title = "Red Dead Redemption 2", Description = "An epic tale of life in America's unforgiving heartland.", ImageURL = "", CategoryId = 1 },
                        new Product { Id = 20, Title = "The Witcher 3: Wild Hunt", Description = "An open-world action RPG based on the bestselling fantasy series.", ImageURL = "", CategoryId = 1 },
                        new Product { Id = 21, Title = "Death Stranding", Description = "An action game developed by Hideo Kojima, creator of the Metal Gear series.", ImageURL = "", CategoryId = 1 },
                        new Product { Id = 22, Title = "The Legend of Zelda: Breath of the Wild", Description = "An open-air adventure game set in a vast wilderness.", ImageURL = "", CategoryId = 1 },
                        new Product { Id = 23, Title = "Super Mario Odyssey", Description = "A 3D platformer featuring Mario's first sandbox-style gameplay.", ImageURL = "", CategoryId = 1 },
                        new Product { Id = 24, Title = "Persona 5", Description = "A role-playing game that follows a group of high school students.", ImageURL = "", CategoryId = 1 },
                        new Product { Id = 25, Title = "Final Fantasy VII Remake", Description = "A modern retelling of the classic RPG.", ImageURL = "", CategoryId = 1 },
                        new Product { Id = 26, Title = "Monster Hunter: World", Description = "A game where players take on the role of a hunter and slay different monsters", ImageURL = "", CategoryId = 1 },
                        new Product { Id = 27, Title = "Overwatch", Description = "A team-based first-person shooter game developed by Blizzard Entertainment.", ImageURL = "" , CategoryId = 1 },
                        //...
                        new Product { Id = 28, Title = "Minecraft", Description = "A sandbox game where players can build and explore virtual worlds.", ImageURL = "", CategoryId = 1 }

                );
        }




    }
}
