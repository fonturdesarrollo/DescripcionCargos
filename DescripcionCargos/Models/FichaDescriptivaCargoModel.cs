using System.ComponentModel.DataAnnotations;

namespace DescripcionCargos.Models
{
    public class FichaDescriptivaCargoModel
    {
        [Key]
        public int FichaDescriptivaCargoId { get; set; }
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
        public string? Oficina { get; set; }
        public int EstadoId { get; set; }
        public string? NombreEstado { get; set; }
        [Required]
        public string? NombreSupervisorInmediato { get; set; }
        public int NivelEducativoId { get; set; }
        public string? NombreNivelEducativo { get; set; }
        [Required]
        public string? ExperienciaCargo { get; set; }
        [Required]
        public string? ConocimientosHabilidades { get; set; }
        [Required]
        public string? ObjetivoCargo { get; set; }
        [Required]
        public string? QueHace { get; set; }
        [Required]
        public string? ComoLoHace { get; set; }
        [Required]
        public string? PorQueLoHace { get; set; }
        [Required]
        public string? ParaQueLoHace { get; set; }
        [Required]
        public string? ResponsablePor { get; set; }
        [Required]
        public string? RiesgoCargo { get; set; }
        [Required]
        public string? CursosCargo { get; set; }
        [Required]
        public string? LineaReporteAutonomia { get; set; }
    }
}
