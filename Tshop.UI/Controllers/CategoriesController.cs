using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Tshop.BLL.Service;
using Tshop.Data.DTO.Request;
using Tshop.Data.DTO.Response;
using Tshop.UI.Resources;

namespace Tshop.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly ICategoryService _categoryService;

        public CategoriesController(
            ICategoryService categoryService,
            IStringLocalizer<SharedResources> localizer)
        {
            _categoryService = categoryService;
            _localizer = localizer;
        }

        // POST: api/Categories
        [HttpPost]
        public async Task<IActionResult> Create(CategoryRequest request)
        {
            if (request.translations == null || !request.translations.Any())
                return BadRequest("At least one translation is required");

            // Await the async service call
            var created = await _categoryService.CreateCategory(request);

            return Ok(new
            {
                data = created,
                message = _localizer["Success"].Value
            });
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // Await the async service call
            var categories = await _categoryService.GetAllCategories();

            return Ok(new
            {
                data = categories,
                message = _localizer["Success"].Value
            });
        }
    }
}