using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    public class Libro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLibro { get; set; }
        [Required(ErrorMessage = "El título es obligatorio")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "El autor es obligatorio")]
        public string Autor { get; set; }

        public string LibroAutor
        {
            get
            {
                return $"{Titulo} {Autor}";
            }
        }

        [Range(0, 100,ErrorMessage ="Valores entre 0 a 100")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public int Ejemplares { get; set; }

        public bool Disponibilidad { get; set; }
      
        public ICollection<Prestamo> Prestamos { get; set; }

    }
}
