using Formularios.Domain.Interfaces;
using Formularios.Domain.Models;
using Formularios.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formularios.Infraestructure.Repositories
{
    public class FormularioRepository : Repository<Formulario>, IFormularioRepository<Formulario>
    {
        private readonly DataContext _dbContext;
        public FormularioRepository(DataContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Formulario>> GetByUsuarioIdAsync(int usuarioId)
        {
            return await _dbContext.Formulario
                .Include(f => f.Campos)
                .Where(f => f.UsuarioId == usuarioId)
                .ToListAsync();
        }
    }
}
