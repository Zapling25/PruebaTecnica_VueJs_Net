using Core.Entities;
using Core.Entities.Alumno;

namespace Infrastructure.Queries.interfaces
{
    public interface IAlumnoQuery
    {
        Task<List<Alumno>> ListarAlumnos();
        Task<string> AsignarAulaAlumno(int IdAula, int IdAlumno);
        Task<string> CrearAlumno(CrearAlumnoRequest alumno);
        Task<string> ActualizarAlumno(AlumnoRequest alumno);
        Task<string> EliminarAlumnoDeAula(int idAlumno);
    }
}
