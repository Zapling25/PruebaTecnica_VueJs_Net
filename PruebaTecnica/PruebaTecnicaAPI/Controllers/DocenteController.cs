using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Core.Entities.Alumno;
using Infrastructure.Queries.interfaces;

namespace PruebaTecnicaAPI.Controllers
{
    [ApiController]
    [Route("docente")]
    public class DocenteController : Controller
    {
        private readonly IDocenteQuery _docenteQuery;

        public DocenteController(IDocenteQuery docenteQuery)
        {
            _docenteQuery = docenteQuery;
        }

        [Route("listarAlumnos")]
        [HttpGet]
        public List<Alumno> ListarAlumnos(int IdDocente)
        {
            List<Alumno> lstAlumnos = _docenteQuery.ListarAlumnosDocente(IdDocente).Result;
            return lstAlumnos;
        }
    }
}
