using Formularios.Domain.Interfaces;
using Formularios.Domain.Models;

namespace Formularios.Infraestructure.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        IFormularioRepository<Formulario> FormularioRepository { get; }
        IFormularioCampoRepository<FormularioCampo> FormularioCampoRepository { get; }
        IFormularioRespuestaRepository<FormularioRespuesta> FormularioRespuestaRepository { get; }

        Task SaveChangesAsync();
    }
}
