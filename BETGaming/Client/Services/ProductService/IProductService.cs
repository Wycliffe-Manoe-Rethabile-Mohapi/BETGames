namespace BETGaming.Client.Services.ProductService
{
    public interface IProductService
    {
        public string Message { get; set; }
        event Action ProductsChanged;
        public List<Product> Products { get; set; }
        Task GetProducts(string? categoryUrl = null);
        Task<ServiceResponse<Product>> GetProduct(int productId);
        Task SearchProducts(string searchString);
        Task<List<string>> GetProductSearchSuggestions(string searchString);
    }
}
