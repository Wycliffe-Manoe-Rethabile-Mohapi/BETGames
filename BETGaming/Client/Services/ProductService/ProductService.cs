
using BETGaming.Shared;
using static System.Net.WebRequestMethods;

namespace BETGaming.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        public List<Product> Products { get; set; } = new List<Product>();
        private  HttpClient HttpClient { get; }
        public string Message { get; set; } = string.Empty;
        public int CurrentPage { get; set; } = 1;
        public int PageCount { get; set; } = 0;
        public string LastSearchText { get; set; } = string.Empty;

        public event Action ProductsChanged;


        public ProductService(HttpClient httpClient) 
        {
            HttpClient = httpClient;
        }

        
        public async Task GetProducts(string? categoryUrl = null)
        {
            var result = categoryUrl == null ?
                await HttpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/Product/featured") :
                await HttpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/Product/category/{categoryUrl}");

            if (result != null && result.Data != null)
                Products = result.Data;

            CurrentPage = 1;
            PageCount = 0;
            if (Products.Count == 0)
                Message = "No products found";

            if (ProductsChanged!=null)
            {
                ProductsChanged.Invoke();
            }
            
        }

        public async Task<ServiceResponse<Product>> GetProduct(int productId)
        {
            var result = await HttpClient.GetFromJsonAsync<ServiceResponse<Product>>($"api/Product/{productId}");

            return result;
        }

        public async Task SearchProducts(string searchString, int page)
        {
            LastSearchText = searchString;
            var result = await HttpClient.GetFromJsonAsync<ServiceResponse<ProductSearchRespomse>>($"api/Product/search/{searchString}/{page}");

            if (result!=null && result.Data!=null)
            {
                Products = result.Data.Products;
                CurrentPage = result.Data.CurrentPage;
                PageCount = result.Data.Pages;
            }

            if (Products.Count == 0) Message = "no products found";

            if (ProductsChanged!=null) 
            {   
                ProductsChanged.Invoke();
            }
        }

        public async Task<List<string>> GetProductSearchSuggestions(string searchString)
        {
            var result = await HttpClient.GetFromJsonAsync<ServiceResponse<List<string>>>($"api/Product/searchsuggestions/{searchString}");

            return result.Data;


        }
    }
}
