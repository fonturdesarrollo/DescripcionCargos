namespace DescripcionCargos.Models
{
	public class EmpleadoModel
	{
        public int PersonalId { get; set; }
        public double Cedula { get; set; }
        public string? PrimerNombreEmpleado { get; set; }
        public string? SegundoNombreEmpleado { get; set; }
        public string? PrimerApellidoEmpleado { get; set; }
        public string? SegundoApellidoEmpleado { get; set; }
        public int CargoId { get; set; }
        public string? NombreCargo { get; set; }
        public int CodigoAdministrativoId { get; set; }
        public string? NombreGerencia { get; set; }
        public string? NombreDivision { get; set; }
        public int EstadoId { get; set; }
        public string? NombreEstado { get; set; }
        public int NivelEducativoId { get; set; }
        public string? NombreNivelEducativo { get; set; }
    }
}
