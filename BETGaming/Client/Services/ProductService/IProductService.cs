namespace BETGaming.Client.Services.ProductService
{
    public interface IProductService
    {
        public string Message { get; set; }
        event Action ProductsChanged;
        public List<Product> Products { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public string LastSearchText { get; set; }
        Task GetProducts(string? categoryUrl = null);
        Task<ServiceResponse<Product>> GetProduct(int productId);
        Task SearchProducts(string searchString, int page);
        Task<List<string>> GetProductSearchSuggestions(string searchString);
    }
}
