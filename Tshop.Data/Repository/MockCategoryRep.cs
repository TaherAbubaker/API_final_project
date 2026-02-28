using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tshop.Data.Models;

namespace Tshop.Data.Repository
{
    internal class MockCategoryRep : ICategoryRepository
    {
        private readonly List<Category> _categories = new();

        public Task<Category> CreateAsync(Category category)
        {
            // Assign an ID just like a DB would
            category.Id = _categories.Count + 1;
            _categories.Add(category);
            return Task.FromResult(category);
        }

        public Task<List<Category>> GetAllAsync()
        {
            return Task.FromResult(_categories.ToList());
        }
    }
}