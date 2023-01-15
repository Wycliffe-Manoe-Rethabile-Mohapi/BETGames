using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BETGaming.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> Products = new List<Product>
        {
            new Product()
            {
                Id  =   1,
                Title = "Game 1",
                Description = "The first game",
                Price = 1.0m,
                ImageURL = "images/3.png"

            },
             new Product()
            {
                Id  =   2,
                Title = "Game 2",
                Description = "The second game",
                Price = 2.0m,
                ImageURL = "images/4.png"

            },
             new Product()
            {
                Id  =   3,
                Title = "Game 3",
                Description = "the third game",
                Price = 3.0m,
                ImageURL = "images/3.png"

            },
             new Product()
            {
                Id  =   4,
                Title = "Game 4",
                Description = "The fourth game",
                Price = 4.0m,
                ImageURL = "images/4.png"

            },
        };

        [HttpGet]
        public  async Task<ActionResult<List<Product>>> GetProducts()
        {
            return  Ok(Products);
        }
    }
}
