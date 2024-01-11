using Core.Entities.Alumno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Queries.interfaces
{
    public interface IDocenteQuery
    {
        Task<List<Alumno>> ListarAlumnosDocente(int IdDocente);
    }
}
