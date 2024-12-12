
namespace Formularios.Domain.Models
{
    public class FormularioRespuesta
    {
        public int Id { get; set; }
        public int FormularioId { get; set; }
        public string Respuesta { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaRespuesta { get; set; }

        public Formulario Formulario { get; set; }
        public ApplicationUser Usuario { get; set; }
    }
}
