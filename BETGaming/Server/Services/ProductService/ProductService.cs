using BETGaming.Server.Data;
using Microsoft.AspNetCore.Mvc;

namespace BETGaming.Server.Services.ProductService
{
    public class ProductService:IProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext dataContext)
        {
            this._context = dataContext;
        }

        public async Task<ServiceResponse<Product>> GetProductAsync(int productId)
        {
            var response = new ServiceResponse<Product>();
            var product = await _context.Products.FindAsync(productId);
            if (product==null)
            {
                response.Success = false;
                response.Message = "Sorry, Could not find the product.";

            }
            else
            {
                response.Data = product;
            }

            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
        {
            var response = new ServiceResponse<List<Product>>() {
                Data= await _context.Products.ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsByCategoryAsync(string categoryUrl)
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Data =  await _context.Products.Where(s => s.Category.Url.ToLower().Equals(categoryUrl.ToLower())).ToListAsync()
            };

            return response;
        }
    }
}
