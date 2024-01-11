using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Alumno
{
    public class Alumno
    {
        public int IdAlumno { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int IdAula { get; set; }
        public string Etapa { get; set; }
        public string Grado { get; set; }
        public string Seccion { get; set; }
    }
}
