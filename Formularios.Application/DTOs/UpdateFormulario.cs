using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formularios.Application.DTOs
{
    public class UpdateFormulario
    {
      public string Nombre { get; set; } = string.Empty;
        public List<UpdateFormularioCampo> Campos { get; set; } = new();


       
    }

    public class UpdateFormularioCampo
    {
        public int Id { get; set; } // 0 o negativo para nuevos campos
        public string Nombre { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
    }
}
