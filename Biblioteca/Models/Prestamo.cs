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
        public DateTime FechaDevolucion { get; set; }
        public bool devolucion { get; set; }

        [ForeignKey("Libro")]
        [Column("IdLibro")]
        public int? IdLibro { get; set; }

        [Required(ErrorMessage = "Seleccionar un Libro")]
        public Libro Libro { get; set; }



        [ForeignKey("Persona")]
        [Column("IdPersona")]
        public int? IdPersona { get; set; }

        [Required(ErrorMessage = "Seleccionar un lector")]
        public virtual Persona Lector { get; set; }

    }
}
