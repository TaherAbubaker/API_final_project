using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tshop.Data.Data;
using Tshop.Data.Models;

namespace Tshop.Data.Repository
{
    public class CategoryRepository : GenericRepository<Category> , ICategoryRepository
    {
       public CategoryRepository(ApplicationDBContext context) : base(context)
        {

        }
    }
}