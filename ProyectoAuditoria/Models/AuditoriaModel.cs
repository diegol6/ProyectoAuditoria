using System.ComponentModel.DataAnnotations;

namespace ProyectoAuditoria.Models
{
    public class AuditoriaModel
    {
        [Required(ErrorMessage = "El campo ID es Obligatorio")]
        public string? IdAuditoria { get; set; }

        [Required(ErrorMessage = "El campo es Obligatorio")]
        public string? FechaInicioAuditoria { get; set; }

        //[Required(ErrorMessage = "El campo es Obligatorio")]
        public string? FechaFinalAuditoria { get; set; }

        [Required(ErrorMessage = "El campo es Obligatorio")]
        public string? IdActivo { get; set; }

        [Required(ErrorMessage = "El campo es Obligatorio")]
        public string? IdHallazgo { get; set; }

    }
}
