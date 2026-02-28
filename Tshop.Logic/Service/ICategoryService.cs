using Tshop.Data.DTO.Request;
using Tshop.Data.DTO.Response;

namespace Tshop.BLL.Service
{
    public interface ICategoryService
    {
        Task <List<CategoryResponse>> GetAllCategories();
        Task <CategoryResponse> CreateCategory(CategoryRequest request);
    }
}