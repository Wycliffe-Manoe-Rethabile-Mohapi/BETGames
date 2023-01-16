using BETGaming.Server.Data;
using System.Runtime.Serialization;

namespace BETGaming.Server.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        public  CategoryService(DataContext context)
        {
            _Context = context;
        }

        public DataContext _Context { get; }

        public async Task<ServiceResponse<List<Category>>> GetCategories()
        {
            var result = new ServiceResponse<List<Category>>()
            {
                Data = await _Context.Categories.ToListAsync()
            };

            return result;

        }
    }
}
