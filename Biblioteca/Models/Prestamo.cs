using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    public class Prestamo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPrestamo { get; set; }
        public DateTime FechaToma { get; set; }

        [Required(ErrorMessage = "Revisa la Fecha")]
        public DateTime FechaDevolucion { get; set; }
        public bool devolucion { get; set; }

        [Required(ErrorMessage = "Seleccionar un Libro")]
        public int? IdLibro { get; set; }
        public virtual Libro libro { get; set; }

        [Required(ErrorMessage = "Seleccionar un Lector")]
        public int? IdPersona { get; set; }
        public virtual Persona persona { get; set; }

    }
}
