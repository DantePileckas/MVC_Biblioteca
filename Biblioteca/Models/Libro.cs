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

        [Range(0, 100)]
        [Required(ErrorMessage = "Campo obligatorio")]
        public int Ejemplares { get; set; }
        //public string rutaImagen { get; set; }
        public bool Disponibilidad { get; set; }
      
        [NotMapped]
        [Display(Name = "Imagen Libro:")]
        public IFormFile FotoLibro { get; set; }

        public string ImageName { get; set; }

        public byte[] PhotoFile { get; set; }

        public string ImageMimeType { get; set; }

        public ICollection<Prestamo> Prestamos { get; set; }

    }
}
