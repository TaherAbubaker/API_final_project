using Mapster;
using Tshop.Data.DTO.Request;
using Tshop.Data.DTO.Response;
using Tshop.Data.Models;
using Tshop.Data.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Tshop.BLL.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // Create category and its translations asynchronously
        public async Task<CategoryResponse> CreateCategory(CategoryRequest request)
        {
            if (request.translations == null || !request.translations.Any())
                throw new ArgumentException("At least one translation is required");

            var defaultTranslation = request.translations.First();

            var category = new Category
            {
                Name = defaultTranslation.name,
                translations = request.translations.Select(t => new CategoryTranslate
                {
                    Name = t.name,
                    Language = t.Language
                }).ToList()
            };

            // Save asynchronously via repository
            var created = await _categoryRepository.CreateAsync(category);

            // Map to DTO for API response
            return created.Adapt<CategoryResponse>();
        }

        // Get all categories with translations asynchronously
        public async Task<List<CategoryResponse>> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return categories.Adapt<List<CategoryResponse>>();
        }
    }
}