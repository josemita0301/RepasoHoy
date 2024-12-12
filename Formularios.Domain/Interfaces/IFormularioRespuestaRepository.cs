using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formularios.Domain.Interfaces
{
    public interface IFormularioRespuestaRepository<T> : IRepository<T> where T : class
    {
    }
}
