
using static System.Net.WebRequestMethods;

namespace BETGaming.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        public List<Product> Products { get; set; } = new List<Product>();
        private  HttpClient HttpClient { get; }

        public ProductService(HttpClient httpClient) 
        {
            HttpClient = httpClient;
        } 
        

        public async Task GetProducts()
        {
            var result = await HttpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/Product");
            if (result != null && result.Data != null)
                Products = result.Data;
        }
    }
}
