using Tshop.Data.DTO.Request;
using Tshop.Data.DTO.Response;
using Tshop.Data.Models;
using System.Linq.Expressions;

namespace Tshop.BLL.Service
{
    public interface ICategoryService
    {
        Task<List<CategoryResponse>> GetAllCategories();
        Task<CategoryResponse> CreateCategory(CategoryRequest request);

        Task<CategoryResponse?> GetCategory(Expression<Func<Category, bool>> filter);
    }
}