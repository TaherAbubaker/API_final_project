using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tshop.Data.Models;

namespace Tshop.Data.Repository
{
    public interface IGenericRepository <T> where  T : class
    {
        Task<T> CreateAsync(T category);
        Task<List<T>> GetAllAsync();

    }
}
