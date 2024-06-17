using System.ComponentModel.DataAnnotations;

namespace APIexamen.Models
{
    public class Peaje
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La placa debe ser obligatoria")]
        public required string Placa { get; set; }

        [Required(ErrorMessage = "El nombre debe ser obligatorio")]
        public required string NombrePeaje { get; set; }

        [RegularExpression("^(I|II|III|IV|V)$", ErrorMessage = "La tarifa solo puede ser 'I', 'II', 'III', 'IV', 'V'.")]
        [Required(ErrorMessage = "La categoria de tarifa debe ser obligatoria")]
        public required string IdCategoriaTarifa { get; set; }

        [Required(ErrorMessage = "La fecha debe ser obligatoria")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El valor debe ser obligatoria")]
        [Range(0, Double.MaxValue, ErrorMessage = "El valor debe ser mayor o igual a 0")]
        public double Valor { get; set; }

    }
}