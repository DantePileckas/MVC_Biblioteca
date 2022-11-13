using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Context;
using Biblioteca.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Web.Helpers;

namespace Biblioteca.Controllers
{
    public class LibrosController : Controller
    {
        private readonly BiblioDatabaseContext _context;
        private IWebHostEnvironment _environment;

        public LibrosController(BiblioDatabaseContext context)

        {
            _context = context;
        }

        // GET: Libros
        public async Task<IActionResult> Index(string searchString)
        {
            var libros = from l in _context.Libros select l;
            if (!String.IsNullOrEmpty(searchString))
            {
                libros = libros.Where(l => l.Titulo!.Contains(searchString));
            }

            return View(await libros.ToListAsync());
        }

        // GET: Libros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros
                .FirstOrDefaultAsync(m => m.IdLibro == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // GET: Libros/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on" + searchString;
        }

        public void CreateLibro(Libro libro)
        {
            if (libro.FotoLibro != null && libro.FotoLibro.Length > 0)
            {
                libro.ImageMimeType = libro.FotoLibro.ContentType;
                libro.ImageName = Path.GetFileName(libro.FotoLibro.FileName);
                if (ModelState.IsValid)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        libro.FotoLibro.CopyTo(memoryStream);
                        libro.PhotoFile = memoryStream.ToArray();
                    }
                }
                _context.Add(libro);
                _context.SaveChanges();
            }
        }

        // POST: Libros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLibro,Titulo,Autor,Ejemplares,FotoLibro,Disponibilidad")] Libro libro)
        {


            if (ModelState.IsValid)
            {
                CreateLibro(libro);
                _context.Add(libro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(libro);
        }

        // GET: Libros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }
            return View(libro);
        }

        // POST: Libros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLibro,Titulo,Autor,Ejemplares,rutaImagen,Disponibilidad")] Libro libro)
        {
            if (id != libro.IdLibro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroExists(libro.IdLibro))
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
            return View(libro);
        }

        // GET: Libros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros
                .FirstOrDefaultAsync(m => m.IdLibro == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // POST: Libros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            _context.Libros.Remove(libro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibroExists(int id)
        {
            return _context.Libros.Any(e => e.IdLibro == id);
        }

        public Libro GetLibroPorId(int id)
        {
            return _context.Libros.Include(l => l.Prestamos)
                .SingleOrDefault(l => l.IdLibro == id);
        }

   

        public IActionResult GetImage(int id)
        {
            Libro requestedLibro = GetLibroPorId(id);
            if (requestedLibro != null)
            {
                string webRootpath = _environment.WebRootPath;
                string folderPath = "\\img\\";
                string fullPath = webRootpath + folderPath + requestedLibro.ImageName;
                if (System.IO.File.Exists(fullPath))
                {
                    FileStream fileOnDisk = new FileStream(fullPath, FileMode.Open);
                    byte[] fileBytes;
                    using (BinaryReader br = new BinaryReader(fileOnDisk))
                    {
                        fileBytes = br.ReadBytes((int)fileOnDisk.Length);
                    }
                    return File(fileBytes, requestedLibro.ImageMimeType);
                }
                else
                {
                    if (requestedLibro.PhotoFile.Length > 0)
                    {
                        return File(requestedLibro.PhotoFile, requestedLibro.ImageMimeType);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            else
            {
                return NotFound();
            }
        }

    }
}



