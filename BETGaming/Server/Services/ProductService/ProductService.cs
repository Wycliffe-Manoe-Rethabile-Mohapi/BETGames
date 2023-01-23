using BETGaming.Server.Data;
using Microsoft.AspNetCore.Mvc;
using System.Text;

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
                .Where(s => s.Variants.Count > 0)
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
                .Where(s => s.Variants.Count > 0)
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
                .Where(s=>s.Variants.Count>0)
                .ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText)
        {
            var products = await FindProductsBySearchTerm(searchText);

            List<string> results = new List<string>();

            foreach (var product in products) 
            {
                if (product.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                {
                    results.Add(product.Title);
                }

                if (product.Description!=null)
                {
                    var punctuation = product.Description.Where(char.IsPunctuation)
                        .Distinct()
                        .ToArray();
                    var words = product.Description.Split()
                        .Select(s => s.Trim(punctuation));

                    foreach (var word in words)
                    {
                        if (word.Contains(searchText, StringComparison.OrdinalIgnoreCase) && !results.Contains(word))
                        {
                            results.Add(word);
                        }
                    }

                }
            }

            return new ServiceResponse<List<string>>()
            {
                Data = results
            };
        }

        public async Task<ServiceResponse<List<Product>>> SearchProductsAsync(string searchText)
        {
            var response = new ServiceResponse<List<Product>>();
            var products = await FindProductsBySearchTerm(searchText);
            response.Data = products;
            return response;
        }

        private async Task<List<Product>> FindProductsBySearchTerm(string searchText)
        {
            return await _context.Products.Where(s => s.Title.ToLower().Contains(searchText.ToLower()) || s.Description.ToLower().Contains(searchText.ToLower()))
                            .Include(s => s.Variants)
                            .Where(s => s.Variants.Count > 0)
                            .ToListAsync();
        }
    }
}
