using Core.Entities;
using Core.Entities.Alumno;
using Dapper;
using Infrastructure.Queries.interfaces;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Infrastructure.Queries
{
    public class AlumnoQuery : IAlumnoQuery
    {
        private readonly string ConnectionString;
        public AlumnoQuery(IConfiguration configuration)
        {
            //Deberá modificar la cadena de conexión antes de ejecutar

            ConnectionString = ConfigurationExtensions.GetConnectionString(configuration, "PruebaTecnicaDB");
        }
        public async Task<string> ActualizarAlumno(AlumnoRequest alumno)
        {
            string mensaje = "";
            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string storedProcedureName = "XYZ_SP_API_ALUMNO_UPD";
                    var param = new DynamicParameters();
                    param.Add("@PARAM_IN_ID_ALUMNO", alumno.Id);
                    param.Add("@PARAM_VC_NOMBRES", alumno.Nombre);
                    param.Add("@PARAM_VC_APELLIDOS", alumno.Apellido);

                    var result = await cn.QueryAsync(storedProcedureName, param, commandType: CommandType.StoredProcedure);
                    foreach (var item in result)
                    {
                        mensaje = Convert.ToString(item.VC_MENSAJE);
                    }
                    return mensaje;
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public async Task<string> AsignarAulaAlumno(int IdAula, int IdAlumno)
        {
            string mensaje = "";
            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string storedProcedureName = "XYZ_SP_API_ASIGNAR_ALUMNO_AULA";
                    var param = new DynamicParameters();
                    param.Add("@PARAM_IN_ID_AULA", IdAula);
                    param.Add("@PARAM_IN_ID_ALUMNO", IdAlumno);

                    var result = await cn.QueryAsync(storedProcedureName, param, commandType: CommandType.StoredProcedure);
                    foreach (var item in result)
                    {
                        mensaje = Convert.ToString(item.VC_MENSAJE);
                    }
                    return mensaje;
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public Task CrearAlumno()
        {
            throw new NotImplementedException();
        }

        public async Task<string> EliminarAlumnoDeAula(int idAlumno)
        {
            string mensaje = "";
            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string storedProcedureName = "XYZ_SP_API_ALUMNO_DELETE";
                    var param = new DynamicParameters();
                    param.Add("@PARAM_IN_ID_ALUMNO", idAlumno);

                    var result = await cn.QueryAsync(storedProcedureName, param, commandType: CommandType.StoredProcedure);
                    foreach (var item in result)
                    {
                        mensaje = Convert.ToString(item.VC_MENSAJE);
                    }
                    return mensaje;
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public async Task<List<Alumno>> ListarAlumnos()
        {
            List<Alumno> lst = new List<Alumno>();
            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string storedProcedureName = "XYZ_SP_API_ALUMNOS_SEL";

                    var result = await cn.QueryAsync(storedProcedureName, commandType: CommandType.StoredProcedure);
                    foreach (var item in result)
                    {
                        Alumno oAlumno = new Alumno();
                        oAlumno.IdAlumno = Convert.ToInt32(item.IN_ID_ALUMNO);
                        oAlumno.IdAula = Convert.ToInt32(item.IN_ID_AULA);
                        oAlumno.Nombre = Convert.ToString(item.VC_NOMBRES);
                        oAlumno.Apellido = Convert.ToString(item.VC_APELLIDOS);
                        oAlumno.Etapa = Convert.ToString(item.VC_ETAPA);
                        oAlumno.Grado = Convert.ToString(item.CH_GRADO);
                        oAlumno.Seccion = Convert.ToString(item.CH_SECCION);
                        lst.Add(oAlumno);
                    }
                    return lst;
                }
            }
            catch (Exception ex)
            {
                lst = new List<Alumno>();
                return lst;
            }
        }
    }
}
