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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData
                (
                    new Product()
                    {
                        Id = 1,
                        Title = "Game 1",
                        Description = "The first game",
                        Price = 1.0m,
                        ImageURL = "images/3.png"

                    },
                        new Product()
                        {
                            Id = 2,
                            Title = "Game 2",
                            Description = "The second game",
                            Price = 2.0m,
                            ImageURL = "images/4.png"

                        },
                        new Product()
                        {
                            Id = 3,
                            Title = "Game 3",
                            Description = "the third game",
                            Price = 3.0m,
                            ImageURL = "images/3.png"

                        },
                        new Product()
                        {
                            Id = 4,
                            Title = "Game 4",
                            Description = "The fourth game",
                            Price = 4.0m,
                            ImageURL = "images/4.png"

                        }

                );
        }




    }
}
