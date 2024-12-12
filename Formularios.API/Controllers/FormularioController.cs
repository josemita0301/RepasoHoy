using Formularios.Application.DTOs;
using Formularios.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Formularios.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class FormularioController : ControllerBase
    {
        private readonly FormularioService _formularioService;

        public FormularioController(FormularioService formularioService)
        {
            _formularioService = formularioService;
        }

        /// <summary>
        /// Obtiene todos los formularios.
        /// </summary>
        /// <returns>Una lista de formularios.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFormularios()
        {
            var formularios = await _formularioService.ObtenerFormulariosAsync();
            return Ok(formularios);
        }

        /// <summary>
        /// Obtiene los formularios de un usuario específico.
        /// </summary>
        /// <param name="usuarioId">El ID del usuario.</param>
        /// <returns>Una lista de formularios asociados al usuario.</returns>
        [HttpGet("usuario/{usuarioId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFormulariosPorUsuario(int usuarioId)
        {
            var formularios = await _formularioService.ObtenerFormulariosPorUsuarioAsync(usuarioId);
            if (formularios == null || !formularios.Any())
            {
                return NotFound("No se encontraron formularios para el usuario especificado.");
            }
            return Ok(formularios);
        }

        /// <summary>
        /// Obtiene un formulario por su ID.
        /// </summary>
        /// <param name="id">El ID del formulario.</param>
        /// <returns>El formulario correspondiente.</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFormularioPorId(int id)
        {
            var formulario = await _formularioService.ObtenerFormulariosPorUsuarioAsync(id);
            if (formulario == null)
            {
                return NotFound($"No se encontró el formulario con ID {id}.");
            }
            return Ok(formulario);
        }

        /// <summary>
        /// Crea un nuevo formulario.
        /// </summary>
        /// <param name="usuarioId">El ID del usuario asociado.</param>
        /// <param name="dto">Datos para crear el formulario.</param>
        /// <returns>El formulario creado.</returns>
        [HttpPost("{usuarioId:int}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CrearFormulario(int usuarioId, [FromBody] CreateFormulario dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var formulario = await _formularioService.CrearFormularioAsync(usuarioId, dto);
            return CreatedAtAction(nameof(GetFormularioPorId), new { id = formulario.Id }, formulario);
        }

        /// <summary>
        /// Actualiza un formulario existente.
        /// </summary>
        /// <param name="id">El ID del formulario a actualizar.</param>
        /// <param name="dto">Datos para actualizar el formulario.</param>
        /// <returns>Estado de la operación.</returns>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ActualizarFormulario(int id, [FromBody] UpdateFormulario dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _formularioService.ActualizarFormularioAsync(id, dto);
            return NoContent();
        }

        /// <summary>
        /// Elimina un formulario por su ID.
        /// </summary>
        /// <param name="id">El ID del formulario a eliminar.</param>
        /// <returns>Estado de la operación.</returns>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EliminarFormulario(int id)
        {
            await _formularioService.EliminarFormularioAsync(id);
            return NoContent();
        }

    }
}
