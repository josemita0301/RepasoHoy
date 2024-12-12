using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formularios.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int entityId);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int entityId);
    }
}
