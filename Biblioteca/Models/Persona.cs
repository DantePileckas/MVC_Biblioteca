using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    public class Persona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPersona { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El apellido es obligatorio")]
    
        public string Apellido { get; set; }
        public string NombreApellido
        {
            get { return $"{Nombre} {Apellido}";
            }
        }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Correo no válido")]
        public string Correo { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "La clave es obligatorio")]
        [MaxLength(8,ErrorMessage = "Longitud mínima: 8 caracteres")]
        public string Clave { get; set; }
        public ICollection<Prestamo> Prestamos { get; set; }

    }
}
