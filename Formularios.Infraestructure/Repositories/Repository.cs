using Formularios.Domain.Interfaces;
using Formularios.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;


namespace Formularios.Infraestructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(DataContext dbContext)
        {
            _context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = dbContext.Set<T>();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int entityId)
        {
            return await _dbSet.FindAsync(entityId);
        }

        public Task AddAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            _dbSet.Add(entity);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            _dbSet.Update(entity);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int entityId)
        {
            var entity = await GetByIdAsync(entityId);

            if (entity == null) throw new ArgumentNullException(nameof(entity));
            {
                _dbSet.Remove(entity);
            }
        }
    }
}
