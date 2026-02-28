using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tshop.Data.Models;

namespace Tshop.Data.Data
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryTranslate> CategoryTranslates { get; set; }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            :base(options)
        {

        }
    }
}
