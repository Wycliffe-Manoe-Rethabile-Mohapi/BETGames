using BETGaming.Server.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BETGaming.Server.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> GetProductsAsync();
        Task<ServiceResponse<Product>> GetProductAsync(int productId);
        Task<ServiceResponse<List<Product>>> GetProductsByCategoryAsync(string CategoryUrl);
        Task<ServiceResponse<ProductSearchRespomse>> SearchProductsAsync(string searchText, int page);
        Task<ServiceResponse<List<String>>> GetProductSearchSuggestionsAsync(string searchText);
        Task<ServiceResponse<List<Product>>> GetFeaturedProductsAsync();

    }
}
