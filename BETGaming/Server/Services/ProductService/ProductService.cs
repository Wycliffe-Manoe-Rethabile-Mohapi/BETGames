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

        public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
        {
            var response = new ServiceResponse<List<Product>>() {
                Data= await _context.Products.ToListAsync()
            };

            return response;
        }
    }
}
