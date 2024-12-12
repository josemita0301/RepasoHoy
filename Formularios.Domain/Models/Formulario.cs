namespace Formularios.Domain.Models
{
    public class Formulario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }
        public int UsuarioId { get; set; }

        public ApplicationUser Usuario { get; set; }
        public ICollection<FormularioCampo> Campos { get; set; }
        public ICollection<FormularioRespuesta> Respuestas { get; set; }

    }
}
