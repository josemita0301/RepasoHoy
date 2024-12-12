using Formularios.Application.DTOs;
using Formularios.Domain.Models;
using Formularios.Infraestructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Formularios.Application.Services
{
    public class FormularioService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FormularioService(IUnitOfWork unitOfWork) // Ahora recibe la interfaz
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Formulario>> ObtenerFormulariosAsync()
        {
            return await _unitOfWork.FormularioRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Formulario>> ObtenerFormulariosPorUsuarioAsync(int usuarioId)
        {
            return await _unitOfWork.FormularioRepository.GetByUsuarioIdAsync(usuarioId);
        }

        public async Task<Formulario?> ObtenerFormularioPorIdAsync(int id)
        {
            return await _unitOfWork.FormularioRepository.GetByIdAsync(id);
        }

        public async Task<Formulario> CrearFormularioAsync(int usuarioId, CreateFormulario dto)
        {
            var formulario = new Formulario
            {
                UsuarioId = usuarioId,
                Nombre = dto.Nombre,
                FechaCreacion = DateTime.UtcNow,
                Campos = dto.Campos.Select(c => new FormularioCampo
                {
                    Nombre = c.Nombre,
                    Tipo = c.Tipo
                }).ToList()
            };

            await _unitOfWork.FormularioRepository.AddAsync(formulario);
            await _unitOfWork.SaveChangesAsync();
            return formulario;
        }

        public async Task ActualizarFormularioAsync(int id, UpdateFormulario dto)
        {
            var formulario = await ObtenerFormularioPorIdAsync(id);
            if (formulario == null)
            {
                throw new KeyNotFoundException("Formulario no encontrado");
            }

            formulario.Nombre = dto.Nombre;
            formulario.Campos = dto.Campos.Select(c => new FormularioCampo
            {
                Id = c.Id != 0 ? c.Id : 0,
                Nombre = c.Nombre,
                Tipo = c.Tipo,
                FormularioId = formulario.Id
            }).ToList();

            await _unitOfWork.FormularioRepository.UpdateAsync(formulario);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EliminarFormularioAsync(int id)
        {
            var formulario = await _unitOfWork.FormularioRepository.GetByIdAsync(id);
            if (formulario == null) throw new KeyNotFoundException();

            var camposAsociados = await _unitOfWork.FormularioCampoRepository.GetByFormularioIdAsync(id);
            foreach (var campo in camposAsociados)
            {
                await _unitOfWork.FormularioCampoRepository.DeleteAsync(campo.Id);
            }
            await _unitOfWork.SaveChangesAsync();

            // Ahora eliminar el formulario
            await _unitOfWork.FormularioRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
