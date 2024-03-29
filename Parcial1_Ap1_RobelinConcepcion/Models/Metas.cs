﻿using System.ComponentModel.DataAnnotations;

namespace Parcial1_Ap1_RobelinConcepcion.Models
{
    public class Metas
    {
        [Key]
        public int MetaId { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "La Descripción es Obligatoria.")]
        public string? Descripción { get; set; }

        [Required(ErrorMessage = "El Monto es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El Monto debe ser mayor que cero.")]
        public decimal Monto { get; set; }
    }
}
