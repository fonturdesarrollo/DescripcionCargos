using DescripcionCargos.Models;

namespace DescripcionCargos.Core
{
    public class Interfaces
    {
        public interface IFichaDescriptivaCargo
        {
            public FichaDescriptivaCargoModel ObtenerPorIdEmpleado(int personalId);
            public FichaDescriptivaCargoModel ObtenerPorId(int fichaDescriptivaCargoId);
            public int AgregarEditar(FichaDescriptivaCargoModel model);
        }
        public interface IEmpleado
        {
            public EmpleadoModel ObtenerPorCedula(double cedula);
        }
    }
}
