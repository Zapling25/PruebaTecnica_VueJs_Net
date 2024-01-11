using Infrastructure.Queries.interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Core.Entities.Alumno;
using Core.Entities;

namespace PruebaTecnicaAPI.Controllers
{
    [ApiController]
    [Route("alumno")]
    public class AlumnoController : ControllerBase
    {
        private readonly IAlumnoQuery _alumnoQuery;

        public AlumnoController(IAlumnoQuery alumnoQuery)
        {
            _alumnoQuery = alumnoQuery;
        }

        [Route("listar")]
        [HttpGet]
        public List<Alumno> ListarAlumnos()
        {
            List<Alumno> lstAlumnos = _alumnoQuery.ListarAlumnos().Result;
            return lstAlumnos;
        }

        [Route("asignarAula")]
        [HttpPost]
        public ResponseModel AsignarAlumnoAula(int IdAula, int IdAlumno)
        {
            ResponseModel response = new ResponseModel();
            response.Mensaje = _alumnoQuery.AsignarAulaAlumno(IdAula, IdAlumno).Result;
            return response;
        }

        [Route("actualizar")]
        [HttpPut]
        public ResponseModel ActualizarAlumno(AlumnoRequest oAlumno)
        {
            ResponseModel response = new ResponseModel();
            response.Mensaje = _alumnoQuery.ActualizarAlumno(oAlumno).Result;
            return response;
        }

        [Route("eliminar")]
        [HttpDelete]
        public ResponseModel EliminarAlumno(int IdAlumno)
        {
            ResponseModel response = new ResponseModel();
            response.Mensaje = _alumnoQuery.EliminarAlumnoDeAula(IdAlumno).Result;
            return response;
        }
    }
}
