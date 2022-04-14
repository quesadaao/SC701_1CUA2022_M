using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FE.W.Models;

namespace FE.W.Controllers
{
    public class TemporadasController : Controller
    {
        private readonly AkiraToriyamaContext _context;

        public TemporadasController(AkiraToriyamaContext context)
        {
            _context = context;
        }

        // GET: Temporadas
        public async Task<IActionResult> Index()
        {
            var akiraToriyamaContext = _context.Temporada.Include(t => t.IdAnimeNavigation);
            return View(await akiraToriyamaContext.ToListAsync());
        }

        // GET: Temporadas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temporada = await _context.Temporada
                .Include(t => t.IdAnimeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (temporada == null)
            {
                return NotFound();
            }

            return View(temporada);
        }

        // GET: Temporadas/Create
        public IActionResult Create()
        {
            ViewData["IdAnime"] = new SelectList(_context.Anime, "Id", "Id");
            return View();
        }

        // POST: Temporadas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,CantidadCapitulos,Creacion,Modificacion,ModificadoPor,IdAnime")] Temporada temporada)
        {
            if (ModelState.IsValid)
            {
                _context.Add(temporada);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAnime"] = new SelectList(_context.Anime, "Id", "Id", temporada.IdAnime);
            return View(temporada);
        }

        // GET: Temporadas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temporada = await _context.Temporada.FindAsync(id);
            if (temporada == null)
            {
                return NotFound();
            }
            ViewData["IdAnime"] = new SelectList(_context.Anime, "Id", "Id", temporada.IdAnime);
            return View(temporada);
        }

        // POST: Temporadas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,CantidadCapitulos,Creacion,Modificacion,ModificadoPor,IdAnime")] Temporada temporada)
        {
            if (id != temporada.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(temporada);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TemporadaExists(temporada.Id))
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
            ViewData["IdAnime"] = new SelectList(_context.Anime, "Id", "Id", temporada.IdAnime);
            return View(temporada);
        }

        // GET: Temporadas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temporada = await _context.Temporada
                .Include(t => t.IdAnimeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (temporada == null)
            {
                return NotFound();
            }

            return View(temporada);
        }

        // POST: Temporadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var temporada = await _context.Temporada.FindAsync(id);
            _context.Temporada.Remove(temporada);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TemporadaExists(int id)
        {
            return _context.Temporada.Any(e => e.Id == id);
        }
    }
}
