using Formularios.Domain.Interfaces;
using Formularios.Domain.Models;
using Formularios.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Formularios.Infraestructure.Repositories
{
    public class FormularioCampoRepository : Repository<FormularioCampo>, IFormularioCampoRepository<FormularioCampo>
    {
        private readonly DataContext _dbContext;

        public FormularioCampoRepository(DataContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<FormularioCampo>> GetByFormularioIdAsync(int formularioId)
        {
            return await _dbContext.FormularioCampo
                .Where(c => c.FormularioId == formularioId)
                .ToListAsync();
        }
    }
}
