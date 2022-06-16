using System.ComponentModel.DataAnnotations;

namespace ProyectoAuditoria.Models
{
    public class HallazgoModel
    {
        [Required(ErrorMessage = "El campo es Obligatorio")]
        public string? IdHallazgo { get; set; }

        [Required(ErrorMessage = "El campo es Obligatorio")]
        public string? Comentario { get; set; }

        [Required(ErrorMessage = "El campo es Obligatorio")]
        public string? Recomendacion { get; set; }
    }
}
