using DescripcionCargos.Models;
using System.Data.SqlClient;
using static DescripcionCargos.Core.Interfaces;

namespace DescripcionCargos.Core
{
	public class Empleados : IEmpleado
	{
        private readonly IConfiguration _configuration;
        public Empleados(IConfiguration configuration)
		{
            this._configuration = configuration;
        }

        public EmpleadoModel ObtenerPorCedula(double cedula)
        {
            try
            {
                EmpleadoModel employee = new();
                using SqlConnection sqlConnection = new(_configuration.GetConnectionString("connectionString"));
                sqlConnection.Open();
                SqlCommand cmd = new($"SELECT * FROM View_ObtenerEmpleados Where Cedula = {cedula}", sqlConnection);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    employee.Cedula = (double)dr["Cedula"];
                    employee.PersonalId = (int)dr["PersonalId"];
                    employee.PrimerNombreEmpleado = (string)dr["PrimerNombreEmpleado"];
                    employee.PrimerApellidoEmpleado = (string)dr["PrimerApellidoEmpleado"];
                    employee.SegundoNombreEmpleado = (string)dr["SegundoNombreEmpleado"];
                    employee.SegundoApellidoEmpleado = (string)dr["SegundoApellidoEmpleado"];
                    employee.CodigoAdministrativoId = (int)dr["CodigoAdministrativoID"];
                    employee.NombreGerencia = (string)dr["NombreGerencia"];
                    employee.NombreDivision = (string)dr["NombreDivision"];
                    employee.CargoId = (int)dr["CargoId"];
                    employee.NombreCargo = (string)dr["NombreCargo"];
                    employee.EstadoId = (int)dr["EstadoId"];
                    employee.NombreEstado = (string)dr["NombreEstado"];
                    employee.NivelEducativoId = (int)dr["NivelEducativoId"];
                    employee.NombreNivelEducativo = (string)dr["NombreNivelEducativo"];
                }

                return employee;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
