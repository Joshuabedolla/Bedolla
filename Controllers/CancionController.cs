using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Joshua2.Data;
using Joshua2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Joshua2.Controllers
{
    public class CancionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CancionController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var canciones = await _context.Canciones.Include(c => c.Album).ToListAsync();
            return View(canciones);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var cancion = await _context.Canciones
                .Include(c => c.Album)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (cancion == null) return NotFound();

            return View(cancion);
        }

        public IActionResult Create()
        {
            ViewData["AlbumId"] = new SelectList(_context.Albums, "Id", "Titulo");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Titulo,Duracion,AlbumId,Artista,Genero,FechaLanzamiento")] Cancion cancion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cancion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["AlbumId"] = new SelectList(_context.Albums, "Id", "Titulo", cancion.AlbumId);
            return View(cancion);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var cancion = await _context.Canciones.FindAsync(id);
            if (cancion == null) return NotFound();

            ViewData["AlbumId"] = new SelectList(_context.Albums, "Id", "Titulo", cancion.AlbumId);
            return View(cancion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Duracion,AlbumId,Artista,Genero,FechaLanzamiento")] Cancion cancion)
        {
            if (id != cancion.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cancion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Canciones.Any(e => e.Id == id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["AlbumId"] = new SelectList(_context.Albums, "Id", "Titulo", cancion.AlbumId);
            return View(cancion);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var cancion = await _context.Canciones
                .Include(c => c.Album)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (cancion == null) return NotFound();

            return View(cancion);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cancion = await _context.Canciones.FindAsync(id);
            _context.Canciones.Remove(cancion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
