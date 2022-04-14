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
    public class CapituloesController : Controller
    {
        private readonly AkiraToriyamaContext _context;

        public CapituloesController(AkiraToriyamaContext context)
        {
            _context = context;
        }

        // GET: Capituloes
        public async Task<IActionResult> Index()
        {
            var akiraToriyamaContext = _context.Capitulo.Include(c => c.IdAnimeNavigation).Include(c => c.IdTemporadaNavigation);
            return View(await akiraToriyamaContext.ToListAsync());
        }

        // GET: Capituloes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var capitulo = await _context.Capitulo
                .Include(c => c.IdAnimeNavigation)
                .Include(c => c.IdTemporadaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (capitulo == null)
            {
                return NotFound();
            }

            return View(capitulo);
        }

        // GET: Capituloes/Create
        public IActionResult Create()
        {
            ViewData["IdAnime"] = new SelectList(_context.Anime, "Id", "Id");
            ViewData["IdTemporada"] = new SelectList(_context.Temporada, "Id", "Id");
            return View();
        }

        // POST: Capituloes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Creacion,Modificacion,ModificadoPor,IdTemporada,IdAnime")] Capitulo capitulo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(capitulo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAnime"] = new SelectList(_context.Anime, "Id", "Id", capitulo.IdAnime);
            ViewData["IdTemporada"] = new SelectList(_context.Temporada, "Id", "Id", capitulo.IdTemporada);
            return View(capitulo);
        }

        // GET: Capituloes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var capitulo = await _context.Capitulo.FindAsync(id);
            if (capitulo == null)
            {
                return NotFound();
            }
            ViewData["IdAnime"] = new SelectList(_context.Anime, "Id", "Id", capitulo.IdAnime);
            ViewData["IdTemporada"] = new SelectList(_context.Temporada, "Id", "Id", capitulo.IdTemporada);
            return View(capitulo);
        }

        // POST: Capituloes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,Creacion,Modificacion,ModificadoPor,IdTemporada,IdAnime")] Capitulo capitulo)
        {
            if (id != capitulo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(capitulo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CapituloExists(capitulo.Id))
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
            ViewData["IdAnime"] = new SelectList(_context.Anime, "Id", "Id", capitulo.IdAnime);
            ViewData["IdTemporada"] = new SelectList(_context.Temporada, "Id", "Id", capitulo.IdTemporada);
            return View(capitulo);
        }

        // GET: Capituloes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var capitulo = await _context.Capitulo
                .Include(c => c.IdAnimeNavigation)
                .Include(c => c.IdTemporadaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (capitulo == null)
            {
                return NotFound();
            }

            return View(capitulo);
        }

        // POST: Capituloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var capitulo = await _context.Capitulo.FindAsync(id);
            _context.Capitulo.Remove(capitulo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CapituloExists(int id)
        {
            return _context.Capitulo.Any(e => e.Id == id);
        }
    }
}
