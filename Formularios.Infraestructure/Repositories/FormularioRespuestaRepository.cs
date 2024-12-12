using Formularios.Domain.Interfaces;
using Formularios.Domain.Models;
using Formularios.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formularios.Infraestructure.Repositories
{
    public class FormularioRespuestaRepository : Repository<FormularioRespuesta>, IFormularioRespuestaRepository<FormularioRespuesta>
    {
        private readonly DataContext _dbContext;
        public FormularioRespuestaRepository(DataContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
