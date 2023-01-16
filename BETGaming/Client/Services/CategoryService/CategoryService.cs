namespace BETGaming.Client.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        public List<Category> Categories { get ; set ; } = new List<Category>();
        public HttpClient HttpClient { get; }

        public CategoryService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }
        public async Task GetCategories()
        {
            var result = await HttpClient.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/Category");
            if (result != null && result.Data != null)
                Categories = result.Data;
        }
    }
}
