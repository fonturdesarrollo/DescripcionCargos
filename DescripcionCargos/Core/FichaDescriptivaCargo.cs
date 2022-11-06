using DescripcionCargos.Models;
using System.Data.SqlClient;
using System.Reflection;
using static DescripcionCargos.Core.Interfaces;

namespace DescripcionCargos.Core
{
    public class FichaDescriptivaCargo : IFichaDescriptivaCargo
    {
        private readonly IConfiguration _configuration;
        public FichaDescriptivaCargo(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public int AgregarEditar(FichaDescriptivaCargoModel model)
        {
            int result = 0;
            try
            {
                using (SqlConnection sqlConnection = new(_configuration.GetConnectionString("connectionString")))
                {
                    if (model != null)
                    {
                        sqlConnection.Open();
                        SqlCommand cmd = new("FichaDescriptivaCargoAgregarEditar", sqlConnection)
                        {
                            CommandType = System.Data.CommandType.StoredProcedure
                        };
                        cmd.Parameters.AddWithValue("FichaDescriptivaCargoId", model.FichaDescriptivaCargoId);
                        cmd.Parameters.AddWithValue("PersonalId", model.PersonalId);
                        cmd.Parameters.AddWithValue("NombreSupervisorInmediato", string.IsNullOrEmpty(model.NombreSupervisorInmediato) ? "N/D" : model.NombreSupervisorInmediato.ToUpper());
                        cmd.Parameters.AddWithValue("ExperienciaCargo", string.IsNullOrEmpty(model.ExperienciaCargo) ? "N/D" : model.ExperienciaCargo.ToUpper());
                        cmd.Parameters.AddWithValue("ConocimientosHabilidades", string.IsNullOrEmpty(model.ConocimientosHabilidades) ? "N/D" : model.ConocimientosHabilidades.ToUpper());
                        cmd.Parameters.AddWithValue("ObjetivoCargo", string.IsNullOrEmpty(model.ObjetivoCargo) ? "N/D" : model.ObjetivoCargo.ToUpper());
                        cmd.Parameters.AddWithValue("QueHace", string.IsNullOrEmpty(model.QueHace) ? "N/D" : model.QueHace.ToUpper());
                        cmd.Parameters.AddWithValue("ComoLoHace", string.IsNullOrEmpty(model.ComoLoHace) ? "N/D" : model.ComoLoHace.ToUpper());
                        cmd.Parameters.AddWithValue("PorQueLoHace", string.IsNullOrEmpty(model.PorQueLoHace) ? "N/D" : model.PorQueLoHace.ToUpper());
                        cmd.Parameters.AddWithValue("ParaQueLoHace", string.IsNullOrEmpty(model.ParaQueLoHace) ? "N/D" : model.ParaQueLoHace.ToUpper());
                        cmd.Parameters.AddWithValue("LineaReporteAutonomia", string.IsNullOrEmpty(model.LineaReporteAutonomia) ? "N/D" : model.LineaReporteAutonomia.ToUpper());
                        cmd.Parameters.AddWithValue("ResponsablePor", string.IsNullOrEmpty(model.ResponsablePor) ? "N/D" : model.ResponsablePor.ToUpper());
                        cmd.Parameters.AddWithValue("RiesgoCargo", string.IsNullOrEmpty(model.RiesgoCargo) ? "N/D" : model.RiesgoCargo.ToUpper());
                        cmd.Parameters.AddWithValue("CursosCargo", string.IsNullOrEmpty(model.CursosCargo) ? "N/D" : model.CursosCargo.ToUpper());

                        result = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public FichaDescriptivaCargoModel ObtenerPorIdEmpleado(int personalId)
        {
            try
            {
                FichaDescriptivaCargoModel employee = new();
                using SqlConnection sqlConnection = new(_configuration.GetConnectionString("connectionString"));
                sqlConnection.Open();
                SqlCommand cmd = new($"SELECT * FROM View_ObtenerFichaDescriptivaCargo Where PersonalId = {personalId}", sqlConnection);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    employee.FichaDescriptivaCargoId = (int)dr["FichaDescriptivaCargoId"];
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
                    employee.NombreSupervisorInmediato =  string.IsNullOrEmpty(dr["NombreSupervisorInmediato"].ToString()) ? string.Empty : dr["NombreSupervisorInmediato"].ToString();
                    employee.ExperienciaCargo =  string.IsNullOrEmpty(dr["ExperienciaCargo"].ToString()) ? string.Empty : dr["ExperienciaCargo"].ToString();
                    employee.ConocimientosHabilidades =  string.IsNullOrEmpty(dr["ConocimientosHabilidades"].ToString()) ? string.Empty : dr["ConocimientosHabilidades"].ToString();
                    employee.ObjetivoCargo =  string.IsNullOrEmpty(dr["ObjetivoCargo"].ToString()) ? string.Empty : dr["ObjetivoCargo"].ToString();
                    employee.QueHace =  string.IsNullOrEmpty(dr["QueHace"].ToString()) ? string.Empty : dr["QueHace"].ToString();
                    employee.ComoLoHace =  string.IsNullOrEmpty(dr["ComoLoHace"].ToString()) ? string.Empty : dr["ComoLoHace"].ToString();
                    employee.PorQueLoHace =  string.IsNullOrEmpty(dr["PorQueLoHace"].ToString()) ? string.Empty : dr["PorQueLoHace"].ToString();
                    employee.ParaQueLoHace =  string.IsNullOrEmpty(dr["ParaQueLoHace"].ToString()) ? string.Empty : dr["ParaQueLoHace"].ToString();
                    employee.LineaReporteAutonomia =  string.IsNullOrEmpty(dr["LineaReporteAutonomia"].ToString()) ? string.Empty : dr["LineaReporteAutonomia"].ToString();
                    employee.ResponsablePor =  string.IsNullOrEmpty(dr["ResponsablePor"].ToString()) ? string.Empty : dr["ResponsablePor"].ToString();
                    employee.RiesgoCargo =  string.IsNullOrEmpty(dr["RiesgoCargo"].ToString()) ? string.Empty : dr["RiesgoCargo"].ToString();
                    employee.CursosCargo =  string.IsNullOrEmpty(dr["CursosCargo"].ToString()) ? string.Empty : dr["CursosCargo"].ToString();
                }

                return employee;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public FichaDescriptivaCargoModel ObtenerPorId(int fichaDescriptivaCargoId)
        {
            try
            {
                FichaDescriptivaCargoModel employee = new();
                using SqlConnection sqlConnection = new(_configuration.GetConnectionString("connectionString"));
                sqlConnection.Open();
                SqlCommand cmd = new($"SELECT * FROM View_ObtenerFichaDescriptivaCargo Where FichaDescriptivaCargoId = {fichaDescriptivaCargoId}", sqlConnection);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    employee.FichaDescriptivaCargoId = (int)dr["FichaDescriptivaCargoId"];
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
                    employee.NombreSupervisorInmediato = string.IsNullOrEmpty(dr["NombreSupervisorInmediato"].ToString()) ? string.Empty : dr["NombreSupervisorInmediato"].ToString();
                    employee.ExperienciaCargo = string.IsNullOrEmpty(dr["ExperienciaCargo"].ToString()) ? string.Empty : dr["ExperienciaCargo"].ToString();
                    employee.ConocimientosHabilidades = string.IsNullOrEmpty(dr["ConocimientosHabilidades"].ToString()) ? string.Empty : dr["ConocimientosHabilidades"].ToString();
                    employee.ObjetivoCargo = string.IsNullOrEmpty(dr["ObjetivoCargo"].ToString()) ? string.Empty : dr["ObjetivoCargo"].ToString();
                    employee.QueHace = string.IsNullOrEmpty(dr["QueHace"].ToString()) ? string.Empty : dr["QueHace"].ToString();
                    employee.ComoLoHace = string.IsNullOrEmpty(dr["ComoLoHace"].ToString()) ? string.Empty : dr["ComoLoHace"].ToString();
                    employee.PorQueLoHace = string.IsNullOrEmpty(dr["PorQueLoHace"].ToString()) ? string.Empty : dr["PorQueLoHace"].ToString();
                    employee.ParaQueLoHace = string.IsNullOrEmpty(dr["ParaQueLoHace"].ToString()) ? string.Empty : dr["ParaQueLoHace"].ToString();
                    employee.LineaReporteAutonomia = string.IsNullOrEmpty(dr["LineaReporteAutonomia"].ToString()) ? string.Empty : dr["LineaReporteAutonomia"].ToString();
                    employee.ResponsablePor = string.IsNullOrEmpty(dr["ResponsablePor"].ToString()) ? string.Empty : dr["ResponsablePor"].ToString();
                    employee.RiesgoCargo = string.IsNullOrEmpty(dr["RiesgoCargo"].ToString()) ? string.Empty : dr["RiesgoCargo"].ToString();
                    employee.CursosCargo = string.IsNullOrEmpty(dr["CursosCargo"].ToString()) ? string.Empty : dr["CursosCargo"].ToString();
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
