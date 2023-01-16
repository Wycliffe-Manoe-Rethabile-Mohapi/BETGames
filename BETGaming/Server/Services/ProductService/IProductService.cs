using BETGaming.Server.Data;
using Microsoft.AspNetCore.Mvc;

namespace BETGaming.Server.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> GetProductsAsync();
    }
}
