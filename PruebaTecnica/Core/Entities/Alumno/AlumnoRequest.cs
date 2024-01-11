using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Alumno
{
    public class AlumnoRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
