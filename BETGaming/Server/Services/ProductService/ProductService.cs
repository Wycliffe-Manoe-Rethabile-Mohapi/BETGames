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
            var product = await _context.Products
                .Include(s=>s.Variants)
                .ThenInclude(s=>s.ProductType)
                .FirstOrDefaultAsync(s=>s.Id== productId);

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
                Data= await _context.Products
                .Include(s => s.Variants)
                .ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsByCategoryAsync(string categoryUrl)
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Data =  await _context.Products.Where(s => s.Category.Url.ToLower().Equals(categoryUrl.ToLower()))
                .Include(s => s.Variants)
                .ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<List<Product>>> SearchProductsAsync(string searchText)
        {
            var response = new ServiceResponse<List<Product>>();

            var result = await _context.Products.Where(s => s.Title.ToLower().Contains(searchText.ToLower()) || s.Description.ToLower().Contains(searchText.ToLower()))
                .Include(s => s.Variants)
                .ToListAsync();
            response.Data = result;
            return response;
        }
    }
}
