using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formularios.Application.DTOs
{
    public class CreateFormulario
    {
        public string Nombre { get; set; } = string.Empty;
        public List<CreateFormularioCampo> Campos { get; set; } = new();
    }
    public class CreateFormularioCampo
    {
        public string Nombre { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
    }
}
