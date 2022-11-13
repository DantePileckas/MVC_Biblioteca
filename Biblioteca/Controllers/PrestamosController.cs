using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Context;
using Biblioteca.Models;

namespace Biblioteca.Controllers
{
    public class PrestamosController : Controller
    {
        private readonly BiblioDatabaseContext _context;

        public PrestamosController(BiblioDatabaseContext context)
        {
            _context = context;
        }

  

        // GET: Prestamos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Prestamos.ToListAsync());
        }

        // GET: Prestamos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamos
                .FirstOrDefaultAsync(m => m.IdPrestamo == id);
            if (prestamo == null)
            {
                return NotFound();
            }

            return View(prestamo);
        }

        // GET: Prestamos/Create
        public IActionResult Create()
        {
            LibroDropDownList();
            PersonaDropDownList();
            return View();
        }

        // POST: Prestamos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPrestamo,FechaToma,FechaDevolucion,devolucion,IdLibro,IdPersona")] Prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prestamo);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            LibroDropDownList(prestamo.IdLibro);
            PersonaDropDownList(prestamo.IdPersona);
            return View(prestamo);
        }

        // GET: Prestamos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamos.FindAsync(id);
            if (prestamo == null)
            {
                return NotFound();
            }
            LibroDropDownList(prestamo.IdLibro);
            PersonaDropDownList(prestamo.IdPersona);
            return View(prestamo);
        }

        // POST: Prestamos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPrestamo,FechaToma,FechaDevolucion,devolucion,IdLibro,IdPersona")] Prestamo prestamo)
        {
            if (id != prestamo.IdPrestamo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prestamo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrestamoExists(prestamo.IdPrestamo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(prestamo);
        }

        // GET: Prestamos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamos
                .FirstOrDefaultAsync(m => m.IdPrestamo == id);
            if (prestamo == null)
            {
                return NotFound();
            }

            return View(prestamo);
        }

        // POST: Prestamos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prestamo = await _context.Prestamos.FindAsync(id);
            _context.Prestamos.Remove(prestamo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrestamoExists(int id)
        {
            return _context.Prestamos.Any(e => e.IdPrestamo == id);
        }

        private void PersonaDropDownList(int? selectedPersona = null)
        {
            var personas = _context.Personas;
            ViewBag.IdPersona = new SelectList(personas.AsNoTracking(), "IdPersona", "Nombre", selectedPersona);
        }
        private void LibroDropDownList(int? selectedLibro = null)
        {
            var libros = _context.Libros;
            ViewBag.IdLibro = new SelectList(libros.AsNoTracking(), "IdLibro", "Titulo", selectedLibro);
        }



    }
}
