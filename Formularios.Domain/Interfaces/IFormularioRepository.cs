using Formularios.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formularios.Domain.Interfaces
{
    public interface IFormularioRepository<T> : IRepository<T> where T : class
    {
        Task<IEnumerable<Formulario>> GetByUsuarioIdAsync(int usuarioId);
    }
}
