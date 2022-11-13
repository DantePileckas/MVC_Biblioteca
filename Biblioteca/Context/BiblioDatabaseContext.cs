using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Context
{
    public class BiblioDatabaseContext : DbContext
    {
        public BiblioDatabaseContext(DbContextOptions<BiblioDatabaseContext> options)
         : base(options)
        {
        }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Libro> Libros { get; set; }




    }
}
