using Core.Entities.Alumno;
using Infrastructure.Queries.interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Dapper;

namespace Infrastructure.Queries
{
    public class DocenteQuery : IDocenteQuery
    {
        private readonly string ConnectionString;
        public DocenteQuery(IConfiguration configuration)
        {
            //Deberá modificar la cadena de conexión antes de ejecutar

            ConnectionString = ConfigurationExtensions.GetConnectionString(configuration, "PruebaTecnicaDB");
        }
        public async Task<List<Alumno>> ListarAlumnosDocente(int IdDocente)
        {
            List<Alumno> lst = new List<Alumno>();
            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string storedProcedureName = "XYZ_SP_API_DOCENTE_ALUMNOS_SEL";
                    var param = new DynamicParameters();
                    param.Add("@PARAM_IN_ID_DOCENTE", IdDocente);

                    var result = await cn.QueryAsync(storedProcedureName, param, commandType: CommandType.StoredProcedure);
                    foreach (var item in result)
                    {
                        Alumno oAlumno = new Alumno();
                        oAlumno.IdAlumno = Convert.ToInt32(item.IN_ID_ALUMNO);
                        oAlumno.Nombre = Convert.ToString(item.VC_NOMBRES);
                        oAlumno.Apellido = Convert.ToString(item.VC_APELLIDOS);
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
