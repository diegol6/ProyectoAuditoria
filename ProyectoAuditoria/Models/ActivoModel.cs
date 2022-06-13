using System.ComponentModel.DataAnnotations;

namespace ProyectoAuditoria.Models
{
    public class ActivoModel
    {
        [Required(ErrorMessage = "El campo ID es Obligatorio")]
        public string? IdActivo { get; set; }

        [Required(ErrorMessage = "El campo es Obligatorio")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El campo es Obligatorio")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "El campo es Obligatorio")]
        public string? Tipo { get; set; }

        [Required(ErrorMessage = "El campo es Obligatorio")]
        public string? Departamento { get; set; }

        [Required(ErrorMessage = "El campo es Obligatorio")]
        public string? Clasificacion { get; set; }

        [Required(ErrorMessage = "El campo es Obligatorio")]
        public string? Criticidad { get; set; }

        [Required(ErrorMessage = "El campo es Obligatorio")]
        public string? Propietario { get; set; }

        [Required(ErrorMessage = "El campo es Obligatorio")]
        public string? Custodio { get; set; }

        [Required(ErrorMessage = "El campo es Obligatorio")]
        public string? Usuarios { get; set; }

        [Required(ErrorMessage = "El campo es Obligatorio")]
        public string? Fecha_Ingreso { get; set; }

        //[Required(ErrorMessage = "El campo es Obligatorio")]
        public string? Fecha_Salida { get; set; }

    }
}
