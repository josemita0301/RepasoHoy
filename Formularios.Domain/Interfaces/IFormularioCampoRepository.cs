using Formularios.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formularios.Domain.Interfaces
{
    public interface IFormularioCampoRepository<T> : IRepository<T> where T : class
    {
        Task<IEnumerable<FormularioCampo>> GetByFormularioIdAsync(int formularioId);
    }
}
