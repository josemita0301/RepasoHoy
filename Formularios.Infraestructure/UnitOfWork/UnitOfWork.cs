using Formularios.Domain.Interfaces;
using Formularios.Domain.Models;
using Formularios.Infraestructure.Data;
using Formularios.Infraestructure.Repositories;

namespace Formularios.Infraestructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;

        public IFormularioRepository<Formulario> FormularioRepository { get; }
        public IFormularioCampoRepository<FormularioCampo> FormularioCampoRepository { get; }
        public IFormularioRespuestaRepository<FormularioRespuesta> FormularioRespuestaRepository { get; }

        public UnitOfWork(
            DataContext dataContext,
            IFormularioRepository<Formulario> formularioRepository,
            IFormularioCampoRepository<FormularioCampo> formularioCampoRepository,
            IFormularioRespuestaRepository<FormularioRespuesta> formularioRespuestaRepository)
        {
            _dataContext = dataContext;
            FormularioRepository = formularioRepository;
            FormularioCampoRepository = formularioCampoRepository;
            FormularioRespuestaRepository = formularioRespuestaRepository;
        }

        public Task SaveChangesAsync()
        {
            return _dataContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dataContext.DisposeAsync();
        }
    }
}
