
using System.Text.Json.Serialization;

namespace Formularios.Domain.Models
{
    public class FormularioCampo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }


        public int FormularioId { get; set; }

        [JsonIgnore]
        public Formulario Formulario { get; set; }
    }
}
